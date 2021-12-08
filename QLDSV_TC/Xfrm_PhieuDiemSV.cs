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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class Xfrm_PhieuDiemSV : DevExpress.XtraEditors.XtraForm
    {
        public Xfrm_PhieuDiemSV()
        {
            InitializeComponent();
        }

        private void Xfrm_PhieuDiemSV_Load(object sender, EventArgs e)
        {
            comboKhoa.DataSource = Program.bdsDSKhoa;

            comboKhoa.DisplayMember = "TENKHOA";
            comboKhoa.ValueMember = "TENPM";

            comboKhoa.SelectedValue = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string maSV = txtMASV.Text;

            if(maSV.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            Program.ExecSqlDataReader("SP_INFO_SV", CommandType.StoredProcedure, new[]
            {
                new SqlParameter("@masv", SqlDbType.NChar){Value=maSV}
            });

            if (Program.reader.Read())
            {
                
                Xrpt_PhieuDiemSV rpt = new Xrpt_PhieuDiemSV(maSV);

                rpt.setInfo(Program.reader.GetString(0), Program.reader.GetString(1), comboKhoa.Text);
                Program.reader.Close();

                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
            else
            {
                MessageBox.Show("Sinh viên không tồn tại! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                Program.reader.Close();
                return;
            }

           
        }
        
    }
}