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
    public partial class Xfrm_DSSV_1LTC : DevExpress.XtraEditors.XtraForm
    {
        public Xfrm_DSSV_1LTC()
        {
            InitializeComponent();
            DSKhoa();
            DSMon();
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

        private void DSMon()
        {
            if (Program.Connect() == 0) return;

            DataTable dt2 = Program.ExecSqlDataTable("EXEC SP_LAY_DS_MONHOC");

            cbMonhoc.DataSource = dt2;
            cbMonhoc.DisplayMember = "TENMH";
            cbMonhoc.ValueMember = "MAMH";
            cbMonhoc.SelectedIndex = 0;
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

        private void btnLoadLTC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String exec = "EXEC SP_DS_LTC @NIENKHOA = '" + cbNienkhoa.SelectedValue.ToString() +
                "', @HOCKY = " + cbHocky.SelectedItem.ToString() +
                ", @MAMH = '" + cbMonhoc.SelectedValue.ToString() +
                "', @SERVER_HIENTAI = '" + Program.mKhoa +
                "', @SERVER_DICH = '" + cbKhoa.SelectedValue.ToString() + "'";

            tbDS.DataSource = Program.ExecSqlDataTable(exec);
        }

        private void btnBaocao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tbDS.Rows.Count - 1 > 0 && tbDS.Rows.Count - 1 > tbDS.CurrentCell.RowIndex)
            {
                int index = tbDS.CurrentCell.RowIndex;
                String maLTCHientai = tbDS.Rows[index].Cells[0].Value.ToString();
                String tenKhoa = (String)((DataRowView)cbKhoa.Items[cbKhoa.SelectedIndex])["TENKHOA"];
                String tenMon = (String)((DataRowView)cbMonhoc.Items[cbMonhoc.SelectedIndex])["TENMH"];
                String nhom = tbDS.Rows[index].Cells[6].Value.ToString();

                Xrpt_DSSV_1LTC_new rpt = new Xrpt_DSSV_1LTC_new(
                    cbNienkhoa.SelectedValue.ToString(),
                    cbHocky.SelectedItem.ToString(),
                    tenKhoa,
                    tenMon,
                    nhom,
                    maLTCHientai
                    );
                
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }
        }
    }
}