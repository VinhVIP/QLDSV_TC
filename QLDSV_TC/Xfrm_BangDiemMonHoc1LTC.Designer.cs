
namespace QLDSV_TC
{
    partial class Xfrm_BangDiemMonHoc1LTC
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
            this.comboKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboNK = new System.Windows.Forms.ComboBox();
            this.comboHK = new System.Windows.Forms.ComboBox();
            this.comboNhom = new System.Windows.Forms.ComboBox();
            this.DS = new QLDSV_TC.DS_LOP();
            this.bdsMH = new System.Windows.Forms.BindingSource(this.components);
            this.MONHOCTableAdapter = new QLDSV_TC.DS_LOPTableAdapters.MONHOCTableAdapter();
            this.tableAdapterManager = new QLDSV_TC.DS_LOPTableAdapters.TableAdapterManager();
            this.comboMH = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).BeginInit();
            this.SuspendLayout();
            // 
            // comboKhoa
            // 
            this.comboKhoa.CausesValidation = false;
            this.comboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKhoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboKhoa.FormattingEnabled = true;
            this.comboKhoa.Location = new System.Drawing.Point(391, 33);
            this.comboKhoa.Name = "comboKhoa";
            this.comboKhoa.Size = new System.Drawing.Size(236, 26);
            this.comboKhoa.TabIndex = 7;
            this.comboKhoa.SelectedIndexChanged += new System.EventHandler(this.comboKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Khoa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(560, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Niên khóa :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Học kỳ :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(118, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Môn học :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(585, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nhóm :";
            // 
            // comboNK
            // 
            this.comboNK.AutoCompleteCustomSource.AddRange(new string[] {
            "2018-2019",
            "2019-2020",
            "2020-2021",
            "2021-2022"});
            this.comboNK.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNK.FormattingEnabled = true;
            this.comboNK.Items.AddRange(new object[] {
            "2019-2020",
            "2020-2021",
            "2021-2022"});
            this.comboNK.Location = new System.Drawing.Point(670, 124);
            this.comboNK.Name = "comboNK";
            this.comboNK.Size = new System.Drawing.Size(160, 26);
            this.comboNK.TabIndex = 13;
            // 
            // comboHK
            // 
            this.comboHK.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3"});
            this.comboHK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHK.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboHK.FormattingEnabled = true;
            this.comboHK.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboHK.Location = new System.Drawing.Point(211, 198);
            this.comboHK.Name = "comboHK";
            this.comboHK.Size = new System.Drawing.Size(133, 26);
            this.comboHK.TabIndex = 14;
            // 
            // comboNhom
            // 
            this.comboNhom.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3"});
            this.comboNhom.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboNhom.FormattingEnabled = true;
            this.comboNhom.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboNhom.Location = new System.Drawing.Point(670, 198);
            this.comboNhom.Name = "comboNhom";
            this.comboNhom.Size = new System.Drawing.Size(160, 26);
            this.comboNhom.TabIndex = 15;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS_LOP";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsMH
            // 
            this.bdsMH.DataMember = "MONHOC";
            this.bdsMH.DataSource = this.DS;
            // 
            // MONHOCTableAdapter
            // 
            this.MONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLDSV_TC.DS_LOPTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // comboMH
            // 
            this.comboMH.DataSource = this.bdsMH;
            this.comboMH.DisplayMember = "TENMH";
            this.comboMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMH.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMH.FormattingEnabled = true;
            this.comboMH.Location = new System.Drawing.Point(211, 119);
            this.comboMH.Name = "comboMH";
            this.comboMH.Size = new System.Drawing.Size(236, 26);
            this.comboMH.TabIndex = 16;
            this.comboMH.ValueMember = "MAMH";
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(449, 308);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(133, 35);
            this.btnPreview.TabIndex = 17;
            this.btnPreview.Text = "Xem báo cáo";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // Xfrm_BangDiemMonHoc1LTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 413);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.comboMH);
            this.Controls.Add(this.comboNhom);
            this.Controls.Add(this.comboHK);
            this.Controls.Add(this.comboNK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboKhoa);
            this.Controls.Add(this.label1);
            this.Name = "Xfrm_BangDiemMonHoc1LTC";
            this.Text = "Xfrm_BangDiemMonHoc1LTC";
            this.Load += new System.EventHandler(this.Xfrm_BangDiemMonHoc1LTC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboNK;
        private System.Windows.Forms.ComboBox comboHK;
        private System.Windows.Forms.ComboBox comboNhom;
        private DS_LOP DS;
        private System.Windows.Forms.BindingSource bdsMH;
        private DS_LOPTableAdapters.MONHOCTableAdapter MONHOCTableAdapter;
        private DS_LOPTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox comboMH;
        private System.Windows.Forms.Button btnPreview;
    }
}