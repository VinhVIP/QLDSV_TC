using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class frmLop : DevExpress.XtraEditors.XtraForm
    {

        private String maKhoa, maLop;
        private DataTable dtSV;

        private int lastLopPosition;
        private bool committed = true;

        private String curServer;
        private String curLogin, curPass;

        public frmLop()
        {
            InitializeComponent();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            DS_LOP.EnforceConstraints = false;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTableAdapter.Fill(this.DS_LOP.LOP);

            comboKhoa.DataSource = Program.bdsDSKhoa;
            comboKhoa.DisplayMember = "TENPM";
            comboKhoa.ValueMember = "TENSERVER";

            comboKhoa.Text = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";

            maKhoa = comboKhoa.Text;

            curServer = Program.server;
            curLogin = Program.mLogin;
            curPass = Program.pass;

            initState();
        }

        private void initState()
        {
            btnGhi.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = btnReload.Enabled = gcLop.Enabled = true;
            btnUndo.Enabled = gvSV.Enabled = panelLop.Enabled = false;
        }

        private void comboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.server = comboKhoa.SelectedValue.ToString();     

            if (comboKhoa.Text != Program.mKhoa)
            {
                Program.mLogin = Program.remoteLogin;
                Program.pass = Program.remotePass;
            }
            else
            {
                Program.mLogin = Program.loginDN;
                Program.pass = Program.passDN;
            }

            // Lưu lại server đang thao tác
            curServer = Program.server;
            curLogin = Program.mLogin;
            curPass = Program.pass;

            if (Program.Connect() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới! ", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
                this.LOPTableAdapter.Fill(this.DS_LOP.LOP);
                
                maKhoa = comboKhoa.Text;

                initState();
            }
        }

        private void btnLoadDSSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
            String sql = "EXEC SP_LAY_DSSV_LOP " + maLop;
            dtSV = Program.ExecSqlDataTable(sql);

            gvSV.DataSource = dtSV;

            for(int i=0; i < dtSV.Rows.Count; i++)
            {
                gvSV.Rows[i].Cells[0].ReadOnly = true;
            }

            committed = true;

            gcLop.Enabled = panelLop.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = btnReload.Enabled = false;
            gvSV.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (dtSV == null || dtSV.Rows.Count == 0) return;

            int removePos = gvSV.CurrentCell.RowIndex;

            String maSV = gvSV.Rows[removePos].Cells["MASV"].Value.ToString();
            Console.WriteLine(maSV);

            int result = Program.ExecSqlNonQuery("SP_XOA_SV", CommandType.StoredProcedure, new[] {
                        new SqlParameter("@masv", SqlDbType.NChar){Value=maSV}
                    });

            if (result == 1)
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                dtSV.Rows.RemoveAt(removePos);
            }
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            dtSV.Rows.Add();

            dtSV.Rows[dtSV.Rows.Count - 1]["PHAI"] = false;
            dtSV.Rows[dtSV.Rows.Count - 1]["DANGHIHOC"] = false;

        }


        private void bdsLOP_PositionChanged(object sender, EventArgs e)
        {
            if (dtSV != null && dtSV.Rows.Count > 0) dtSV.Clear();
        }

        private void gvSV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            committed = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.AddNew();

            txtMaKhoa.Text = maKhoa;

            lastLopPosition = bdsLOP.Position;

            btnThem.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = gvSV.Enabled = gcLop.Enabled = btnReload.Enabled = false;
            panelLop.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;

            txtMaLop.Focus();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (panelLop.Enabled)
            {
                bdsLOP.CancelEdit();
                bdsLOP.RemoveAt(bdsLOP.Count - 1);
            }

            initState();
            

            //gcLop.Enabled = true;
            //panelLop.Enabled = gvSV.Enabled = false;

            //btnUndo.Enabled = false;
            //btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnLoadDSSV.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (MessageBox.Show("Bạn thực sự muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();

                int result = Program.ExecSqlNonQuery("SP_XOA_LOP", CommandType.StoredProcedure, new[] {
                        new SqlParameter("@malop", SqlDbType.NChar){Value=maLop}
                    });

                if (result == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    //bdsLOP.RemoveCurrent();
                    LOPTableAdapter.Connection.ConnectionString = Program.connString;
                    this.LOPTableAdapter.Fill(this.DS_LOP.LOP);
                }
            }

            if (bdsLOP.Count == 0) btnXoa.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LOPTableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTableAdapter.Fill(this.DS_LOP.LOP);
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (panelLop.Enabled)
            {
                // Thêm lớp
                // Kiểm tra các ràng buộc
                if (txtMaLop.Text.Trim() == "")
                {
                    MessageBox.Show("Mã lớp không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                    txtMaLop.Focus();
                    return;
                }
                if (txtTenLop.Text.Trim() == "")
                {
                    MessageBox.Show("Tên lớp không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                    txtTenLop.Focus();
                    return;
                }
                if (txtKhoaHoc.Text.Trim() == "")
                {
                    MessageBox.Show("Khóa học không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                    txtKhoaHoc.Focus();
                    return;
                }


                string maLop = txtMaLop.Text.Trim();

                if (Program.ExecSqlNonQuery("SP_THEM_LOP", CommandType.StoredProcedure, new[]
                {
                        new SqlParameter("@malop", SqlDbType.NChar){Value=maLop},
                        new SqlParameter("@tenlop", SqlDbType.NVarChar){Value=txtTenLop.Text.Trim()},
                        new SqlParameter("@khoahoc", SqlDbType.NChar){Value=txtKhoaHoc.Text.Trim()},
                        new SqlParameter("@makhoa", SqlDbType.NChar){Value=txtMaKhoa.Text}
                    }) == 1)
                {
                    LOPTableAdapter.Connection.ConnectionString = Program.connString;
                    LOPTableAdapter.Fill(DS_LOP.LOP);
                    
                    MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);
                    
                    btnGhi.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = btnReload.Enabled = gcLop.Enabled = true;
                    btnUndo.Enabled = gvSV.Enabled = panelLop.Enabled = false;
                }
                
            }
            else
            {
                if (gcLop.Enabled)
                {
                    try
                    {
                        // Cập nhật Lớp
                        bdsLOP.EndEdit();
                        bdsLOP.ResetCurrentItem();
                        LOPTableAdapter.Connection.ConnectionString = Program.connString;
                        LOPTableAdapter.Update(DS_LOP.LOP);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Cập nhật lớp thất bại: "+ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);

                    btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = gcLop.Enabled = btnReload.Enabled = true;
                    btnUndo.Enabled = gvSV.Enabled = panelLop.Enabled = false;
                }
                

                if (gvSV.Enabled)
                {
                    // Thêm sinh viên
                    DataTable dt = new DataTable();

                    dt.Columns.Add("MASV", typeof(string));
                    dt.Columns.Add("HO", typeof(string));
                    dt.Columns.Add("TEN", typeof(string));
                    dt.Columns.Add("PHAI", typeof(bool));
                    dt.Columns.Add("DIACHI", typeof(string));
                    dt.Columns.Add("NGAYSINH", typeof(string));
                    dt.Columns.Add("MALOP", typeof(string));
                    dt.Columns.Add("DANGHIHOC", typeof(bool));
                    dt.Columns.Add("PASSWORD", typeof(string));


                    for (int i = 0; i < dtSV.Rows.Count; i++)
                    {
                        dt.Rows.Add(dtSV.Rows[i]["MASV"], dtSV.Rows[i]["HO"],
                            dtSV.Rows[i]["TEN"], dtSV.Rows[i]["PHAI"],
                            dtSV.Rows[i]["DIACHI"], convertDate(dtSV.Rows[i]["NGAYSINH"].ToString()), maLop,
                            dtSV.Rows[i]["DANGHIHOC"], dtSV.Rows[i]["PASSWORD"]
                        );
                    }

                    SqlParameter param = new SqlParameter();
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.TYPE_SINHVIEN";
                    param.ParameterName = "@SV";
                    param.Value = dt;

                    Program.Connect();
                    try
                    {
                        SqlCommand sqlCmd = new SqlCommand("SP_IU_SV", Program.conn);
                        sqlCmd.Parameters.Clear();
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add(param);
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi sinh viên: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);

                    committed = true;

                    btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = gcLop.Enabled = btnReload.Enabled = true;
                    btnUndo.Enabled = gvSV.Enabled = panelLop.Enabled = false;
                }
                

            }
            
        }

        private void connectLoginSite()
        {
            Program.server = curServer;
            Program.mLogin = curLogin;
            Program.pass = curPass;

            Program.Connect();
        }

        /**
         * date: dd/MM/yyyy
         * @return  MM/dd/yyyy
         */
        private string convertDate(string date)
        {
            if (date == null || date == "") return null;
            string[] s = date.Split('/');
            if (s.Length < 3) return null;
            Console.WriteLine(date + " " + s.Length);
            return s[1] + '/' + s[0] + '/' + s[2];
        }

    }
}