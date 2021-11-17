using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace QLDSV_TC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        

        public static SqlConnection conn = new SqlConnection();
        public static String connString = "";
        public static String connPublisher = "Data Source=localhost;Initial Catalog=QLDSV_TC;Persist Security Info=True;User ID=sa;Password=123456;Connection Timeout=5";
        public static String connTemplate = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connection Timeout=5";
        public static String dbName = "QLDSV_TC";

        public static BindingSource bindingSourcePM = new BindingSource();
        public static BindingSource bdsDSKhoa = new BindingSource();

        public static string mKhoa = "";

        public static String server = "";
        public static String mLogin = "";
        public static String username = "";
        public static String pass = "";

        public static String fullName = "";
        public static String role = "";

        public static String remoteLogin = "HTKN";
        public static String remotePass = "123456";

        public static String loginDN = "";
        public static String passDN = "";

        public static String loginSV = "SV";
        public static String passSV = "123456";

        public static SqlDataReader reader;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        public static int Connect()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                connString = String.Format(connTemplate, server, dbName, mLogin, pass);
                conn.ConnectionString = connString;
                conn.Open();
                return 1;
            }catch(Exception ex)
            {
                //MessageBox.Show("Lỗi kết nối tới CSDL.\n Kiểm tra lại username và password.\n " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static int ConnectPublisher()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            try
            {
                conn.ConnectionString = connPublisher;
                conn.Open();
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối tới CSDL.\n Kiểm tra lại username và password.\n " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        /**
         * Gán các thông tin kết nối server và cập nhật lại connString cho đúng với cấu hình vừa được gán
         */
        public static void setConnectionProperties(String serverName, String login, String password)
        {
            server = serverName;
            mLogin = login;
            pass = password;

            connString =  String.Format(connTemplate, serverName, dbName, login, password);
        }

        /**
         * Mở lại kết nối có sẵn nếu nó bị đóng
         */
        public static void TryExistsConnect()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
        }

        public static SqlDataReader ExecSqlDataReader(String sql)
        {
            TryExistsConnect();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                reader = cmd.ExecuteReader();
                return reader;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String sql, CommandType type, SqlParameter[] parameters)
        {
            TryExistsConnect();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = type;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            try
            {
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                reader = null;
                return null;
            }

        }

        public static int ExecSqlNonQuery(String sql)
        {
            TryExistsConnect();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            // cmd.CommandTimeout = 600;
            try
            {
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return ex.State;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int ExecSqlNonQuery(String sql, CommandType type, SqlParameter[] parameters)
        {
            TryExistsConnect();

            SqlCommand cmd = new SqlCommand(sql, conn);
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            cmd.CommandType = type;
            // cmd.CommandTimeout = 600;
            try
            {
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataTable ExecSqlDataTable(String sql)
        {
            TryExistsConnect();

            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dataTable);
            conn.Close();
            return dataTable;
        }

    }
}
