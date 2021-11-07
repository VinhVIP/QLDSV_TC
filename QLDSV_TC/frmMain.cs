﻿using DevExpress.XtraBars;
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
            Form frm = this.checkExists(typeof(frmSV));
            if (frm != null) frm.Activate();
            else
            {
                frmSV f = new frmSV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNhapMH_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnTaoTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.role.Equals("SV")) return;

            Form frm = this.checkExists(typeof(frmTaoTK2));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoTK2 f = new frmTaoTK2();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSinhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}