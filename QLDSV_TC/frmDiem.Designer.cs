
namespace QLDSV_TC
{
    partial class frmDiem
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGhiDiem = new System.Windows.Forms.Button();
            this.btnNhapDiem = new System.Windows.Forms.Button();
            this.btnTaiLTC = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboHK = new System.Windows.Forms.ComboBox();
            this.comboNK = new System.Windows.Forms.ComboBox();
            this.comboKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gcLTC = new DevExpress.XtraGrid.GridControl();
            this.bdsDSLTC = new System.Windows.Forms.BindingSource(this.components);
            this.DS_LTC = new QLDSV_TC.DS_LTC();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMALTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SP_LAY_DS_LTCTableAdapter = new QLDSV_TC.DS_LTCTableAdapters.SP_LAY_DS_LTCTableAdapter();
            this.tableAdapterManager = new QLDSV_TC.DS_LTCTableAdapters.TableAdapterManager();
            this.gcDiem = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSLTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_LTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGhiDiem);
            this.panelControl1.Controls.Add(this.btnNhapDiem);
            this.panelControl1.Controls.Add(this.btnTaiLTC);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.comboHK);
            this.panelControl1.Controls.Add(this.comboNK);
            this.panelControl1.Controls.Add(this.comboKhoa);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1256, 76);
            this.panelControl1.TabIndex = 0;
            // 
            // btnGhiDiem
            // 
            this.btnGhiDiem.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnGhiDiem.Location = new System.Drawing.Point(1121, 17);
            this.btnGhiDiem.Name = "btnGhiDiem";
            this.btnGhiDiem.Size = new System.Drawing.Size(88, 36);
            this.btnGhiDiem.TabIndex = 8;
            this.btnGhiDiem.Text = "Ghi điểm";
            this.btnGhiDiem.UseVisualStyleBackColor = true;
            this.btnGhiDiem.Click += new System.EventHandler(this.btnGhiDiem_Click);
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnNhapDiem.Location = new System.Drawing.Point(1009, 17);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Size = new System.Drawing.Size(88, 36);
            this.btnNhapDiem.TabIndex = 7;
            this.btnNhapDiem.Text = "Nhập điểm";
            this.btnNhapDiem.UseVisualStyleBackColor = true;
            this.btnNhapDiem.Click += new System.EventHandler(this.btnNhapDiem_Click);
            // 
            // btnTaiLTC
            // 
            this.btnTaiLTC.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnTaiLTC.ImageKey = "(none)";
            this.btnTaiLTC.Location = new System.Drawing.Point(866, 17);
            this.btnTaiLTC.Name = "btnTaiLTC";
            this.btnTaiLTC.Size = new System.Drawing.Size(114, 36);
            this.btnTaiLTC.TabIndex = 6;
            this.btnTaiLTC.Text = "Tải lớp tín chỉ";
            this.btnTaiLTC.UseVisualStyleBackColor = true;
            this.btnTaiLTC.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(613, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Học kỳ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(327, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Niên khóa:";
            // 
            // comboHK
            // 
            this.comboHK.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboHK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHK.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboHK.FormattingEnabled = true;
            this.comboHK.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboHK.Location = new System.Drawing.Point(679, 24);
            this.comboHK.Name = "comboHK";
            this.comboHK.Size = new System.Drawing.Size(121, 24);
            this.comboHK.TabIndex = 3;
            // 
            // comboNK
            // 
            this.comboNK.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboNK.FormattingEnabled = true;
            this.comboNK.Items.AddRange(new object[] {
            "2018-2019",
            "2019-2020",
            "2020-2021",
            "2021-2022"});
            this.comboNK.Location = new System.Drawing.Point(406, 24);
            this.comboNK.MaxLength = 9;
            this.comboNK.Name = "comboNK";
            this.comboNK.Size = new System.Drawing.Size(121, 24);
            this.comboNK.TabIndex = 2;
            // 
            // comboKhoa
            // 
            this.comboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKhoa.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboKhoa.FormattingEnabled = true;
            this.comboKhoa.Location = new System.Drawing.Point(111, 24);
            this.comboKhoa.Name = "comboKhoa";
            this.comboKhoa.Size = new System.Drawing.Size(161, 24);
            this.comboKhoa.TabIndex = 1;
            this.comboKhoa.SelectedIndexChanged += new System.EventHandler(this.comboKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(47, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoa:";
            // 
            // gcLTC
            // 
            this.gcLTC.DataSource = this.bdsDSLTC;
            this.gcLTC.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcLTC.Location = new System.Drawing.Point(0, 76);
            this.gcLTC.MainView = this.gridView1;
            this.gcLTC.Name = "gcLTC";
            this.gcLTC.Size = new System.Drawing.Size(680, 661);
            this.gcLTC.TabIndex = 1;
            this.gcLTC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bdsDSLTC
            // 
            this.bdsDSLTC.DataMember = "SP_LAY_DS_LTC";
            this.bdsDSLTC.DataSource = this.DS_LTC;
            // 
            // DS_LTC
            // 
            this.DS_LTC.DataSetName = "DS_LTC";
            this.DS_LTC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMALTC,
            this.colTENMH,
            this.colNHOM,
            this.colHOTEN});
            this.gridView1.GridControl = this.gcLTC;
            this.gridView1.Name = "gridView1";
            // 
            // colMALTC
            // 
            this.colMALTC.FieldName = "MALTC";
            this.colMALTC.Name = "colMALTC";
            this.colMALTC.Visible = true;
            this.colMALTC.VisibleIndex = 0;
            // 
            // colTENMH
            // 
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 1;
            // 
            // colNHOM
            // 
            this.colNHOM.FieldName = "NHOM";
            this.colNHOM.Name = "colNHOM";
            this.colNHOM.Visible = true;
            this.colNHOM.VisibleIndex = 2;
            // 
            // colHOTEN
            // 
            this.colHOTEN.FieldName = "HOTEN";
            this.colHOTEN.Name = "colHOTEN";
            this.colHOTEN.Visible = true;
            this.colHOTEN.VisibleIndex = 3;
            // 
            // SP_LAY_DS_LTCTableAdapter
            // 
            this.SP_LAY_DS_LTCTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = QLDSV_TC.DS_LTCTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gcDiem
            // 
            this.gcDiem.AllowUserToAddRows = false;
            this.gcDiem.AllowUserToDeleteRows = false;
            this.gcDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gcDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDiem.Location = new System.Drawing.Point(680, 76);
            this.gcDiem.Name = "gcDiem";
            this.gcDiem.Size = new System.Drawing.Size(576, 661);
            this.gcDiem.TabIndex = 2;
            this.gcDiem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gcDiem_CellEndEdit);
            this.gcDiem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gcDiem_KeyUp);
            // 
            // frmDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 737);
            this.Controls.Add(this.gcDiem);
            this.Controls.Add(this.gcLTC);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmDiem";
            this.Text = "frmDiem";
            this.Load += new System.EventHandler(this.frmDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSLTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_LTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGhiDiem;
        private System.Windows.Forms.Button btnNhapDiem;
        private System.Windows.Forms.Button btnTaiLTC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboHK;
        private System.Windows.Forms.ComboBox comboNK;
        private System.Windows.Forms.ComboBox comboKhoa;
        private DevExpress.XtraGrid.GridControl gcLTC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DS_LTC DS_LTC;
        private System.Windows.Forms.BindingSource bdsDSLTC;
        private DS_LTCTableAdapters.SP_LAY_DS_LTCTableAdapter SP_LAY_DS_LTCTableAdapter;
        private DS_LTCTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.Columns.GridColumn colMALTC;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colNHOM;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTEN;
        private System.Windows.Forms.DataGridView gcDiem;
    }
}