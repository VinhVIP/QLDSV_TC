
namespace QLDSV_TC
{
    partial class Xfrm_DS_LTC
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
            this.cbHocky = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbNienkhoa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBaocao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbHocky
            // 
            this.cbHocky.CausesValidation = false;
            this.cbHocky.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHocky.FormattingEnabled = true;
            this.cbHocky.Location = new System.Drawing.Point(455, 160);
            this.cbHocky.Name = "cbHocky";
            this.cbHocky.Size = new System.Drawing.Size(135, 21);
            this.cbHocky.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Học kỳ:";
            // 
            // cbNienkhoa
            // 
            this.cbNienkhoa.CausesValidation = false;
            this.cbNienkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNienkhoa.FormattingEnabled = true;
            this.cbNienkhoa.Location = new System.Drawing.Point(455, 109);
            this.cbNienkhoa.Name = "cbNienkhoa";
            this.cbNienkhoa.Size = new System.Drawing.Size(135, 21);
            this.cbNienkhoa.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Niên khóa :";
            // 
            // cbKhoa
            // 
            this.cbKhoa.CausesValidation = false;
            this.cbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKhoa.Enabled = false;
            this.cbKhoa.FormattingEnabled = true;
            this.cbKhoa.Location = new System.Drawing.Point(455, 59);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(135, 21);
            this.cbKhoa.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Khoa :";
            // 
            // btnBaocao
            // 
            this.btnBaocao.Location = new System.Drawing.Point(433, 234);
            this.btnBaocao.Name = "btnBaocao";
            this.btnBaocao.Size = new System.Drawing.Size(120, 36);
            this.btnBaocao.TabIndex = 20;
            this.btnBaocao.Text = "Xem báo cáo";
            this.btnBaocao.UseVisualStyleBackColor = true;
            this.btnBaocao.Click += new System.EventHandler(this.btnBaocao_Click);
            // 
            // Xfrm_DS_LTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 382);
            this.Controls.Add(this.btnBaocao);
            this.Controls.Add(this.cbHocky);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbNienkhoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbKhoa);
            this.Controls.Add(this.label1);
            this.Name = "Xfrm_DS_LTC";
            this.Text = "Xfrm_DS_LTC";
            this.Load += new System.EventHandler(this.Xfrm_DS_LTC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbHocky;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbNienkhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBaocao;
    }
}