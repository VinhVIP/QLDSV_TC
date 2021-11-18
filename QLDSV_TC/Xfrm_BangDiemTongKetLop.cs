using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class Xfrm_BangDiemTongKetLop : DevExpress.XtraEditors.XtraForm
    {
        public Xfrm_BangDiemTongKetLop()
        {
            InitializeComponent();
        }

        private void Xfrm_BangDiemTongKetLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_LOP.LOP' table. You can move, or remove it, as needed.
            this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTableAdapter.Fill(this.DS_LOP.LOP);

            comboKhoa.DataSource = Program.bdsDSKhoa;
            comboKhoa.DisplayMember = "TENPM";
            comboKhoa.ValueMember = "TENSERVER";

            comboKhoa.SelectedText = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string maLop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
            string tenLop = ((DataRowView)bdsLop[bdsLop.Position])["TENLOP"].ToString();
            string khoaHoc = ((DataRowView)bdsLop[bdsLop.Position])["KHOAHOC"].ToString();

            Xrpt_BangDiemTongKetLop rpt = new Xrpt_BangDiemTongKetLop(maLop);
            rpt.setInfo(maLop, tenLop, khoaHoc, comboKhoa.Text);

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
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

            if (Program.Connect() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới! ", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
                this.LOPTableAdapter.Fill(this.DS_LOP.LOP);
            }
        }

    }
}