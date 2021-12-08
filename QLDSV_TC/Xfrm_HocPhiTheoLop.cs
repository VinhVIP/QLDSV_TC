using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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
    public partial class Xfrm_HocPhiTheoLop : DevExpress.XtraEditors.XtraForm
    {
        public Xfrm_HocPhiTheoLop()
        {
            InitializeComponent();
        }

        private void Xfrm_HocPhiTheoLop_Load(object sender, EventArgs e)
        {
            DS_LOP.EnforceConstraints = false;
            this.lOPTableAdapter.Connection.ConnectionString = Program.connString;
            
            this.lOPTableAdapter.Fill(this.DS_LOP.LOP);

            comboNK.SelectedIndex = comboHK.SelectedIndex = 0;
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS_LOP);

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            String maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
            String maKhoa = ((DataRowView)bdsLOP[bdsLOP.Position])["MAKHOA"].ToString();
            

            if (comboNK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập niên khóa!", "Thông báo", MessageBoxButtons.OK);
                comboNK.Focus();
                return;
            }
            else if (Regex.IsMatch(comboNK.Text, "^[0-9]{4}-[0-9]{4}$") == false)
            {
                MessageBox.Show("Niên khóa phải có định dạng ####-####", "Lỗi", MessageBoxButtons.OK);
                comboNK.Focus();
                return;
            }

            String nienKhoa = comboNK.Text.Trim();
            int hocKy = int.Parse(comboHK.Text);

            Program.ExecSqlDataReader("SP_KTR_SV_LOP", CommandType.StoredProcedure, new[] {
                     new SqlParameter("@MALOP", SqlDbType.NVarChar){Value=maLop},
                     new SqlParameter("@NIENKHOA", SqlDbType.NVarChar){Value=nienKhoa },
                     new SqlParameter("@HOCKY", SqlDbType.Int){Value=hocKy},
                 });
            if (Program.reader.Read())
            {
                Program.reader.Close();
                Xrpt_InDSHP_LOP rpt = new Xrpt_InDSHP_LOP(maLop, nienKhoa, hocKy);
                String sql = "EXEC SP_LAY_TEN_KHOA " + maKhoa;
                Program.ExecSqlDataReader(sql);
                String khoa;
                Int64 tong;
                Program.reader.Read();

                khoa = Program.reader.GetString(0);

                Program.reader.Close();
                Program.ExecSqlDataReader("SP_SUM_HP_LOP", CommandType.StoredProcedure, new[] {
                     new SqlParameter("@MALOP", SqlDbType.NVarChar){Value=maLop},
                     new SqlParameter("@NIENKHOA", SqlDbType.NVarChar){Value=nienKhoa },
                     new SqlParameter("@HOCKY", SqlDbType.Int){Value=hocKy},
                 });

                Program.reader.Read();

                tong = Int64.Parse(Program.reader.GetValue(0).ToString());

                Program.reader.Close();
                rpt.setInfo(maLop, khoa, tong);

                ReportPrintTool print = new ReportPrintTool(rpt);

                print.ShowPreviewDialog();
            }
            else
            {
                MessageBox.Show("Lớp không có sinh viên đăng ký trong niên khóa, học kì này!!", "", MessageBoxButtons.OK);
                Program.reader.Close();
                return;
            }
            

        }
    }
}