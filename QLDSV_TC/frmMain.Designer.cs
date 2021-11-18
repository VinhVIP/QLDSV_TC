
namespace QLDSV_TC
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNhapLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhapLTC = new DevExpress.XtraBars.BarButtonItem();
            this.txtLoginInfo = new DevExpress.XtraBars.BarStaticItem();
            this.btnDongHP = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhapMH = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangKyLTC = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhapDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTK = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnBCDSLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnBCDKLTC = new DevExpress.XtraBars.BarButtonItem();
            this.btnBCDiemMH = new DevExpress.XtraBars.BarButtonItem();
            this.btnBCPhieuDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnBCDiemTongKet = new DevExpress.XtraBars.BarButtonItem();
            this.btnBCDongHP = new DevExpress.XtraBars.BarButtonItem();
            this.btnSinhVien = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnNhapLop,
            this.btnNhapLTC,
            this.txtLoginInfo,
            this.btnDongHP,
            this.btnNhapMH,
            this.btnDangKyLTC,
            this.btnNhapDiem,
            this.btnTaoTK,
            this.btnLogout,
            this.btnBCDSLop,
            this.btnBCDKLTC,
            this.btnBCDiemMH,
            this.btnBCPhieuDiem,
            this.btnBCDiemTongKet,
            this.btnBCDongHP,
            this.btnSinhVien});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 22;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbon.Size = new System.Drawing.Size(1311, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnNhapLop
            // 
            this.btnNhapLop.Caption = "Nhập Lớp - Sinh Viên";
            this.btnNhapLop.Id = 1;
            this.btnNhapLop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapLop.ImageOptions.Image")));
            this.btnNhapLop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhapLop.ImageOptions.LargeImage")));
            this.btnNhapLop.ItemAppearance.Normal.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNhapLop.ItemAppearance.Normal.Options.UseBackColor = true;
            this.btnNhapLop.LargeWidth = 70;
            this.btnNhapLop.Name = "btnNhapLop";
            this.btnNhapLop.RememberLastCommand = true;
            this.btnNhapLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhapLop_ItemClick);
            // 
            // btnNhapLTC
            // 
            this.btnNhapLTC.Caption = "Mở Lớp tín chỉ";
            this.btnNhapLTC.Id = 2;
            this.btnNhapLTC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapLTC.ImageOptions.Image")));
            this.btnNhapLTC.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhapLTC.ImageOptions.LargeImage")));
            this.btnNhapLTC.LargeWidth = 70;
            this.btnNhapLTC.Name = "btnNhapLTC";
            // 
            // txtLoginInfo
            // 
            this.txtLoginInfo.Caption = "Trần Quang Vinh - N18DCCN246";
            this.txtLoginInfo.Id = 3;
            this.txtLoginInfo.Name = "txtLoginInfo";
            // 
            // btnDongHP
            // 
            this.btnDongHP.Caption = "Đóng Học phí";
            this.btnDongHP.Id = 4;
            this.btnDongHP.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDongHP.ImageOptions.Image")));
            this.btnDongHP.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDongHP.ImageOptions.LargeImage")));
            this.btnDongHP.ItemAppearance.Normal.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDongHP.ItemAppearance.Normal.Options.UseBackColor = true;
            this.btnDongHP.LargeWidth = 70;
            this.btnDongHP.Name = "btnDongHP";
            this.btnDongHP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDongHP_ItemClick);
            // 
            // btnNhapMH
            // 
            this.btnNhapMH.Caption = "Nhập Môn học";
            this.btnNhapMH.Id = 7;
            this.btnNhapMH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapMH.ImageOptions.Image")));
            this.btnNhapMH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhapMH.ImageOptions.LargeImage")));
            this.btnNhapMH.LargeWidth = 70;
            this.btnNhapMH.Name = "btnNhapMH";
            this.btnNhapMH.RememberLastCommand = true;
            this.btnNhapMH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhapMH_ItemClick);
            // 
            // btnDangKyLTC
            // 
            this.btnDangKyLTC.Caption = "Đăng ký Lớp tín chỉ";
            this.btnDangKyLTC.Id = 8;
            this.btnDangKyLTC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangKyLTC.ImageOptions.Image")));
            this.btnDangKyLTC.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangKyLTC.ImageOptions.LargeImage")));
            this.btnDangKyLTC.LargeWidth = 70;
            this.btnDangKyLTC.Name = "btnDangKyLTC";
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.Caption = "Nhập Điểm";
            this.btnNhapDiem.Id = 9;
            this.btnNhapDiem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapDiem.ImageOptions.Image")));
            this.btnNhapDiem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhapDiem.ImageOptions.LargeImage")));
            this.btnNhapDiem.LargeWidth = 70;
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhapDiem_ItemClick);
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.Caption = "Tạo Tài khoản";
            this.btnTaoTK.Id = 10;
            this.btnTaoTK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoTK.ImageOptions.Image")));
            this.btnTaoTK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaoTK.ImageOptions.LargeImage")));
            this.btnTaoTK.LargeWidth = 70;
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTK_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Id = 11;
            this.btnLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.Image")));
            this.btnLogout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.LargeImage")));
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnBCDSLop
            // 
            this.btnBCDSLop.Caption = "Danh sách Lớp";
            this.btnBCDSLop.Id = 12;
            this.btnBCDSLop.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBCDSLop.ImageOptions.Image")));
            this.btnBCDSLop.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBCDSLop.ImageOptions.LargeImage")));
            this.btnBCDSLop.LargeWidth = 70;
            this.btnBCDSLop.Name = "btnBCDSLop";
            // 
            // btnBCDKLTC
            // 
            this.btnBCDKLTC.Caption = "Danh sách Sinh viên đăng ký";
            this.btnBCDKLTC.Id = 13;
            this.btnBCDKLTC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBCDKLTC.ImageOptions.Image")));
            this.btnBCDKLTC.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBCDKLTC.ImageOptions.LargeImage")));
            this.btnBCDKLTC.LargeWidth = 80;
            this.btnBCDKLTC.Name = "btnBCDKLTC";
            // 
            // btnBCDiemMH
            // 
            this.btnBCDiemMH.Caption = "Bảng điểm Môn học 1 LTC";
            this.btnBCDiemMH.Id = 14;
            this.btnBCDiemMH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBCDiemMH.ImageOptions.Image")));
            this.btnBCDiemMH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBCDiemMH.ImageOptions.LargeImage")));
            this.btnBCDiemMH.LargeWidth = 81;
            this.btnBCDiemMH.Name = "btnBCDiemMH";
            this.btnBCDiemMH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBCDiemMH_ItemClick);
            // 
            // btnBCPhieuDiem
            // 
            this.btnBCPhieuDiem.Caption = "Phiếu điểm";
            this.btnBCPhieuDiem.Id = 15;
            this.btnBCPhieuDiem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBCPhieuDiem.ImageOptions.LargeImage")));
            this.btnBCPhieuDiem.LargeWidth = 70;
            this.btnBCPhieuDiem.Name = "btnBCPhieuDiem";
            this.btnBCPhieuDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBCPhieuDiem_ItemClick);
            // 
            // btnBCDiemTongKet
            // 
            this.btnBCDiemTongKet.Caption = "Bảng điểm Tổng kết";
            this.btnBCDiemTongKet.Id = 16;
            this.btnBCDiemTongKet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBCDiemTongKet.ImageOptions.Image")));
            this.btnBCDiemTongKet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBCDiemTongKet.ImageOptions.LargeImage")));
            this.btnBCDiemTongKet.LargeWidth = 70;
            this.btnBCDiemTongKet.Name = "btnBCDiemTongKet";
            this.btnBCDiemTongKet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBCDiemTongKet_ItemClick);
            // 
            // btnBCDongHP
            // 
            this.btnBCDongHP.Caption = "Danh sách Đóng học phí";
            this.btnBCDongHP.Id = 17;
            this.btnBCDongHP.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBCDongHP.ImageOptions.Image")));
            this.btnBCDongHP.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBCDongHP.ImageOptions.LargeImage")));
            this.btnBCDongHP.LargeWidth = 70;
            this.btnBCDongHP.Name = "btnBCDongHP";
            this.btnBCDongHP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBCDongHP_ItemClick);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Caption = "Nhập SV";
            this.btnSinhVien.Id = 21;
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSinhVien_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Nhập liệu";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhapLop);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhapMH);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnNhapLTC);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDangKyLTC);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnNhapDiem);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Lớp tín chỉ";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnDongHP);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Báo cáo";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBCDSLop);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBCDKLTC);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Lớp Tín chỉ";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnBCDiemMH);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnBCPhieuDiem);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnBCDiemTongKet);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Điểm";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnBCDongHP);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Học phí";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup6});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Quản trị";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnTaoTK);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnLogout);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.txtLoginInfo);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 836);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1311, 24);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 814);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1311, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 860);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnNhapLop;
        private DevExpress.XtraBars.BarButtonItem btnNhapLTC;
        private DevExpress.XtraBars.BarStaticItem txtLoginInfo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnDongHP;
        private DevExpress.XtraBars.BarButtonItem btnNhapMH;
        private DevExpress.XtraBars.BarButtonItem btnDangKyLTC;
        private DevExpress.XtraBars.BarButtonItem btnNhapDiem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnTaoTK;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnBCDSLop;
        private DevExpress.XtraBars.BarButtonItem btnBCDKLTC;
        private DevExpress.XtraBars.BarButtonItem btnBCDiemMH;
        private DevExpress.XtraBars.BarButtonItem btnBCPhieuDiem;
        private DevExpress.XtraBars.BarButtonItem btnBCDiemTongKet;
        private DevExpress.XtraBars.BarButtonItem btnBCDongHP;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraBars.BarButtonItem btnSinhVien;
    }
}