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

namespace QLDSV_TC
{
    public partial class frmNhapLop : DevExpress.XtraEditors.XtraForm
    {

        private int lastPosition;
        private String maKhoa;

        public frmNhapLop()
        {
            InitializeComponent();
        }


        private void frmNhapLop_Load(object sender, EventArgs e)
        {
            DS_LOP.EnforceConstraints = false;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTableAdapter.Fill(this.DS_LOP.LOP);

            this.SINHVIENTableAdapter.Fill(this.DS_LOP.SINHVIEN);

            comboKhoa.DataSource = Program.bindingSourcePM;
            comboKhoa.DisplayMember = "TENPM";
            comboKhoa.ValueMember = "TENSERVER";

            comboKhoa.SelectedIndex = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";

            maKhoa = comboKhoa.Text;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lastPosition = bdsLOP.Position;
            groupBox1.Enabled = true;

            bdsLOP.AddNew();
            txtMaKhoa.Text = maKhoa;

            gcLop.Enabled = false;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.CancelEdit();

            gcLop.Enabled = true;
            groupBox1.Enabled = false;

            btnUndo.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LOPTableAdapter.Fill(DS_LOP.LOP);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsSV.Count > 0)
            {
                MessageBox.Show("Lớp đã có sinh viên nên không thể xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if(MessageBox.Show("Bạn thực sự muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String maLop = "";
                try
                {
                    maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
                    bdsLOP.RemoveCurrent();
                    LOPTableAdapter.Connection.ConnectionString = Program.connString;
                    LOPTableAdapter.Update(DS_LOP.LOP);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: "+ex.Message, "Thông báo", MessageBoxButtons.OK);
                    LOPTableAdapter.Fill(DS_LOP.LOP);
                    bdsLOP.Position = bdsLOP.Find("MALOP", maLop);
                }
                
            }

            if (bdsLOP.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra các ràng buộc
            if(txtMaLop.Text.Trim() == "")
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

            try
            {
                bdsLOP.EndEdit();
                bdsLOP.ResetCurrentItem();
                LOPTableAdapter.Connection.ConnectionString = Program.connString;
                LOPTableAdapter.Update(DS_LOP.LOP);
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi lớp: "+ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);

            gcLop.Enabled = true;
            btnGhi.Enabled = btnUndo.Enabled = false;

            groupBox1.Enabled = false;
        }

        private void comboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.server = comboKhoa.SelectedValue.ToString();

            if(comboKhoa.SelectedIndex != Program.mKhoa)
            {
                Program.mLogin = Program.remoteLogin;
                Program.pass = Program.remotePass;
            }
            else
            {
                Program.mLogin = Program.loginDN;
                Program.pass = Program.passDN;
            }

            if(Program.Connect() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới! ", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                LOPTableAdapter.Connection.ConnectionString = Program.connString;
                LOPTableAdapter.Fill(DS_LOP.LOP);

                SINHVIENTableAdapter.Connection.ConnectionString = Program.connString;
                SINHVIENTableAdapter.Fill(DS_LOP.SINHVIEN);

                maKhoa = comboKhoa.Text;
            }
        }
    }
}