using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class frmHocPhi : DevExpress.XtraEditors.XtraForm
    {
        private string maSV;
        private DataTable dtDSHP, dtCT_DHP;
        private int vitri_HP, vitri_CTHP;
        private bool luaChon;
        public frmHocPhi()
        {
            InitializeComponent();
            btnDongHP.Enabled = false;
            btnThemHP.Enabled = false;
            btnGhi.Enabled = false;
            btnSearch.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            gcCT_HP.DataSource = new DataTable();
            maSV = txtMASV.Text;

            if (maSV.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            Program.ExecSqlDataReader("SP_INFO_SV", CommandType.StoredProcedure, new[]
            {
                new SqlParameter("@masv", SqlDbType.NChar){Value=maSV}
            });

            if (Program.reader.Read())
            {

                txtTenSV.Text = Program.reader.GetString(0);
                txtMaLop.Text = Program.reader.GetString(1);

                Program.reader.Close();

            }
            else
            {
                MessageBox.Show("Sinh viên không tồn tại! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                Program.reader.Close();
                return;
            }
            load_dtDSHP();
            gridView1.OptionsBehavior.ReadOnly = true;
            btnThemHP.Enabled = true;
            btnDongHP.Enabled = false;
        }





        private void gcHOCPHI_Click(object sender, EventArgs e)
        {
        }

        private void btnThemHP_Click(object sender, EventArgs e)
        {
            luaChon = true;
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView1.AddNewRow();
            dtDSHP.Columns["HOCPHIDADONG"].ReadOnly = true;
            dtDSHP.Columns["HOCPHICANDONG"].ReadOnly = true;
            btnThemHP.Enabled = false;
            btnGhi.Enabled = true;

        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (luaChon)
            {
                vitri_HP = gridView1.RowCount - 1;
                
                string nienKhoa = dtDSHP.Rows[vitri_HP]["NIENKHOA"].ToString();
                
                if (nienKhoa.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập niên khóa!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (dtDSHP.Rows[vitri_HP]["HOCKY"].ToString().Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập học kỳ!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                foreach (Char c in dtDSHP.Rows[vitri_HP]["HOCKY"].ToString().Trim())
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("Học kì phải là 1 số nguyên dương!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                }
                int hocKy = int.Parse(dtDSHP.Rows[vitri_HP]["HOCKY"].ToString());
                if (hocKy < 0 || hocKy > 3)
                {
                    MessageBox.Show("Học kì phải là 1 số nguyên lớn hơn 0 và nhỏ hơn 4!", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                if (dtDSHP.Rows[vitri_HP]["HOCPHI"].ToString().Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập học phí!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                foreach (Char c in dtDSHP.Rows[vitri_HP]["HOCPHI"].ToString().Trim())
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("Học phí phải là 1 số nguyên dương!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                }
                int hocPhi = int.Parse(dtDSHP.Rows[vitri_HP]["HOCPHI"].ToString());
                if (hocPhi == 0)
                {
                    MessageBox.Show("Học phí phải là 1 số nguyên lớn hơn 0!", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                int check = Program.ExecSqlNonQuery("SP_THEMHP", CommandType.StoredProcedure, new[] {
                     new SqlParameter("@MASV", SqlDbType.NVarChar){Value=maSV},
                     new SqlParameter("@NIENKHOA", SqlDbType.NVarChar){Value=nienKhoa },
                     new SqlParameter("@HOCKY", SqlDbType.Int){Value=hocKy},
                     new SqlParameter("@HOCPHI", SqlDbType.Int){Value=hocPhi}
                 });
                 if (check == 1)
                  {
                     MessageBox.Show("Thêm học phí thành công!", "Thông báo", MessageBoxButtons.OK);
                     load_dtDSHP();
                    gridView1.OptionsBehavior.ReadOnly = true;
                    btnThemHP.Enabled = true;
                    btnDongHP.Enabled = false;
                    btnGhi.Enabled = false;
                }

                
            }
            else
            {
                vitri_CTHP = dtCT_DHP.Rows.Count - 1;
                string nienKhoa = dtDSHP.Rows[vitri_HP]["NIENKHOA"].ToString();
                int hocKy = int.Parse(dtDSHP.Rows[vitri_HP]["HOCKY"].ToString());
                DateTime ngayDong = DateTime.Parse(dtCT_DHP.Rows[vitri_CTHP]["NGAYDONG"].ToString());
                if (dtCT_DHP.Rows[vitri_CTHP]["SOTIENDONG"].ToString().Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập Số tiền đóng!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                foreach (Char c in dtCT_DHP.Rows[vitri_CTHP]["SOTIENDONG"].ToString().Trim())
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("Số tiền đóng phải là 1 số nguyên dương!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                }
                int soTienDong = int.Parse(dtCT_DHP.Rows[vitri_CTHP]["SOTIENDONG"].ToString());
                if (soTienDong == 0)
                {
                    MessageBox.Show("Số tiền đóng phải phải lớn hơn 0!", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                if (soTienDong > int.Parse(dtDSHP.Rows[vitri_HP]["HOCPHICANDONG"].ToString()))
                {
                    MessageBox.Show("Số tiền đóng phải nhỏ hơn hoặc bằng số tiền cần đóng!", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                int check = Program.ExecSqlNonQuery("SP_DONGHP", CommandType.StoredProcedure, new[] {
                        new SqlParameter("@MASV", SqlDbType.NVarChar){Value=maSV},
                        new SqlParameter("@NIENKHOA", SqlDbType.NVarChar){Value=nienKhoa },
                        new SqlParameter("@HOCKY", SqlDbType.Int){Value=hocKy},
                        new SqlParameter("@NGAYDONG", SqlDbType.DateTime){Value=ngayDong},
                         new SqlParameter("@SOTIENDONG", SqlDbType.Int){Value=soTienDong}
                    });
                if (check == 1)
                {
                    MessageBox.Show("Đóng học phí thành công!", "Thông báo", MessageBoxButtons.OK);
                    load_dtCTHP();
                    load_dtDSHP();
                    btnGhi.Enabled = false;
                    btnThemHP.Enabled = true;
                    btnDongHP.Enabled = false;
                }
                else
                {
                    load_dtCTHP();
                }
                
                
                

            }
            
            

            
            
        }

        private void gridView1_Click(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            vitri_HP = gridView1.FocusedRowHandle;
            load_dtCTHP();
            
            if (int.Parse(dtDSHP.Rows[vitri_HP]["HOCPHICANDONG"].ToString()) < 1)
            {
                btnDongHP.Enabled = false;
            }
            else
            {
                btnDongHP.Enabled = true;
            }
            
        }

        private void btnDongHP_Click(object sender, EventArgs e)
        {
            
            dtCT_DHP.Rows.Add();
            vitri_CTHP = dtCT_DHP.Rows.Count - 1;
            DateTime now = DateTime.Now;
            dtCT_DHP.Rows[vitri_CTHP]["NGAYDONG"] = now.ToString("yyyy-MM-dd");
            dtCT_DHP.Rows[vitri_CTHP]["SOTIENDONG"] = int.Parse(dtDSHP.Rows[vitri_HP]["HOCPHICANDONG"].ToString()).ToString("0.");
            gcCT_HP.Columns[1].ReadOnly = false;
            for(int i= 0;i< dtCT_DHP.Rows.Count - 1; i++)
            {
                gcCT_HP.Rows[i].ReadOnly = true;
            }
            btnGhi.Enabled = true;
            btnDongHP.Enabled = false;
            btnThemHP.Enabled = false;
            luaChon = false;
        }

        private void load_dtDSHP()
        {
            String sql = "EXEC SP_LAYDSHP " + maSV;
            dtDSHP = Program.ExecSqlDataTable(sql);
            string nienKhoa;
            int hocKy, hocPhi, soTienDaDong, soTienCanDong;
            //String hocPhiDaDong;
            dtDSHP.Columns.Add("HOCPHIDADONG", typeof(int));
            dtDSHP.Columns.Add("HOCPHICANDONG", typeof(int));
            for (int i = 0; i < dtDSHP.Rows.Count; i++)
            {
                nienKhoa = dtDSHP.Rows[i]["NIENKHOA"].ToString();
                hocKy = int.Parse(dtDSHP.Rows[i]["HOCKY"].ToString());
                Program.ExecSqlDataReader("SP_HPDADONG", CommandType.StoredProcedure, new[] {
                        new SqlParameter("@MASV", SqlDbType.NVarChar){Value=maSV},
                        new SqlParameter("@NIENKHOA", SqlDbType.NVarChar){Value=nienKhoa },
                        new SqlParameter("@HOCKY", SqlDbType.Int){Value=hocKy}
                    });
                if (Program.reader.Read())
                {
                    dtDSHP.Rows[i]["HOCPHIDADONG"] = Program.reader.GetValue(0);
                    Program.reader.Close();
                }
                else
                {
                    dtDSHP.Rows[i]["HOCPHIDADONG"] = "0";
                    Program.reader.Close();
                }


                hocPhi = dtDSHP.Rows[i]["HOCPHI"].ToString().Length == 0 ? 0 : int.Parse(dtDSHP.Rows[i]["HOCPHI"].ToString());
                soTienDaDong = dtDSHP.Rows[i]["HOCPHIDADONG"].ToString().Length == 0 ? 0 : int.Parse(dtDSHP.Rows[i]["HOCPHIDADONG"].ToString());
                soTienCanDong = hocPhi - soTienDaDong;
                dtDSHP.Rows[i]["HOCPHICANDONG"] = soTienCanDong.ToString("0.");

            }
            gcHOCPHI.DataSource = dtDSHP;
        }

        private void load_dtCTHP()
        {
            string nienKhoa = dtDSHP.Rows[vitri_HP]["NIENKHOA"].ToString();
            int hocKy = int.Parse(dtDSHP.Rows[vitri_HP]["HOCKY"].ToString());
            String sql = "EXEC SP_CT_DONGHP '" + maSV + "', '" + nienKhoa + "', " + hocKy;
            dtCT_DHP = Program.ExecSqlDataTable(sql);
            //dtCT_DHP.Columns["NGAYDONG"].ReadOnly = true;
            //dtCT_DHP.Columns["SOTIENDONG"].ReadOnly = true;
            gcCT_HP.DataSource = dtCT_DHP;
            gcCT_HP.Columns[0].ReadOnly = true;
            gcCT_HP.Columns[1].ReadOnly = true;

        }
    }
}