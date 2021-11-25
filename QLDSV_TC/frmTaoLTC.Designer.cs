
namespace QLDSV_TC
{
    partial class frmTaoLTC
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
            this.btnTaoLTC = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMon = new System.Windows.Forms.ComboBox();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGV = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNienKhoa1 = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNienKhoa2 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNhom = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSVTT = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNienKhoa1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNienKhoa2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSVTT.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTaoLTC
            // 
            this.btnTaoLTC.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoLTC.Location = new System.Drawing.Point(323, 354);
            this.btnTaoLTC.Name = "btnTaoLTC";
            this.btnTaoLTC.Size = new System.Drawing.Size(130, 29);
            this.btnTaoLTC.TabIndex = 21;
            this.btnTaoLTC.Text = "Tạo lớp tín chỉ";
            this.btnTaoLTC.UseVisualStyleBackColor = true;
            this.btnTaoLTC.Click += new System.EventHandler(this.btnTaoLTC_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "Chọn Môn :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Chọn Khoa:";
            // 
            // cbMon
            // 
            this.cbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMon.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMon.FormattingEnabled = true;
            this.cbMon.IntegralHeight = false;
            this.cbMon.ItemHeight = 18;
            this.cbMon.Location = new System.Drawing.Point(300, 57);
            this.cbMon.MaxDropDownItems = 5;
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(247, 26);
            this.cbMon.TabIndex = 18;
            // 
            // cbKhoa
            // 
            this.cbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKhoa.FormattingEnabled = true;
            this.cbKhoa.Location = new System.Drawing.Point(300, 12);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(247, 26);
            this.cbKhoa.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(161, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "Chọn Giảng viên :";
            // 
            // cbGV
            // 
            this.cbGV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGV.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGV.FormattingEnabled = true;
            this.cbGV.ItemHeight = 18;
            this.cbGV.Location = new System.Drawing.Point(300, 106);
            this.cbGV.MaxDropDownItems = 5;
            this.cbGV.Name = "cbGV";
            this.cbGV.Size = new System.Drawing.Size(247, 26);
            this.cbGV.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(161, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "Chọn Học kỳ :";
            // 
            // cbHocKy
            // 
            this.cbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHocKy.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.ItemHeight = 18;
            this.cbHocKy.Location = new System.Drawing.Point(300, 196);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(247, 26);
            this.cbHocKy.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(161, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 18);
            this.label7.TabIndex = 31;
            this.label7.Text = "Niên khóa :";
            // 
            // txtNienKhoa1
            // 
            this.txtNienKhoa1.Location = new System.Drawing.Point(300, 153);
            this.txtNienKhoa1.Name = "txtNienKhoa1";
            this.txtNienKhoa1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNienKhoa1.Properties.Appearance.Options.UseFont = true;
            this.txtNienKhoa1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNienKhoa1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNienKhoa1.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtNienKhoa1.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtNienKhoa1.Properties.MaskSettings.Set("mask", "d");
            this.txtNienKhoa1.Properties.MaxLength = 4;
            this.txtNienKhoa1.Properties.UseMaskAsDisplayFormat = true;
            this.txtNienKhoa1.Size = new System.Drawing.Size(89, 24);
            this.txtNienKhoa1.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(405, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 18);
            this.label8.TabIndex = 32;
            this.label8.Text = "-";
            // 
            // txtNienKhoa2
            // 
            this.txtNienKhoa2.Location = new System.Drawing.Point(433, 153);
            this.txtNienKhoa2.Name = "txtNienKhoa2";
            this.txtNienKhoa2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNienKhoa2.Properties.Appearance.Options.UseFont = true;
            this.txtNienKhoa2.Properties.DisplayFormat.FormatString = "n0";
            this.txtNienKhoa2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNienKhoa2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNienKhoa2.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtNienKhoa2.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtNienKhoa2.Properties.MaskSettings.Set("mask", "d");
            this.txtNienKhoa2.Properties.MaxLength = 4;
            this.txtNienKhoa2.Properties.UseMaskAsDisplayFormat = true;
            this.txtNienKhoa2.Size = new System.Drawing.Size(89, 24);
            this.txtNienKhoa2.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 35;
            this.label3.Text = "Nhóm :";
            // 
            // txtNhom
            // 
            this.txtNhom.Location = new System.Drawing.Point(300, 246);
            this.txtNhom.Name = "txtNhom";
            this.txtNhom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhom.Properties.Appearance.Options.UseFont = true;
            this.txtNhom.Properties.DisplayFormat.FormatString = "n0";
            this.txtNhom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNhom.Properties.EditFormat.FormatString = "n0";
            this.txtNhom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNhom.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtNhom.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtNhom.Properties.MaskSettings.Set("mask", "d");
            this.txtNhom.Properties.MaxLength = 2;
            this.txtNhom.Properties.UseMaskAsDisplayFormat = true;
            this.txtNhom.Size = new System.Drawing.Size(247, 24);
            this.txtNhom.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(161, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "Số SV tối thiểu :";
            // 
            // txtSVTT
            // 
            this.txtSVTT.Location = new System.Drawing.Point(300, 295);
            this.txtSVTT.Name = "txtSVTT";
            this.txtSVTT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSVTT.Properties.Appearance.Options.UseFont = true;
            this.txtSVTT.Properties.DisplayFormat.FormatString = "n0";
            this.txtSVTT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSVTT.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSVTT.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtSVTT.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False");
            this.txtSVTT.Properties.MaskSettings.Set("mask", "d");
            this.txtSVTT.Properties.UseMaskAsDisplayFormat = true;
            this.txtSVTT.Size = new System.Drawing.Size(247, 24);
            this.txtSVTT.TabIndex = 36;
            // 
            // frmTaoLTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 420);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSVTT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNhom);
            this.Controls.Add(this.txtNienKhoa2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNienKhoa1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbHocKy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbGV);
            this.Controls.Add(this.btnTaoLTC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMon);
            this.Controls.Add(this.cbKhoa);
            this.Name = "frmTaoLTC";
            this.Text = "frmTaoLTC";
            this.Load += new System.EventHandler(this.frmTaoLTC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNienKhoa1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNienKhoa2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSVTT.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTaoLTC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMon;
        private System.Windows.Forms.ComboBox cbKhoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtNienKhoa1;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtNienKhoa2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtNhom;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtSVTT;
    }
}