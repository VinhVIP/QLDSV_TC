using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace QLDSV_TC
{
    public partial class Xfrm_DS_LTC : DevExpress.XtraEditors.XtraForm
    {
        public Xfrm_DS_LTC()
        {
            InitializeComponent();
        }

        private void Xfrm_DS_LTC_Load(object sender, EventArgs e)
        {
            DSKhoa();
            DSNienkhoa();
            DSHocKy();
        }

        private void DSKhoa()
        {
            String exec = "EXEC SP_LAY_DS_KHOA_2 @ROLE= '" + Program.role + "'";

            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable(exec);

            cbKhoa.DataSource = dt;
            cbKhoa.DisplayMember = "TENKHOA";
            cbKhoa.ValueMember = "MAKHOA";
            cbKhoa.SelectedValue = Program.mKhoa;
        }

        private void DSNienkhoa()
        {
            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable("EXEC SP_DS_NIENKHOA");
            cbNienkhoa.DataSource = dt;
            cbNienkhoa.DisplayMember = "NIENKHOA";
            cbNienkhoa.ValueMember = "NIENKHOA";
            cbNienkhoa.SelectedIndex = 0;
        }

        private void DSHocKy()
        {
            cbHocky.Items.Add("1");
            cbHocky.Items.Add("2");
            cbHocky.Items.Add("3");
            cbHocky.Items.Add("4");
            cbHocky.SelectedIndex = 0;
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            String tenKhoa = (String) ((DataRowView)cbKhoa.Items[cbKhoa.SelectedIndex])["TENKHOA"];

            Xrpt_DS_LTC rpt = new Xrpt_DS_LTC(cbNienkhoa.SelectedValue.ToString(), 
                cbHocky.SelectedItem.ToString(),
                tenKhoa);

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}