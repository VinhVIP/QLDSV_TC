
namespace QLDSV_TC
{
    partial class Xfrm_BangDiemTongKetLop
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
            this.label4 = new System.Windows.Forms.Label();
            this.comboKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.DS_LOP = new QLDSV_TC.DS_LOP();
            this.bdsLop = new System.Windows.Forms.BindingSource(this.components);
            this.LOPTableAdapter = new QLDSV_TC.DS_LOPTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new QLDSV_TC.DS_LOPTableAdapters.TableAdapterManager();
            this.comboLop = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS_LOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(273, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Lớp :";
            // 
            // comboKhoa
            // 
            this.comboKhoa.CausesValidation = false;
            this.comboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboKhoa.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboKhoa.FormattingEnabled = true;
            this.comboKhoa.Location = new System.Drawing.Point(327, 67);
            this.comboKhoa.Name = "comboKhoa";
            this.comboKhoa.Size = new System.Drawing.Size(236, 26);
            this.comboKhoa.TabIndex = 18;
            this.comboKhoa.SelectedIndexChanged += new System.EventHandler(this.comboKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Khoa :";
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(362, 252);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(129, 28);
            this.btnPreview.TabIndex = 21;
            this.btnPreview.Text = "Xem trước";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // DS_LOP
            // 
            this.DS_LOP.DataSetName = "DS_LOP";
            this.DS_LOP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsLop
            // 
            this.bdsLop.DataMember = "LOP";
            this.bdsLop.DataSource = this.DS_LOP;
            // 
            // LOPTableAdapter
            // 
            this.LOPTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.LOPTableAdapter = this.LOPTableAdapter;
            this.tableAdapterManager.UpdateOrder = QLDSV_TC.DS_LOPTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // comboLop
            // 
            this.comboLop.DataSource = this.bdsLop;
            this.comboLop.DisplayMember = "MALOP";
            this.comboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLop.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLop.FormattingEnabled = true;
            this.comboLop.Location = new System.Drawing.Point(327, 154);
            this.comboLop.Name = "comboLop";
            this.comboLop.Size = new System.Drawing.Size(236, 26);
            this.comboLop.TabIndex = 22;
            this.comboLop.ValueMember = "MALOP";
            // 
            // Xfrm_BangDiemTongKetLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 383);
            this.Controls.Add(this.comboLop);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboKhoa);
            this.Controls.Add(this.label1);
            this.Name = "Xfrm_BangDiemTongKetLop";
            this.Text = "Xfrm_BangDiemTongKetLop";
            this.Load += new System.EventHandler(this.Xfrm_BangDiemTongKetLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS_LOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreview;
        private DS_LOP DS_LOP;
        private System.Windows.Forms.BindingSource bdsLop;
        private DS_LOPTableAdapters.LOPTableAdapter LOPTableAdapter;
        private DS_LOPTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox comboLop;
    }
}