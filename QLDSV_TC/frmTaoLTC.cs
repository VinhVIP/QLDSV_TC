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
    public partial class frmTaoLTC : DevExpress.XtraEditors.XtraForm
    {
        public frmTaoLTC()
        {
            InitializeComponent();
        }

        private void frmTaoLTC_Load(object sender, EventArgs e)
        {
            DSGV();
            DSHocKy();
            DSKhoa();
            DSMon();
            setNienKhoa();
        }

        private void DSKhoa()
        {
            if (Program.role.Equals("PGV"))
            {
                if (Program.Connect() == 0) return;
                DataTable dt = Program.ExecSqlDataTable("EXEC SP_Lay_DS_KHOA_2");

                cbKhoa.DataSource = dt;
                cbKhoa.DisplayMember = "TENKHOA";
                cbKhoa.ValueMember = "MAKHOA";
                cbKhoa.SelectedIndex = 0;
            }
            else if (Program.role.Equals("KHOA"))
            {
                if (Program.Connect() == 0) return;
                DataTable dt = Program.ExecSqlDataTable("EXEC SP_Lay_TEN_KHOA_HIENTAI");

                cbKhoa.DataSource = dt;
                cbKhoa.DisplayMember = "TENKHOA";
                cbKhoa.ValueMember = "MAKHOA";
                cbKhoa.SelectedIndex = 0;
            }
        }

        private void DSMon()
        {
            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable("EXEC SP_LAY_DS_MONHOC");

            cbMon.DataSource = dt;
            cbMon.DisplayMember = "TENMH";
            cbMon.ValueMember = "MAMH";
            cbMon.SelectedValue = "XLA";
        }

        private void DSGV()
        {
            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable("EXEC SP_LayDSGV");
            cbGV.DataSource = dt;
            cbGV.DisplayMember = "HOTEN";
            cbGV.ValueMember = "MAGV";

            cbGV.SelectedIndex = 0;
        }

        private void setNienKhoa()
        {
            if (Program.Connect() == 0) return;

            Program.ExecSqlDataReader("SP_LAY_NIENKHOA_HIENTAI");

            Program.reader.Read();

            txtNienKhoa1.Text = Program.reader.GetInt32(0).ToString();
            txtNienKhoa2.Text = Program.reader.GetInt32(1).ToString();

            Program.reader.Close();
        }

        private void DSHocKy()
        {
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
            cbHocKy.Items.Add("3");
            cbHocKy.Items.Add("4");
            cbHocKy.SelectedIndex = 0;
        }

        private void btnTaoLTC_Click(object sender, EventArgs e)
        {
           
           if (txtNhom.Text.Trim().Length == 0 || txtNienKhoa1.Text.Trim().Length == 0 || txtNienKhoa2.Text.Trim().Length == 0 || txtSVTT.Text.Trim().Length == 0)
           {
               MessageBox.Show("Vui lòng điền đầy đủ dữ liệu", "Thông báo", MessageBoxButtons.OK);

            }
            else
            {
                try
                {
                    if (Program.ExecSqlNonQuery("SP_THEM_LTC", CommandType.StoredProcedure, new[] {
                    new SqlParameter("@NIENKHOA", SqlDbType.NChar){Value=txtNienKhoa1.Text.ToString()+"-"+txtNienKhoa2.Text.ToString()},
                    new SqlParameter("@HOCKY", SqlDbType.Int){Value=cbHocKy.SelectedItem.ToString()},
                    new SqlParameter("@MAMH", SqlDbType.NChar){Value=cbMon.SelectedValue.ToString()},
                    new SqlParameter("@NHOM", SqlDbType.Int){Value=txtNhom.Text.ToString()},
                    new SqlParameter("@MAGV", SqlDbType.NChar){Value=cbGV.SelectedValue.ToString()},
                    new SqlParameter("@SOSVTOITHIEU", SqlDbType.SmallInt){Value=txtSVTT.Text.ToString()},
                    new SqlParameter("@SERVER_HIENTAI", SqlDbType.NChar){Value=Program.mKhoa},
                    new SqlParameter("@SERVER_THEM", SqlDbType.NChar){Value=cbKhoa.SelectedValue.ToString()},
                    }) == 1)
                    {
                        MessageBox.Show("Thêm lớp tín chỉ thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                }
                
            }


            //Console.WriteLine(txtNhom.Text.ToString().GetType());
           // Console.WriteLine(Int32.Parse(txtNhom.Text.ToString()) + 123);
            //Console.WriteLine(Int32.Parse(txtNhom.ToString().Trim())+1);
            

        }
    }
}