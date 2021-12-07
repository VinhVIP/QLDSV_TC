using DevExpress.XtraBars;
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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin của user ở góc dưới màn hình
            txtLoginInfo.Caption = Program.fullName + " - " + Program.username + " - " + Program.role;

            Program.loginDN = Program.mLogin;
            Program.passDN = Program.pass;

            if (Program.role.Equals("PGV") || Program.role.Equals("KHOA"))
            {
                btnDangKyLTC.Enabled = false;
                btnDongHP.Enabled = false;
                btnBCDongHP.Enabled = false;
            }else if (Program.role.Equals("SV"))
            {
                btnNhapLop.Enabled = btnNhapMH.Enabled = btnNhapLTC.Enabled = btnNhapDiem.Enabled = btnDongHP.Enabled = false;
                btnBCDSLop.Enabled = btnBCDKLTC.Enabled = btnBCDiemMH.Enabled = btnBCPhieuDiem.Enabled = btnBCDiemTongKet.Enabled = btnBCDongHP.Enabled = false;
                btnTaoTK.Enabled = false;
            }else if (Program.role.Equals("PKT"))
            {
                btnNhapLop.Enabled = btnNhapMH.Enabled = btnNhapLTC.Enabled = btnDangKyLTC.Enabled = btnNhapDiem.Enabled = false;
                btnBCDSLop.Enabled = btnBCDKLTC.Enabled = btnBCDiemMH.Enabled = btnBCPhieuDiem.Enabled = btnBCDiemTongKet.Enabled = false;
            }
        }

        private Form checkExists(Type frmType)
        {
            foreach(Form f in this.MdiChildren)
            {
                if (f.GetType() == frmType) return f;
            }
            return null;
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmLogin().Show();
            this.Close();
        }

        private void btnNhapLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(frmLop));
            if (frm != null) frm.Activate();
            else
            {
                frmLop f = new frmLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNhapMH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(frmMH));
            if (frm != null) frm.Activate();
            else
            {
                frmMH f = new frmMH();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btnTaoTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.role.Equals("SV")) return;

            Form frm = this.checkExists(typeof(frmTaoTK));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoTK f = new frmTaoTK();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btnNhapDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(frmDiem));
            if (frm != null) frm.Activate();
            else
            {
                frmDiem f = new frmDiem();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBCDiemMH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(Xfrm_BangDiemMonHoc1LTC));
            if (frm != null) frm.Activate();
            else
            {
                Xfrm_BangDiemMonHoc1LTC f = new Xfrm_BangDiemMonHoc1LTC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBCPhieuDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(Xfrm_PhieuDiemSV));
            if (frm != null) frm.Activate();
            else
            {
                Xfrm_PhieuDiemSV f = new Xfrm_PhieuDiemSV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBCDiemTongKet_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(Xfrm_BangDiemTongKetLop));
            if (frm != null) frm.Activate();
            else
            {
                Xfrm_BangDiemTongKetLop f = new Xfrm_BangDiemTongKetLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDongHP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(frmHocPhi));
            if (frm != null) frm.Activate();
            else
            {
                frmHocPhi f = new frmHocPhi();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBCDongHP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(Xfrm_HocPhiTheoLop));
            if (frm != null) frm.Activate();
            else
            {
                Xfrm_HocPhiTheoLop f = new Xfrm_HocPhiTheoLop();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNhapLTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.role.Equals("SV")) return;

            Form frm = this.checkExists(typeof(frmLTC));
            if (frm != null) frm.Activate();
            else
            {
                frmLTC f = new frmLTC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangKyLTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.role.Equals("SV"))
            {
                Form frm = this.checkExists(typeof(frmDKLTC));

                if (frm != null) frm.Activate();
                else
                {
                    frmDKLTC f = new frmDKLTC();
                    f.MdiParent = this;
                    f.Show();
                }
            }
            else
                return;
        }

        private void btnBCDSLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.role.Equals("SV")) return;

            Form frm = this.checkExists(typeof(Xfrm_DS_LTC));
            if (frm != null) frm.Activate();
            else
            {
                Xfrm_DS_LTC f = new Xfrm_DS_LTC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBCDKLTC_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.role.Equals("SV")) return;

            Form frm = this.checkExists(typeof(Xfrm_DSSV_1LTC));
            if (frm != null) frm.Activate();
            else
            {
                Xfrm_DSSV_1LTC f = new Xfrm_DSSV_1LTC();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}