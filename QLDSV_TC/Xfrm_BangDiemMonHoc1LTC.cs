using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class Xfrm_BangDiemMonHoc1LTC : DevExpress.XtraEditors.XtraForm
    {
        public Xfrm_BangDiemMonHoc1LTC()
        {
            InitializeComponent();
        }

        private void Xfrm_BangDiemMonHoc1LTC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS_LOP.MONHOC' table. You can move, or remove it, as needed.
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connString;
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);

            comboKhoa.DataSource = Program.bdsDSKhoa;
            comboKhoa.DisplayMember = "TENKHOA";
            comboKhoa.ValueMember = "TENPM";

            comboKhoa.SelectedValue = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";

            comboHK.SelectedIndex = comboNK.SelectedIndex = comboNhom.SelectedIndex = 0;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

            if (comboNK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập niên khóa!", "Thông báo", MessageBoxButtons.OK);
                comboNK.Focus();
                return;
            }
            else if (Regex.IsMatch(comboNK.Text, "^[0-9]{4}-[0-9]{4}$") == false)
            {
                MessageBox.Show("Niên khóa phải có định dạng ####-####", "Lỗi", MessageBoxButtons.OK);
                comboNK.Focus();
                return;
            }

            if (comboNhom.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập nhóm!", "Thông báo", MessageBoxButtons.OK);
                comboNhom.Focus();
                return;
            }

            int nhom;

            try
            {
                nhom = int.Parse(comboNhom.Text.Trim());
            }catch(Exception ex)
            {
                MessageBox.Show("Nhóm không đúng định dạng!", "Thông báo", MessageBoxButtons.OK);
                comboNhom.Focus();
                return;
            }

            if (nhom == 0)
            {
                MessageBox.Show("Nhóm không hợp lệ!", "Thông báo", MessageBoxButtons.OK);
                comboNhom.Focus();
                return;
            }

            //Console.WriteLine("text: " + comboMH.Text);
            //Console.WriteLine("selected value: " + comboMH.SelectedValue);

            Xrpt_BangDiemMonHoc1LTC rpt = new Xrpt_BangDiemMonHoc1LTC(comboKhoa.Text,
                comboNK.Text,
                int.Parse(comboHK.Text),
                comboMH.SelectedValue.ToString(), //maMH
                comboMH.Text,   // tenMH
                nhom
            );

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();

        }

        private void comboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.server = Program.khoa[comboKhoa.Text].Item2;

            if (Program.khoa[comboKhoa.Text].ToString() != Program.mKhoa)
            {
                Program.mLogin = Program.remoteLogin;
                Program.pass = Program.remotePass;
            }
            else
            {
                Program.mLogin = Program.loginDN;
                Program.pass = Program.passDN;
            }

            if (Program.Connect() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới! ", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                this.MONHOCTableAdapter.Connection.ConnectionString = Program.connString;
                this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
            }
        }
    }
}