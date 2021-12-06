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
using System.Data.SqlClient;

namespace QLDSV_TC
{
    public partial class frmDKLTC : DevExpress.XtraEditors.XtraForm
    {
        public frmDKLTC()
        {
            InitializeComponent();
        }

        private void frmDKLTC_Load(object sender, EventArgs e)
        {
            initButton();
            DSHocKy();
            DSKhoa();
            DSNienkhoa();
        }

        private void initButton()
        {
            btnDK.Enabled = btnHuy.Enabled = btnReload.Enabled = false;
            btnLoadDS.Enabled = true;
        }

        private void DSKhoa()
        {
            String exec = "EXEC SP_LAY_DS_KHOA_2 @ROLE= '" + Program.role + "'";

            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable(exec);

            cbKhoa.DataSource = dt;
            cbKhoa.DisplayMember = "TENKHOA";
            cbKhoa.ValueMember = "MAKHOA";
            cbKhoa.SelectedIndex = 0;
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

        private void btnLoadDS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnDK.Enabled = btnHuy.Enabled = btnReload.Enabled = true;
            loadDS();
        }

        private void loadDS()
        {
            String exec = "EXEC SP_DS_DANGKY_LTC @NIENKHOA = '" + cbNienkhoa.SelectedValue.ToString() +
                "', @HOCKY = " + cbHocky.SelectedItem.ToString() +
                ", @MASV = '" + Program.username + "'";

            tbDS.DataSource = Program.ExecSqlDataTable(exec);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadDS();
        }

        private void capnhatDK(String MaLTC, String isHuy)
            // huy la kieu string 'true'/ 'false'
        {
            try
            {
                if (Program.ExecSqlNonQuery("SP_CAPNHAT_DANGKY_LTC", CommandType.StoredProcedure, new[] {
                    new SqlParameter("@MASV", SqlDbType.NChar){Value=Program.username},
                    new SqlParameter("@MALTC", SqlDbType.Int){Value=MaLTC},
                    new SqlParameter("@HUY", SqlDbType.Bit){Value=isHuy}
                    }) == 1)
                {
                    MessageBox.Show("Thay đổi đăng ký thành công!", "Thông báo", MessageBoxButtons.OK);
                }

                loadDS();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tbDS.Rows.Count - 1 > 0 && tbDS.Rows.Count - 1 > tbDS.CurrentCell.RowIndex)
            {
                int index = tbDS.CurrentCell.RowIndex;
                capnhatDK(tbDS.Rows[index].Cells[0].Value.ToString(), "false");
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tbDS.Rows.Count - 1 > 0 && tbDS.Rows.Count - 1 > tbDS.CurrentCell.RowIndex)
            {
                int index = tbDS.CurrentCell.RowIndex;
                capnhatDK(tbDS.Rows[index].Cells[0].Value.ToString(), "true");
            }
        }
    }
}