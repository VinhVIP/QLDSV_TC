
namespace QLDSV_TC
{
    partial class frmHocPhi
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnDongHP = new System.Windows.Forms.Button();
            this.btnThemHP = new System.Windows.Forms.Button();
            this.txtMaLop = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSV = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtMASV = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gcHOCPHI = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNIENKHOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCPHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCPHIDADONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOCPHICANDONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCT_HP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenSV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMASV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHOCPHI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCT_HP)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGhi);
            this.panelControl1.Controls.Add(this.btnDongHP);
            this.panelControl1.Controls.Add(this.btnThemHP);
            this.panelControl1.Controls.Add(this.txtMaLop);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.txtTenSV);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.txtMASV);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1384, 50);
            this.panelControl1.TabIndex = 4;
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhi.Location = new System.Drawing.Point(1184, 12);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(84, 27);
            this.btnGhi.TabIndex = 10;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnDongHP
            // 
            this.btnDongHP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDongHP.Location = new System.Drawing.Point(1025, 12);
            this.btnDongHP.Name = "btnDongHP";
            this.btnDongHP.Size = new System.Drawing.Size(112, 27);
            this.btnDongHP.TabIndex = 9;
            this.btnDongHP.Text = "Đóng học phí";
            this.btnDongHP.UseVisualStyleBackColor = true;
            this.btnDongHP.Click += new System.EventHandler(this.btnDongHP_Click);
            // 
            // btnThemHP
            // 
            this.btnThemHP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHP.Location = new System.Drawing.Point(871, 12);
            this.btnThemHP.Name = "btnThemHP";
            this.btnThemHP.Size = new System.Drawing.Size(122, 27);
            this.btnThemHP.TabIndex = 8;
            this.btnThemHP.Text = "Thêm Học Phí";
            this.btnThemHP.UseVisualStyleBackColor = true;
            this.btnThemHP.Click += new System.EventHandler(this.btnThemHP_Click);
            // 
            // txtMaLop
            // 
            this.txtMaLop.Enabled = false;
            this.txtMaLop.Location = new System.Drawing.Point(536, 13);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLop.Properties.Appearance.Options.UseFont = true;
            this.txtMaLop.Size = new System.Drawing.Size(291, 24);
            this.txtMaLop.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(479, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mã Lớp:";
            // 
            // txtTenSV
            // 
            this.txtTenSV.Enabled = false;
            this.txtTenSV.Location = new System.Drawing.Point(348, 13);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSV.Properties.Appearance.Options.UseFont = true;
            this.txtTenSV.Size = new System.Drawing.Size(125, 24);
            this.txtTenSV.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Họ Tên:";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(210, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tra Cứu";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMASV
            // 
            this.txtMASV.Location = new System.Drawing.Point(93, 13);
            this.txtMASV.Name = "txtMASV";
            this.txtMASV.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMASV.Properties.Appearance.Options.UseFont = true;
            this.txtMASV.Size = new System.Drawing.Size(111, 24);
            this.txtMASV.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã sinh viên:";
            // 
            // gcHOCPHI
            // 
            this.gcHOCPHI.DataMember = null;
            this.gcHOCPHI.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcHOCPHI.Location = new System.Drawing.Point(0, 50);
            this.gcHOCPHI.MainView = this.gridView1;
            this.gcHOCPHI.Name = "gcHOCPHI";
            this.gcHOCPHI.Size = new System.Drawing.Size(886, 706);
            this.gcHOCPHI.TabIndex = 6;
            this.gcHOCPHI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcHOCPHI.Click += new System.EventHandler(this.gcHOCPHI_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNIENKHOA,
            this.colHOCKY,
            this.colHOCPHI,
            this.colHOCPHIDADONG,
            this.colHOCPHICANDONG});
            this.gridView1.GridControl = this.gcHOCPHI;
            this.gridView1.Name = "gridView1";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_Click);
            // 
            // colNIENKHOA
            // 
            this.colNIENKHOA.FieldName = "NIENKHOA";
            this.colNIENKHOA.Name = "colNIENKHOA";
            this.colNIENKHOA.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colNIENKHOA.Visible = true;
            this.colNIENKHOA.VisibleIndex = 0;
            // 
            // colHOCKY
            // 
            this.colHOCKY.DisplayFormat.FormatString = "n0";
            this.colHOCKY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHOCKY.FieldName = "HOCKY";
            this.colHOCKY.Name = "colHOCKY";
            this.colHOCKY.Visible = true;
            this.colHOCKY.VisibleIndex = 1;
            // 
            // colHOCPHI
            // 
            this.colHOCPHI.DisplayFormat.FormatString = "n0";
            this.colHOCPHI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHOCPHI.FieldName = "HOCPHI";
            this.colHOCPHI.Name = "colHOCPHI";
            this.colHOCPHI.Visible = true;
            this.colHOCPHI.VisibleIndex = 2;
            // 
            // colHOCPHIDADONG
            // 
            this.colHOCPHIDADONG.Caption = "HOCPHIDADONG";
            this.colHOCPHIDADONG.DisplayFormat.FormatString = "n0";
            this.colHOCPHIDADONG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHOCPHIDADONG.FieldName = "HOCPHIDADONG";
            this.colHOCPHIDADONG.Name = "colHOCPHIDADONG";
            this.colHOCPHIDADONG.Visible = true;
            this.colHOCPHIDADONG.VisibleIndex = 3;
            // 
            // colHOCPHICANDONG
            // 
            this.colHOCPHICANDONG.Caption = "HOCPHICANDONG";
            this.colHOCPHICANDONG.DisplayFormat.FormatString = "n0";
            this.colHOCPHICANDONG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHOCPHICANDONG.FieldName = "HOCPHICANDONG";
            this.colHOCPHICANDONG.Name = "colHOCPHICANDONG";
            this.colHOCPHICANDONG.Visible = true;
            this.colHOCPHICANDONG.VisibleIndex = 4;
            // 
            // gcCT_HP
            // 
            this.gcCT_HP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gcCT_HP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcCT_HP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCT_HP.Location = new System.Drawing.Point(886, 50);
            this.gcCT_HP.Name = "gcCT_HP";
            this.gcCT_HP.Size = new System.Drawing.Size(498, 706);
            this.gcCT_HP.TabIndex = 7;
            // 
            // frmHocPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 756);
            this.Controls.Add(this.gcCT_HP);
            this.Controls.Add(this.gcHOCPHI);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmHocPhi";
            this.Text = "frmHocPhi";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaLop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenSV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMASV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHOCPHI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCT_HP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtMASV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private DevExpress.XtraEditors.TextEdit txtMaLop;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtTenSV;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnDongHP;
        private System.Windows.Forms.Button btnThemHP;
        private DevExpress.XtraGrid.GridControl gcHOCPHI;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNIENKHOA;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCKY;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCPHI;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCPHIDADONG;
        private DevExpress.XtraGrid.Columns.GridColumn colHOCPHICANDONG;
        private System.Windows.Forms.DataGridView gcCT_HP;
    }
}