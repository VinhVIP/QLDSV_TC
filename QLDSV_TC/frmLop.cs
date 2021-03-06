using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class frmLop : DevExpress.XtraEditors.XtraForm
    {

        private String maKhoa, maLop;
        private DataTable dtSV, dtCopy;

        private int lastLopPosition;

        private String curServer;
        private String curLogin, curPass;

        public frmLop()
        {
            InitializeComponent();
        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            DS_LOP.EnforceConstraints = false;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTableAdapter.Fill(this.DS_LOP.LOP);

            comboKhoa.DataSource = Program.bdsDSKhoa;
            comboKhoa.DisplayMember = "TENKHOA";
            comboKhoa.ValueMember = "TENPM";

            comboKhoa.SelectedValue = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";

            maKhoa = comboKhoa.SelectedValue.ToString();

            curServer = Program.server;
            curLogin = Program.mLogin;
            curPass = Program.pass;

            initState();
        }

        private void initState()
        {
            btnGhi.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = btnReload.Enabled = gcLop.Enabled = true;
            btnUndo.Enabled = gvSV.Enabled = panelLop.Enabled = false;
            
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

            // Lưu lại server đang thao tác
            curServer = Program.server;
            curLogin = Program.mLogin;
            curPass = Program.pass;

            if (Program.Connect() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới! ", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
                this.LOPTableAdapter.Fill(this.DS_LOP.LOP);
                
                maKhoa = comboKhoa.SelectedValue.ToString();

                initState();
            }
        }

        

        private void btnLoadDSSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
            loadDSSV(maLop);
        }

        private void loadDSSV(string maLop)
        {
            String sql = "EXEC SP_LAY_DSSV_LOP " + maLop;
            dtSV = Program.ExecSqlDataTable(sql);

            // Copy
            dtCopy = dtSV.Clone();
            for (int i = 0; i < dtSV.Rows.Count; i++)
            {
                dtCopy.Rows.Add(dtSV.Rows[i]["MASV"], dtSV.Rows[i]["HO"],
                            dtSV.Rows[i]["TEN"], dtSV.Rows[i]["PHAI"],
                            dtSV.Rows[i]["DIACHI"], dtSV.Rows[i]["NGAYSINH"],
                            dtSV.Rows[i]["DANGHIHOC"], dtSV.Rows[i]["PASSWORD"]);
            }

            gvSV.DataSource = dtSV;

            for (int i = 0; i < dtSV.Rows.Count; i++)
            {
                gvSV.Rows[i].Cells[0].ReadOnly = true;
            }

            gcLop.Enabled = panelLop.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = btnReload.Enabled = false;
            gvSV.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;

            ((DataGridViewTextBoxColumn)gvSV.Columns["MASV"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)gvSV.Columns["HO"]).MaxInputLength = 50;
            ((DataGridViewTextBoxColumn)gvSV.Columns["TEN"]).MaxInputLength = 10;
            ((DataGridViewTextBoxColumn)gvSV.Columns["DIACHI"]).MaxInputLength = 100;

            // gvSV.Columns["TEN"].SortMode = DataGridViewColumnSortMode.NotSortable;

            // gvSV.Sort(gvSV.Columns["MASV"], ListSortDirection.Descending);

            disableSortGVSV();

        }

        private void disableSortGVSV()
        {
            foreach (DataGridViewColumn column in gvSV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void gvSV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (dtSV == null || dtSV.Rows.Count == 0) return;

            if (MessageBox.Show("Bạn thực sự muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int removePos = gvSV.CurrentCell.RowIndex;
                if (removePos == -1) return;

                String maSV = gvSV.Rows[removePos].Cells["MASV"].Value.ToString();
                Console.WriteLine("Xoa :" + maSV);

                int result = Program.ExecSqlNonQuery("SP_XOA_SV", CommandType.StoredProcedure, new[] {
                        new SqlParameter("@masv", SqlDbType.NChar){Value=maSV}
                    });

                if (result == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    dtSV.Rows.RemoveAt(removePos);

                    //dtCopy.PrimaryKey = new DataColumn[] { dtCopy.Columns["MASV"] };

                    //DataRow rows = dtCopy.Rows.Find(maSV);
                    //Console.WriteLine(rows["HO"]);
                    //foreach(DataRow r in rows)
                    //{
                    //    Console.WriteLine(r["TEN"]);
                    //    dtCopy.Rows.Remove(r);
                    //}
                }
            }

            //for(int i=0; i<dtCopy.Rows.Count; i++)
            //{
            //    Console.WriteLine(dtCopy.Rows[i].ItemArray[0]);
            //}
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
           
            dtSV.Rows.Add();

            dtSV.Rows[dtSV.Rows.Count - 1]["PHAI"] = false;
            dtSV.Rows[dtSV.Rows.Count - 1]["DANGHIHOC"] = false;
            dtSV.Rows[dtSV.Rows.Count - 1]["PASSWORD"] = Program.encrypt("123456");

            gvSV.CurrentCell = gvSV.Rows[dtSV.Rows.Count - 1].Cells["MASV"];
            gvSV.BeginEdit(true);
        }


        private void bdsLOP_PositionChanged(object sender, EventArgs e)
        {
            if (dtSV != null && dtSV.Rows.Count > 0) dtSV.Clear();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.AddNew();

            txtMaKhoa.Text = maKhoa;

            lastLopPosition = bdsLOP.Position;

            btnThem.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = gvSV.Enabled = gcLop.Enabled = btnReload.Enabled = false;
            panelLop.Enabled = btnGhi.Enabled = btnUndo.Enabled = true;

            txtMaLop.Focus();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (panelLop.Enabled)
            {
                bdsLOP.CancelEdit();
                bdsLOP.RemoveAt(bdsLOP.Count - 1);
            }

            initState();
            

            //gcLop.Enabled = true;
            //panelLop.Enabled = gvSV.Enabled = false;

            //btnUndo.Enabled = false;
            //btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = btnLoadDSSV.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (MessageBox.Show("Bạn thực sự muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();

                int result = Program.ExecSqlNonQuery("SP_XOA_LOP", CommandType.StoredProcedure, new[] {
                        new SqlParameter("@malop", SqlDbType.NChar){Value=maLop}
                    });

                if (result == 1)
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    //bdsLOP.RemoveCurrent();
                    LOPTableAdapter.Connection.ConnectionString = Program.connString;
                    this.LOPTableAdapter.Fill(this.DS_LOP.LOP);
                }
            }

            if (bdsLOP.Count == 0) btnXoa.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LOPTableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTableAdapter.Fill(this.DS_LOP.LOP);
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (panelLop.Enabled)
            {
                // Thêm lớp
                // Kiểm tra các ràng buộc
                if (txtMaLop.Text.Trim() == "")
                {
                    MessageBox.Show("Mã lớp không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                    txtMaLop.Focus();
                    return;
                }
                if (txtTenLop.Text.Trim() == "")
                {
                    MessageBox.Show("Tên lớp không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                    txtTenLop.Focus();
                    return;
                }
                if (txtKhoaHoc.Text.Trim() == "")
                {
                    MessageBox.Show("Khóa học không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
                    txtKhoaHoc.Focus();
                    return;
                }
                else if(Regex.IsMatch(txtKhoaHoc.Text, "^[0-9]{4}-[0-9]{4}$") == false)
                {
                    MessageBox.Show("Khóa học phải có định dạng ####-####", "Thông báo", MessageBoxButtons.OK);
                    txtKhoaHoc.Focus();
                    return;
                }
                else
                {
                    int year1 = Int32.Parse(txtKhoaHoc.Text.ToString().Substring(0, 4));
                    int year2 = Int32.Parse(txtKhoaHoc.Text.ToString().Substring(5));

                    if(year1 >= year2)
                    {
                        MessageBox.Show("Khóa học không hợp lệ!", "Thông báo", MessageBoxButtons.OK);
                        txtKhoaHoc.Focus();
                        return;
                    }
                }


                string maLop = txtMaLop.Text.Trim();

                if (Program.ExecSqlNonQuery("SP_THEM_LOP", CommandType.StoredProcedure, new[]
                {
                        new SqlParameter("@malop", SqlDbType.NChar){Value=maLop.ToUpper()},
                        new SqlParameter("@tenlop", SqlDbType.NVarChar){Value=txtTenLop.Text.Trim()},
                        new SqlParameter("@khoahoc", SqlDbType.NChar){Value=txtKhoaHoc.Text.Trim()},
                        new SqlParameter("@makhoa", SqlDbType.NChar){Value=txtMaKhoa.Text}
                    }) == 1)
                {
                    LOPTableAdapter.Connection.ConnectionString = Program.connString;
                    LOPTableAdapter.Fill(DS_LOP.LOP);
                    
                    MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);
                    
                    btnGhi.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = btnReload.Enabled = gcLop.Enabled = true;
                    btnUndo.Enabled = gvSV.Enabled = panelLop.Enabled = false;

                }
                
            }
            else
            {
                if (gcLop.Enabled)
                {
                    for (int i=0; i<bdsLOP.Count; i++)
                    {
                        String khoahoc = ((DataRowView)bdsLOP[i])["KHOAHOC"].ToString();
                        if(Regex.IsMatch(khoahoc, "^[0-9]{4}-[0-9]{4}$") == false)
                        {
                            bdsLOP.Position = i;
                            MessageBox.Show("Khóa học phải có định dạng ####-####", "Lỗi", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            int year1 = Int32.Parse(txtKhoaHoc.Text.ToString().Substring(0, 4));
                            int year2 = Int32.Parse(txtKhoaHoc.Text.ToString().Substring(5));

                            if (year1 >= year2)
                            {
                                MessageBox.Show("Khóa học không hợp lệ!", "Thông báo", MessageBoxButtons.OK);
                                txtKhoaHoc.Focus();
                                return;
                            }
                        }

                        String tenlop = ((DataRowView)bdsLOP[i])["TENLOP"].ToString();
                        if(tenlop.Length > 50)
                        {
                            bdsLOP.Position = i;
                            MessageBox.Show("Tên lớp không được vượt quá 50 kí tự", "Lỗi", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    
                    try
                    {
                        // Cập nhật Lớp
                        bdsLOP.EndEdit();
                        bdsLOP.ResetCurrentItem();
                        LOPTableAdapter.Connection.ConnectionString = Program.connString;
                        LOPTableAdapter.Update(DS_LOP.LOP);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Cập nhật lớp thất bại: "+ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }

                    MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);

                    btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = gcLop.Enabled = btnReload.Enabled = true;
                    btnUndo.Enabled = gvSV.Enabled = panelLop.Enabled = false;
                }
                

                if (gvSV.Enabled)
                {
                    // Kiểm tra bảng sinh viên hiện tại có bị trùng mã sinh viên nào hay không
                    try
                    {
                        dtSV.PrimaryKey = new DataColumn[] { dtSV.Columns["MASV"] };
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Có mã sinh viên bị trùng", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    

                    // Thêm sinh viên
                    DataTable dt = new DataTable();

                    dt.Columns.Add("MASV", typeof(string));
                    dt.Columns.Add("HO", typeof(string));
                    dt.Columns.Add("TEN", typeof(string));
                    dt.Columns.Add("PHAI", typeof(bool));
                    dt.Columns.Add("DIACHI", typeof(string));
                    dt.Columns.Add("NGAYSINH", typeof(string));
                    dt.Columns.Add("MALOP", typeof(string));
                    dt.Columns.Add("DANGHIHOC", typeof(bool));
                    dt.Columns.Add("PASSWORD", typeof(string));
                    dt.Columns.Add("NEW", typeof(bool));    // Kiểm tra row thêm mới hay chỉnh sửa


                    for (int i = 0; i < dtSV.Rows.Count; i++)
                    {

                        if(i < dtCopy.Rows.Count)
                        {
                            // Cập nhật
                            int index = indexRow(dtCopy, dtSV.Rows[i]);
                            if (index != -1)
                            {
                                if (!isSameRow(dtSV.Rows[i], dtCopy.Rows[index]))
                                {
                                    Console.WriteLine(dtSV.Rows[i]["MASV"] + " Edit");

                                    dt.Rows.Add(dtSV.Rows[i]["MASV"].ToString().ToUpper(),
                                       formatName(dtSV.Rows[i]["HO"].ToString()),
                                       formatWord(dtSV.Rows[i]["TEN"].ToString().Trim()),
                                       dtSV.Rows[i]["PHAI"],
                                       dtSV.Rows[i]["DIACHI"],
                                       convertDate(dtSV.Rows[i]["NGAYSINH"].ToString()),
                                       maLop,
                                       dtSV.Rows[i]["DANGHIHOC"],
                                       dtSV.Rows[i]["PASSWORD"],
                                       false
                                    );
                                }
                            }
                            else
                            {
                                Console.WriteLine("index = -1");
                            }
                        }
                        else
                        {
                            // Thêm mới
                            Console.WriteLine(dtSV.Rows[i]["MASV"] + " - " + i);

                            dt.Rows.Add(dtSV.Rows[i]["MASV"].ToString().ToUpper(),
                                   formatName(dtSV.Rows[i]["HO"].ToString()),
                                   formatWord(dtSV.Rows[i]["TEN"].ToString().Trim()),
                                   dtSV.Rows[i]["PHAI"],
                                   dtSV.Rows[i]["DIACHI"],
                                   convertDate(dtSV.Rows[i]["NGAYSINH"].ToString()),
                                   maLop,
                                   dtSV.Rows[i]["DANGHIHOC"],
                                   dtSV.Rows[i]["PASSWORD"],
                                   true
                            );
                        }

                        
                    }


                    SqlParameter param = new SqlParameter();
                    param.SqlDbType = SqlDbType.Structured;
                    param.TypeName = "dbo.TYPE_SINHVIEN";
                    param.ParameterName = "@SV";
                    param.Value = dt;

                    Program.Connect();
                    try
                    {
                        SqlCommand sqlCmd = new SqlCommand("SP_IU_SV", Program.conn);
                        sqlCmd.Parameters.Clear();
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.Parameters.Add(param);
                        sqlCmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if(ex.State == 18)
                        {
                            string msg = ex.Message.Trim();
                            string[] list = msg.Split(' ');

                            MessageBox.Show(String.Format("Lỗi ghi sinh viên: {0} thành công \n {1} lỗi : {2}", dt.Rows.Count-list.Length, list.Length, ex.Message), "Thông báo: ", MessageBoxButtons.OK);

                            loadDSSV(maLop);

                            int i = 0, j = 0;

                            int focusPos = dtSV.Rows.Count;

                            while (j < list.Length)
                            {
                                while (dt.Rows[i]["MASV"].ToString() != list[j]) i++;

                                dtSV.Rows.Add(dt.Rows[i]["MASV"], dt.Rows[i]["HO"],
                                    dt.Rows[i]["TEN"], dt.Rows[i]["PHAI"],
                                    dt.Rows[i]["DIACHI"], convertDate(dt.Rows[i]["NGAYSINH"].ToString()),
                                    dt.Rows[i]["DANGHIHOC"], dt.Rows[i]["PASSWORD"]);

                                i++; j++;
                            }

                            gvSV.CurrentCell = gvSV.Rows[focusPos].Cells["MASV"];
                            gvSV.BeginEdit(true);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi ghi sinh viên: " + ex.Message, "Thông báo: ", MessageBoxButtons.OK);
                        }

                        return;
                    }

                    loadDSSV(maLop);
                    MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);


                    btnThem.Enabled = btnGhi.Enabled = btnXoa.Enabled = btnLoadDSSV.Enabled = gcLop.Enabled = btnReload.Enabled = true;
                    btnUndo.Enabled = gvSV.Enabled = panelLop.Enabled = false;
                }
                

            }
            
        }

        private int indexRow(DataTable dt, DataRow row)
        {
            int l = 0, r = dt.Rows.Count-1;
            while(l <= r)
            {
                int m = (l + r) / 2;
                if (dt.Rows[m]["MASV"].ToString() == row["MASV"].ToString()) return m;
                else if (dt.Rows[m]["MASV"].ToString().CompareTo(row["MASV"].ToString()) < 0) l = m + 1;
                else r = m - 1;
            }
            return -1;
        }

        private bool isSameRow(DataRow a, DataRow b)
        {
            return a.ItemArray.SequenceEqual(b.ItemArray);
            //for(int i=0; i<a.ItemArray.Length; i++)
            //{
            //    if (a[i] != b[i]) return false;
            //}
            //return true;
        }

        private String formatName(string name)
        {
            string[] list = name.Split(' ');
            string res = "";
            foreach(string s in list)
            {
                if(s.Length > 0) res += formatWord(s) + " ";
            }
            return res.Trim();
        }

        private String formatWord(string name)
        {
            if (name == null || name.Length == 0) return "";
            string res = name.Substring(0, 1).ToUpper();
            if(name.Length > 1) res += name.Substring(1).ToLower();

            return res;
        }

        //private void connectLoginSite()
        //{
        //    Program.server = curServer;
        //    Program.mLogin = curLogin;
        //    Program.pass = curPass;

        //    Program.Connect();
        //}

        /**
         * date: dd/MM/yyyy
         * @return  MM/dd/yyyy
         */
        private string convertDate(string date)
        {
            if (date == null || date == "") return null;
            string[] s = date.Split('/');
            if (s.Length < 3) return null;
            Console.WriteLine(date + " " + s.Length);
            return s[1] + '/' + s[0] + '/' + s[2];
        }

    }
}