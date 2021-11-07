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
        private int lastPosition, lopSize;
        private String maKhoa;
        private String lastAction = "";

        public frmLop()
        {
            InitializeComponent();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLOP.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS_LOP1);

        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            DS_LOP1.EnforceConstraints = false;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTableAdapter.Fill(this.DS_LOP1.LOP);

            this.SINHVIENTableAdapter.Fill(this.DS_LOP1.SINHVIEN);

            comboKhoa.DataSource = Program.bindingSourcePM;
            comboKhoa.DisplayMember = "TENPM";
            comboKhoa.ValueMember = "TENSERVER";

            comboKhoa.SelectedIndex = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";

            maKhoa = comboKhoa.Text;

            btnUndo.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = true;
            panel.Enabled = false;
        }

        private void comboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.server = comboKhoa.SelectedValue.ToString();

            if (comboKhoa.SelectedIndex != Program.mKhoa)
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
                LOPTableAdapter.Connection.ConnectionString = Program.connString;
                LOPTableAdapter.Fill(DS_LOP1.LOP);

                SINHVIENTableAdapter.Connection.ConnectionString = Program.connString;
                SINHVIENTableAdapter.Fill(DS_LOP1.SINHVIEN);

                maKhoa = comboKhoa.Text;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lastPosition = bdsLOP.Position;

            bdsLOP.AddNew();
            
            gcLop.Focus();
            txtMaKhoa.Text = maKhoa;

            gcLop.Enabled = false;
            panel.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;

            txtMaLop.Focus();

            lastAction = "add";
            lastPosition = bdsLOP.Position;
            lopSize = bdsLOP.Count;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsSV.Count > 0)
            {
                MessageBox.Show("Lớp đã có sinh viên nên không thể xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn thực sự muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String maLop = "";
                try
                {
                    maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
                    bdsLOP.RemoveCurrent();
                    LOPTableAdapter.Connection.ConnectionString = Program.connString;
                    LOPTableAdapter.Update(DS_LOP1.LOP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    LOPTableAdapter.Fill(DS_LOP1.LOP);
                    bdsLOP.Position = bdsLOP.Find("MALOP", maLop);
                }

            }

            if (bdsLOP.Count == 0) btnXoa.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LOPTableAdapter.Fill(DS_LOP1.LOP);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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

            // Kiêm tra thêm / hiệu chỉnh
            if (lastAction == "add")
            {
                if (isMaLopExists(txtMaLop.Text.Trim())) return;

                if (Program.ConnectPublisher() == 1)
                {
                    if (isMaLopExists(txtMaLop.Text.Trim())) return;
                }
                Program.Connect();
            } else if (lastAction == "edit")
            {

            }
            

            try
            {
                bdsLOP.EndEdit();
                bdsLOP.ResetCurrentItem();
                LOPTableAdapter.Connection.ConnectionString = Program.connString;
                LOPTableAdapter.Update(DS_LOP1.LOP);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi lớp: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);

            btnThem.Enabled = btnReload.Enabled = btnXoa.Enabled = btnHieuChinh.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled =  false;

            gcLop.Enabled = true;
            panel.Enabled = false;
        }

        private void comboKhoa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.server = comboKhoa.SelectedValue.ToString();

            if (comboKhoa.SelectedIndex != Program.mKhoa)
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
                LOPTableAdapter.Connection.ConnectionString = Program.connString;
                LOPTableAdapter.Fill(DS_LOP1.LOP);

                SINHVIENTableAdapter.Connection.ConnectionString = Program.connString;
                SINHVIENTableAdapter.Fill(DS_LOP1.SINHVIEN);

                maKhoa = comboKhoa.Text;
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.CancelEdit();

            if (lastAction == "add")
            {
                Console.WriteLine("delete line: "+ (lopSize - 1));
                bdsLOP.RemoveAt(bdsLOP.Count-1);
                lastAction = "undo";
            }
            if (lastAction == "edit") bdsLOP.Position = lastPosition;

            gcLop.Enabled = true;
            panel.Enabled = false;

            btnUndo.Enabled = false;
            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = true;
        }

        private void gcLop_Click(object sender, EventArgs e)
        {
            /*btnHieuChinh.Enabled = btnUndo.Enabled = btnXoa.Enabled = true;
            btnThem.Enabled = btnGhi.Enabled = false;*/
        }

        private void btnHieuChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lastPosition = bdsLOP.Position;
            lastAction = "edit";

            gcLop.Enabled = false;
            panel.Enabled = true;

            btnThem.Enabled = btnHieuChinh.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnUndo.Enabled = true;
        }

        private bool isMaLopExists(String maLop)
        {
            Program.ExecSqlDataReader("SP_TimLop", CommandType.StoredProcedure, new[] {
                new SqlParameter("@malop", SqlDbType.NVarChar){Value=maLop}
            });

            if (Program.reader.Read())
            {
                MessageBox.Show("Mã lớp đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                txtMaLop.Focus();
                Program.reader.Close();
                return true;
            }

            Program.reader.Close();
            return false;
        }
    }
}