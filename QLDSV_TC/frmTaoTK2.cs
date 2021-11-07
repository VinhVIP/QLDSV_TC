using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class frmTaoTK2 : DevExpress.XtraEditors.XtraForm
    {
        public frmTaoTK2()
        {
            InitializeComponent();
        }

        private void frmTaoTK2_Load(object sender, EventArgs e)
        {
            layDSGV();
            initNhom();
        }

        private void layDSGV()
        {
            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable("EXEC SP_LayDSGV");

            comboBoxGV.DataSource = dt;
            comboBoxGV.DisplayMember = "HOTEN";
            comboBoxGV.ValueMember = "MAGV";
        }

        private void initNhom()
        {
            if (Program.role.Equals("PGV"))
            {
                comboBoxNhom.Items.Add("PGV");
                comboBoxNhom.Items.Add("KHOA");
            }
            else if (Program.role.Equals("KHOA"))
            {
                comboBoxNhom.Items.Add("KHOA");
            }
            else if (Program.role.Equals("PKT"))
            {
                comboBoxNhom.Items.Add("PKT");
            }

            comboBoxNhom.SelectedIndex = 0;
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            if (txtTK.Text.Trim().Length == 0 || txtMK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tài khoản và mật khẩu không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (comboBoxGV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giảng viên muốn tạo tài khoản!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (comboBoxNhom.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhóm quyền!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            Program.ExecSqlDataReader("SP_TAOLOGIN", CommandType.StoredProcedure, new[] {
                new SqlParameter("@LGNAME", SqlDbType.VarChar) { Value=txtTK.Text.Trim() },
                new SqlParameter("@PASS", SqlDbType.VarChar) { Value=txtMK.Text.Trim() },
                new SqlParameter("@USERNAME", SqlDbType.VarChar) { Value=comboBoxGV.SelectedValue },
                new SqlParameter("@ROLE", SqlDbType.VarChar) { Value=((String)comboBoxNhom.SelectedItem).Trim() },
            });

            if (Program.reader != null)
            {
                MessageBox.Show("Tạo tài khoản thành công!", "Thống báo", MessageBoxButtons.OK);
            }
        }
    }
}