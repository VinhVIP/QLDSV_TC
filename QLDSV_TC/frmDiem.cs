using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class frmDiem : DevExpress.XtraEditors.XtraForm
    {

        private String maLTC;
        private DataTable dtDSDK, dtCopy;

        public frmDiem()
        {
            InitializeComponent();
        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            comboKhoa.DataSource = Program.bdsDSKhoa;
            comboKhoa.DisplayMember = "TENKHOA";
            comboKhoa.ValueMember = "TENPM";

            comboKhoa.SelectedValue = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";

            comboNK.SelectedIndex = comboHK.SelectedIndex = 0;
        }

        private void comboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.server = Program.khoa[comboKhoa.Text].Item2;

            if (Program.khoa[comboKhoa.Text].ToString() != Program.mKhoa)
            {
                Program.mLogin = Program.remoteLogin;
                Program.pass = Program.remotePass;
            }
            else
            {
                Program.mLogin = Program.loginDN;
                Program.pass = Program.passDN;
            }

            if (Program.Connect() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới! ", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboNK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập niên khóa!", "Thông báo", MessageBoxButtons.OK);
                comboNK.Focus();
                return;
            }else if (Regex.IsMatch(comboNK.Text, "^[0-9]{4}-[0-9]{4}$") == false)
            {
                MessageBox.Show("Niên khóa phải có định dạng ####-####", "Lỗi", MessageBoxButtons.OK);
                comboNK.Focus();
                return;
            }

            try
            {
                this.SP_LAY_DS_LTCTableAdapter.Connection.ConnectionString = Program.connString;
                this.SP_LAY_DS_LTCTableAdapter.Fill(this.DS_LTC.SP_LAY_DS_LTC, comboNK.Text, int.Parse(comboHK.Text));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            if (bdsDSLTC.Count == 0) return;

            maLTC = ((DataRowView)bdsDSLTC[bdsDSLTC.Position])["MALTC"].ToString();
            String sql = "EXEC SP_LAY_DSSV_DANGKY " + maLTC;
            dtDSDK = Program.ExecSqlDataTable(sql);

            dtDSDK.Columns.Add("DIEM_TK", typeof(float));

            float diemCC, diemGK, diemCK, diemTK;

            // Copy
            dtCopy = new DataTable();
            dtCopy.Columns.Add("MASV", typeof(string));
            dtCopy.Columns.Add("DIEM_CC", typeof(float));
            dtCopy.Columns.Add("DIEM_GK", typeof(float));
            dtCopy.Columns.Add("DIEM_CK", typeof(float));

            for (int i = 0; i < dtDSDK.Rows.Count; i++)
            {
                diemCC = dtDSDK.Rows[i]["DIEM_CC"].ToString().Length == 0 ? 0 : float.Parse(dtDSDK.Rows[i]["DIEM_CC"].ToString());
                diemGK = dtDSDK.Rows[i]["DIEM_GK"].ToString().Length == 0 ? 0 : float.Parse(dtDSDK.Rows[i]["DIEM_GK"].ToString());
                diemCK = dtDSDK.Rows[i]["DIEM_CK"].ToString().Length == 0 ? 0 : float.Parse(dtDSDK.Rows[i]["DIEM_CK"].ToString());

                diemTK = diemCC * 0.1f + diemGK * 0.3f + diemCK * 0.6f;
                dtDSDK.Rows[i]["DIEM_TK"] = diemTK.ToString("0.##");

                // Copy data
                dtCopy.Rows.Add(dtDSDK.Rows[i]["MASV"], dtDSDK.Rows[i]["DIEM_CC"], dtDSDK.Rows[i]["DIEM_GK"], dtDSDK.Rows[i]["DIEM_CK"]);
            }

            dtDSDK.Columns["MASV"].ReadOnly = true;
            dtDSDK.Columns["HOTENSV"].ReadOnly = true;
            dtDSDK.Columns["DIEM_TK"].ReadOnly = true;

            gcDiem.DataSource = dtDSDK;
        }

        private void btnGhiDiem_Click(object sender, EventArgs e)
        {
            if (dtDSDK == null || dtDSDK.Rows.Count == 0) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("MALTC", typeof(int));
            dt.Columns.Add("MASV", typeof(string));
            dt.Columns.Add("DIEM_CC", typeof(float));
            dt.Columns.Add("DIEM_GK", typeof(float));
            dt.Columns.Add("DIEM_CK", typeof(float));

            int ltc = int.Parse(maLTC);

            for (int i = 0; i < dtDSDK.Rows.Count; i++)
            {
                if (isSameData(dtCopy.Rows[i], dtDSDK.Rows[i]) == false)
                {
                    dt.Rows.Add(ltc, dtDSDK.Rows[i]["MASV"], dtDSDK.Rows[i]["DIEM_CC"], dtDSDK.Rows[i]["DIEM_GK"], dtDSDK.Rows[i]["DIEM_CK"]);
                    Console.WriteLine(dtDSDK.Rows[i]["MASV"]);
                }
            }

            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = "dbo.TYPE_DANGKY";
            param.ParameterName = "@DIEMTHI";
            param.Value = dt;

            Program.Connect();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("SP_UPDATE_DIEM", Program.conn);
                sqlCmd.Parameters.Clear();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(param);
                sqlCmd.ExecuteNonQuery();

                MessageBox.Show("Ghi điểm thành công!", "Thông báo", MessageBoxButtons.OK);

                dtCopy.Clear();
                for (int i = 0; i < dtDSDK.Rows.Count; i++)
                {
                    dtCopy.Rows.Add(dtDSDK.Rows[i]["MASV"], dtDSDK.Rows[i]["DIEM_CC"], dtDSDK.Rows[i]["DIEM_GK"], dtDSDK.Rows[i]["DIEM_CK"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi điểm: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void goToNextCell(int row, int col)
        {
            if (row != -1)
            {
                if (col < 2)
                {
                    col = 2;
                }
                else if (col > 4)
                {
                    col = 2;
                    row = Math.Min(dtDSDK.Rows.Count - 1, row + 1);
                }
                gcDiem.CurrentCell = gcDiem.Rows[row].Cells[col];
            }
        }


        private int row = -1, col = -1;
        bool mustEdit = false;

        private void gcDiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (mustEdit)
            {
                gcDiem.CurrentCell = gcDiem.Rows[row].Cells[col];
                mustEdit = false;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                goToNextCell(gcDiem.CurrentCell.RowIndex, gcDiem.CurrentCell.ColumnIndex);
            }
        }

        private void tinhDiemTK(int row)
        {
            float diemCC = gcDiem.Rows[row].Cells[2].Value.ToString().Length > 0 ? float.Parse(gcDiem.Rows[row].Cells[2].Value.ToString()) : 0f;
            float diemGK = gcDiem.Rows[row].Cells[3].Value.ToString().Length > 0 ? float.Parse(gcDiem.Rows[row].Cells[3].Value.ToString()) : 0f;
            float diemCK = gcDiem.Rows[row].Cells[4].Value.ToString().Length > 0 ? float.Parse(gcDiem.Rows[row].Cells[4].Value.ToString()) : 0f;

            float diemTK = diemCC * 0.1f + diemGK * 0.3f + diemCK * 0.6f;
            dtDSDK.Columns["DIEM_TK"].ReadOnly = false;
            gcDiem.Rows[row].Cells[5].Value = diemTK.ToString("0.##");
            dtDSDK.Columns["DIEM_TK"].ReadOnly = true;
        }


        private void gcDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.ColumnIndex <= 4)
            {
                String val = gcDiem.CurrentCell.Value.ToString();
                var rowView = ((DataRowView)gcDiem.Rows[e.RowIndex].DataBoundItem).Row;

                if (val.Trim().Length > 0)
                {
                    float mark = float.Parse(val);
                    if (mark < 0 || mark > 10)
                    {
                        row = e.RowIndex;
                        col = e.ColumnIndex;

                        MessageBox.Show("Điểm phải nằm trong phạm vi 0-10", "Thông báo", MessageBoxButtons.OK);

                        rowView.RejectChanges();
                        tinhDiemTK(e.RowIndex);

                        mustEdit = true;

                        return;
                    }
                    else
                    {
                        float nguyen = (float) Math.Floor(mark);
                        float tp = mark - nguyen;

                        if(tp >= 0 && tp < 0.25)
                        {
                            mark = nguyen;
                        }else if(tp < 0.75)
                        {
                            mark = nguyen + 0.5f;
                        }
                        else
                        {
                            mark = nguyen + 1f;
                        }

                        gcDiem.CurrentCell.Value = mark;
                        tinhDiemTK(e.RowIndex);
                    }
                }

                rowView.AcceptChanges();
                mustEdit = false;
            }

            tinhDiemTK(e.RowIndex);
        }

        private bool isSameData(DataRow a, DataRow b)
        {
            return a["DIEM_CC"].ToString().Trim().Equals(b["DIEM_CC"].ToString().Trim()) &&
                a["DIEM_GK"].ToString().Trim().Equals(b["DIEM_GK"].ToString().Trim()) &&
                a["DIEM_CK"].ToString().Trim().Equals(b["DIEM_CK"].ToString().Trim());
        }

    }
}