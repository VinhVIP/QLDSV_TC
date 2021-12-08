
namespace QLDSV_TC
{
    partial class Xfrm_HocPhiTheoLop
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboHK = new System.Windows.Forms.ComboBox();
            this.comboNK = new System.Windows.Forms.ComboBox();
            this.DS_LOP = new QLDSV_TC.DS_LOP();
            this.bdsLOP = new System.Windows.Forms.BindingSource(this.components);
            this.lOPTableAdapter = new QLDSV_TC.DS_LOPTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new QLDSV_TC.DS_LOPTableAdapters.TableAdapterManager();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS_LOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLOP)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(602, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Học kỳ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.Location = new System.Drawing.Point(374, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Niên khóa:";
            // 
            // comboHK
            // 
            this.comboHK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHK.Font = new System.Drawing.Font("Tahoma", 10F);
            this.comboHK.FormattingEnabled = true;
            this.comboHK.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboHK.Location = new System.Drawing.Point(676, 25);
            this.comboHK.Name = "comboHK";
            this.comboHK.Size = new System.Drawing.Size(121, 24);
            this.comboHK.TabIndex = 7;
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
            this.comboNK.Location = new System.Drawing.Point(462, 25);
            this.comboNK.Name = "comboNK";
            this.comboNK.Size = new System.Drawing.Size(121, 24);
            this.comboNK.TabIndex = 6;
            // 
            // DS_LOP
            // 
            this.DS_LOP.DataSetName = "DS_LOP";
            this.DS_LOP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsLOP
            // 
            this.bdsLOP.DataMember = "LOP";
            this.bdsLOP.DataSource = this.DS_LOP;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.LOPTableAdapter = this.lOPTableAdapter;
            this.tableAdapterManager.UpdateOrder = QLDSV_TC.DS_LOPTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(388, 79);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(129, 28);
            this.btnPreview.TabIndex = 27;
            this.btnPreview.Text = "Xem trước";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cbLop
            // 
            this.cbLop.DataSource = this.bdsLOP;
            this.cbLop.DisplayMember = "MALOP";
            this.cbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLop.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(120, 23);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(236, 26);
            this.cbLop.TabIndex = 29;
            this.cbLop.ValueMember = "MALOP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "Lớp :";
            // 
            // Xfrm_HocPhiTheoLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 466);
            this.Controls.Add(this.cbLop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboHK);
            this.Controls.Add(this.comboNK);
            this.Name = "Xfrm_HocPhiTheoLop";
            this.Text = "Xfrm_HocPhiTheoLop";
            this.Load += new System.EventHandler(this.Xfrm_HocPhiTheoLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS_LOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboHK;
        private System.Windows.Forms.ComboBox comboNK;
        private DS_LOP DS_LOP;
        private System.Windows.Forms.BindingSource bdsLOP;
        private DS_LOPTableAdapters.LOPTableAdapter lOPTableAdapter;
        private DS_LOPTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Label label4;
    }
}