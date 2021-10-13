using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLDSV_TC
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            LayDSPM();
        }

        /**
         * Lấy tên và địa chỉ các phân mảnh gán vào ComboBox
         */
        private void LayDSPM()
        {
            if (Program.ConnectPublisher() == 0) return;
            DataTable dt = Program.ExecSqlDataTable("EXEC SP_LayDSPM");

            // Lưu trữ danh sách phân mảnh 
            Program.bindingSourcePM.DataSource = dt;

            comboKhoa.DataSource = Program.bindingSourcePM;
            comboKhoa.DisplayMember = "TENPM";
            comboKhoa.ValueMember = "TENSERVER";
        }

        private void btnLogin(object sender, EventArgs e)
        {
            if (txtTK.Text.Trim().Length == 0 || txtMK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tài khoản và mật khẩu không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            // Thiết lập cấu hình kết nối
            Program.setConnectionProperties((string)comboKhoa.SelectedValue, txtTK.Text.Trim(), txtMK.Text.Trim());

            if (Program.Connect() == 0)
            {
                // Nếu login thất bại thì kiểm tra xem login đó có phải là của sinh viên hay không
                // Mã SV có 10 kí tự
                if (txtTK.Text.Trim().Length == 10)
                {
                    // Kết nối về Site chủ
                    if (Program.ConnectPublisher() == 0)
                    {
                        return;
                    }

                    Program.ExecSqlDataReader("SP_LayLoginSV", CommandType.StoredProcedure, new[] {
                        new SqlParameter("@MASV", SqlDbType.NVarChar){Value=txtTK.Text.Trim()},
                        new SqlParameter("@PASSWORD", SqlDbType.NVarChar){Value=txtMK.Text.Trim()}
                    });

                    if (Program.reader == null)
                    {
                        MessageBox.Show("Eos hieu sao bi null :))", "Info");
                        return;
                    }

                    if (Program.reader.Read())
                    {
                        // Lưu trữ thông tin sinh viên đăng nhập
                        Program.fullName = Program.reader.GetString(1);
                        
                        // MessageBox.Show(Program.fullName, "Info");

                        // Hiển thị frmMain và ẩn frmLogin
                        new frmMain().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai thông tin đăng nhập", "Info");
                    }
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập", "Info");
                }
            }
            else
            {
                getLoginInfo();
            }


        }

        /**
         * Lấy thông tin user vừa login
         * Áp dụng cho Giảng viên login (PGV, KHOA, PKT)
         */
        private void getLoginInfo()
        {
            Program.ExecSqlDataReader("SP_DANGNHAP", CommandType.StoredProcedure, new[] {
                new SqlParameter("@TENLOGIN", SqlDbType.NVarChar){Value=Program.loginname}
            });


            if (Program.reader == null) return;

            if (Program.reader.Read())
            {
                Program.fullName = Program.reader.GetString(1);
                // MessageBox.Show(Program.fullName, "Info");
                new frmMain().Show();
                this.Hide();
            }
        }


    }
}