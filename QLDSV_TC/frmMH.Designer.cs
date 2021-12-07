
namespace QLDSV_TC
{
    partial class frmMH
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
            System.Windows.Forms.Label MAMHLabel;
            System.Windows.Forms.Label TENMHLabel;
            System.Windows.Forms.Label SOTIET_LTLabel;
            System.Windows.Forms.Label SOTIET_THLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMH));
            this.label1 = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_ThemMH = new DevExpress.XtraBars.BarButtonItem();
            this.btn_DelMH = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SaveMH = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Undo = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Reload = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.DS_MH = new QLDSV_TC.DS_MH();
            this.bdsMH = new System.Windows.Forms.BindingSource(this.components);
            this.MONHOCTableAdapter = new QLDSV_TC.DS_MHTableAdapters.MONHOCTableAdapter();
            this.tableAdapterManager = new QLDSV_TC.DS_MHTableAdapters.TableAdapterManager();
            this.LOPTINCHITableAdapter = new QLDSV_TC.DS_MHTableAdapters.LOPTINCHITableAdapter();
            this.gcMONHOC = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTIET_LT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTIET_TH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtSOTIETTH = new DevExpress.XtraEditors.TextEdit();
            this.txtSOTIETLT = new DevExpress.XtraEditors.TextEdit();
            this.txtTENMH = new System.Windows.Forms.TextBox();
            this.txtMAMH = new System.Windows.Forms.TextBox();
            this.bdsLTC = new System.Windows.Forms.BindingSource(this.components);
            MAMHLabel = new System.Windows.Forms.Label();
            TENMHLabel = new System.Windows.Forms.Label();
            SOTIET_LTLabel = new System.Windows.Forms.Label();
            SOTIET_THLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_MH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMONHOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOTIETTH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOTIETLT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLTC)).BeginInit();
            this.SuspendLayout();
            // 
            // MAMHLabel
            // 
            MAMHLabel.AutoSize = true;
            MAMHLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            MAMHLabel.Location = new System.Drawing.Point(50, 115);
            MAMHLabel.Name = "MAMHLabel";
            MAMHLabel.Size = new System.Drawing.Size(49, 16);
            MAMHLabel.TabIndex = 0;
            MAMHLabel.Text = "MAMH:";
            // 
            // TENMHLabel
            // 
            TENMHLabel.AutoSize = true;
            TENMHLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            TENMHLabel.Location = new System.Drawing.Point(50, 153);
            TENMHLabel.Name = "TENMHLabel";
            TENMHLabel.Size = new System.Drawing.Size(54, 16);
            TENMHLabel.TabIndex = 2;
            TENMHLabel.Text = "TENMH:";
            // 
            // SOTIET_LTLabel
            // 
            SOTIET_LTLabel.AutoSize = true;
            SOTIET_LTLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SOTIET_LTLabel.Location = new System.Drawing.Point(50, 198);
            SOTIET_LTLabel.Name = "SOTIET_LTLabel";
            SOTIET_LTLabel.Size = new System.Drawing.Size(75, 16);
            SOTIET_LTLabel.TabIndex = 4;
            SOTIET_LTLabel.Text = "SOTIET LT:";
            // 
            // SOTIET_THLabel
            // 
            SOTIET_THLabel.AutoSize = true;
            SOTIET_THLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            SOTIET_THLabel.Location = new System.Drawing.Point(50, 241);
            SOTIET_THLabel.Name = "SOTIET_THLabel";
            SOTIET_THLabel.Size = new System.Drawing.Size(77, 16);
            SOTIET_THLabel.TabIndex = 6;
            SOTIET_THLabel.Text = "SOTIET TH:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_ThemMH,
            this.barButtonItem1,
            this.btn_DelMH,
            this.btn_SaveMH,
            this.btn_Undo,
            this.btn_Reload,
            this.btn_Exit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_ThemMH, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_DelMH, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_SaveMH, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Undo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_Reload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btn_ThemMH
            // 
            this.btn_ThemMH.Caption = "THÊM";
            this.btn_ThemMH.Id = 0;
            this.btn_ThemMH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ThemMH.ImageOptions.Image")));
            this.btn_ThemMH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_ThemMH.ImageOptions.LargeImage")));
            this.btn_ThemMH.Name = "btn_ThemMH";
            this.btn_ThemMH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ThemMH_ItemClick);
            // 
            // btn_DelMH
            // 
            this.btn_DelMH.Caption = "Xóa";
            this.btn_DelMH.Id = 2;
            this.btn_DelMH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_DelMH.ImageOptions.Image")));
            this.btn_DelMH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_DelMH.ImageOptions.LargeImage")));
            this.btn_DelMH.Name = "btn_DelMH";
            this.btn_DelMH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_DelMH_ItemClick);
            // 
            // btn_SaveMH
            // 
            this.btn_SaveMH.Caption = "Ghi";
            this.btn_SaveMH.Id = 3;
            this.btn_SaveMH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_SaveMH.ImageOptions.Image")));
            this.btn_SaveMH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_SaveMH.ImageOptions.LargeImage")));
            this.btn_SaveMH.Name = "btn_SaveMH";
            this.btn_SaveMH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SaveMH_ItemClick);
            // 
            // btn_Undo
            // 
            this.btn_Undo.Caption = "Phục Hồi";
            this.btn_Undo.Id = 4;
            this.btn_Undo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Undo.ImageOptions.Image")));
            this.btn_Undo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Undo.ImageOptions.LargeImage")));
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Undo_ItemClick);
            // 
            // btn_Reload
            // 
            this.btn_Reload.Caption = "Reload";
            this.btn_Reload.Id = 5;
            this.btn_Reload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Reload.ImageOptions.Image")));
            this.btn_Reload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Reload.ImageOptions.LargeImage")));
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Reload_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1384, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 708);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1384, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 684);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1384, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 684);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Hiệu Chỉnh";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btn_Exit
            // 
            this.btn_Exit.Caption = "Thoát";
            this.btn_Exit.Id = 6;
            this.btn_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.ImageOptions.Image")));
            this.btn_Exit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Exit.ImageOptions.LargeImage")));
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Exit_ItemClick);
            // 
            // DS_MH
            // 
            this.DS_MH.DataSetName = "DS_MH";
            this.DS_MH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsMH
            // 
            this.bdsMH.DataMember = "MONHOC";
            this.bdsMH.DataSource = this.DS_MH;
            // 
            // MONHOCTableAdapter
            // 
            this.MONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.LOPTINCHITableAdapter = this.LOPTINCHITableAdapter;
            this.tableAdapterManager.MONHOCTableAdapter = this.MONHOCTableAdapter;
            this.tableAdapterManager.UpdateOrder = QLDSV_TC.DS_MHTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // LOPTINCHITableAdapter
            // 
            this.LOPTINCHITableAdapter.ClearBeforeFill = true;
            // 
            // gcMONHOC
            // 
            this.gcMONHOC.DataSource = this.bdsMH;
            this.gcMONHOC.Dock = System.Windows.Forms.DockStyle.Right;
            this.gcMONHOC.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gcMONHOC.Location = new System.Drawing.Point(449, 24);
            this.gcMONHOC.MainView = this.gridView1;
            this.gcMONHOC.MenuManager = this.barManager1;
            this.gcMONHOC.Name = "gcMONHOC";
            this.gcMONHOC.Size = new System.Drawing.Size(935, 684);
            this.gcMONHOC.TabIndex = 10;
            this.gcMONHOC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcMONHOC.Click += new System.EventHandler(this.gcMONHOC_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAMH,
            this.colTENMH,
            this.colSOTIET_LT,
            this.colSOTIET_TH});
            this.gridView1.GridControl = this.gcMONHOC;
            this.gridView1.Name = "gridView1";
            // 
            // colMAMH
            // 
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 0;
            // 
            // colTENMH
            // 
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 1;
            // 
            // colSOTIET_LT
            // 
            this.colSOTIET_LT.FieldName = "SOTIET_LT";
            this.colSOTIET_LT.Name = "colSOTIET_LT";
            this.colSOTIET_LT.Visible = true;
            this.colSOTIET_LT.VisibleIndex = 2;
            // 
            // colSOTIET_TH
            // 
            this.colSOTIET_TH.FieldName = "SOTIET_TH";
            this.colSOTIET_TH.Name = "colSOTIET_TH";
            this.colSOTIET_TH.Visible = true;
            this.colSOTIET_TH.VisibleIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(SOTIET_THLabel);
            this.panelControl1.Controls.Add(this.txtSOTIETTH);
            this.panelControl1.Controls.Add(SOTIET_LTLabel);
            this.panelControl1.Controls.Add(this.txtSOTIETLT);
            this.panelControl1.Controls.Add(TENMHLabel);
            this.panelControl1.Controls.Add(this.txtTENMH);
            this.panelControl1.Controls.Add(MAMHLabel);
            this.panelControl1.Controls.Add(this.txtMAMH);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(449, 684);
            this.panelControl1.TabIndex = 11;
            // 
            // txtSOTIETTH
            // 
            this.txtSOTIETTH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsMH, "SOTIET_TH", true));
            this.txtSOTIETTH.Location = new System.Drawing.Point(139, 238);
            this.txtSOTIETTH.MenuManager = this.barManager1;
            this.txtSOTIETTH.Name = "txtSOTIETTH";
            this.txtSOTIETTH.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSOTIETTH.Properties.Appearance.Options.UseFont = true;
            this.txtSOTIETTH.Properties.DisplayFormat.FormatString = "n0";
            this.txtSOTIETTH.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSOTIETTH.Size = new System.Drawing.Size(94, 22);
            this.txtSOTIETTH.TabIndex = 7;
            // 
            // txtSOTIETLT
            // 
            this.txtSOTIETLT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsMH, "SOTIET_LT", true));
            this.txtSOTIETLT.Location = new System.Drawing.Point(139, 195);
            this.txtSOTIETLT.MenuManager = this.barManager1;
            this.txtSOTIETLT.Name = "txtSOTIETLT";
            this.txtSOTIETLT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSOTIETLT.Properties.Appearance.Options.UseFont = true;
            this.txtSOTIETLT.Size = new System.Drawing.Size(94, 22);
            this.txtSOTIETLT.TabIndex = 5;
            // 
            // txtTENMH
            // 
            this.txtTENMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMH, "TENMH", true));
            this.txtTENMH.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTENMH.Location = new System.Drawing.Point(139, 150);
            this.txtTENMH.Name = "txtTENMH";
            this.txtTENMH.Size = new System.Drawing.Size(162, 23);
            this.txtTENMH.TabIndex = 3;
            // 
            // txtMAMH
            // 
            this.txtMAMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMH, "MAMH", true));
            this.txtMAMH.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAMH.Location = new System.Drawing.Point(139, 112);
            this.txtMAMH.Name = "txtMAMH";
            this.txtMAMH.Size = new System.Drawing.Size(162, 23);
            this.txtMAMH.TabIndex = 1;
            // 
            // bdsLTC
            // 
            this.bdsLTC.DataMember = "FK_LOPTINCHI_MONHOC";
            this.bdsLTC.DataSource = this.bdsMH;
            // 
            // frmMH
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 728);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcMONHOC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InactiveGlowColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMH";
            this.Text = "frmMH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_MH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMONHOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOTIETTH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOTIETLT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLTC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btn_ThemMH;
        private DevExpress.XtraBars.BarButtonItem btn_DelMH;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btn_SaveMH;
        private DevExpress.XtraBars.BarButtonItem btn_Undo;
        private DevExpress.XtraBars.BarButtonItem btn_Reload;
        private DevExpress.XtraBars.BarButtonItem btn_Exit;
        private System.Windows.Forms.BindingSource bdsMH;
        private DS_MH DS_MH;
        private DS_MHTableAdapters.MONHOCTableAdapter MONHOCTableAdapter;
        private DS_MHTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcMONHOC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtSOTIETTH;
        private DevExpress.XtraEditors.TextEdit txtSOTIETLT;
        private System.Windows.Forms.TextBox txtTENMH;
        private System.Windows.Forms.TextBox txtMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTIET_LT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTIET_TH;
        private DS_MHTableAdapters.LOPTINCHITableAdapter LOPTINCHITableAdapter;
        private System.Windows.Forms.BindingSource bdsLTC;
    }
}