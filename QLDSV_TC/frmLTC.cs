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
    public partial class frmLTC : DevExpress.XtraEditors.XtraForm
    {
        private String maLTCHientai;
        private int soUndo = 0;
        List<string> listKhoa = new List<string>();
        List<string> listMon = new List<string>();
        List<string> listGV = new List<string>();
        List<string> listSVTT = new List<string>();
        List<string> listNienkhoa1 = new List<string>();
        List<string> listNienkhoa2 = new List<string>();
        List<string> listHocky = new List<string>();
        List<string> listNhom = new List<string>();
        List<bool> listHuy = new List<bool>();
        // chức năng = 1: thêm, = 2: sửa, =-1: không thêm không sửa
        int chucnang=-1;
        // = 1: khoa, = 2: môn, = 3: giảng viên, = 4: svtt, = 5: niên khóa 1, = 6: niên khóa 2
        // =7: hoc kỳ, = 8: nhóm, = 9: hủy
        List<int> listUndo = new List<int>();

        // Lưu giá trị gốc để undo về ban đầu
        String rootKhoa = "";
        String rootMon="";
        String rootGV="";
        String rootSVTT="";
        String rootNienkhoa1="";
        String rootNienkhoa2="";
        String rootHocky = "";
        String rootNhom="";
        bool rootHuy = false;

        public frmLTC()
        {
            InitializeComponent();
        }

        private void frmLTC_Load(object sender, EventArgs e)
        {
            initData();
        }

        private void initData()
        {
            DSMon();
            DSKhoa();
            DSNienkhoa();
            DSHocKy();
            DSGV();
            initButton();
        }

        private void initButton()
        {
            btnLoadLTC.Enabled = btnThem.Enabled = true;
            btnXoa.Enabled = btnSua.Enabled = btnGhi.Enabled = btnUndo.Enabled = btnReload.Enabled = false;
        }

        private void DSKhoa()
        {
            String exec = "EXEC SP_LAY_DS_KHOA_2 @ROLE= '" + Program.role + "'";
            
            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable(exec);

            cbKhoa.DataSource = dt;
            cbKhoa.DisplayMember = "TENKHOA";
            cbKhoa.ValueMember = "MAKHOA";
            cbKhoa.SelectedIndex = 0;

            DataTable dt2 = Program.ExecSqlDataTable(exec);
            cbKhoaEdit.DataSource = dt2;
            cbKhoaEdit.DisplayMember = "TENKHOA";
            cbKhoaEdit.ValueMember = "MAKHOA";
            cbKhoaEdit.SelectedIndex = 0;
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

        private void DSMon()
        {
            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable("EXEC SP_LAY_DS_MONHOC");

            cbMon.DataSource = dt;
            cbMon.DisplayMember = "TENMH";
            cbMon.ValueMember = "MAMH";
            cbMon.SelectedIndex = 0;

            DataTable dt2 = Program.ExecSqlDataTable("EXEC SP_LAY_DS_MONHOC");

            cbMonhoc.DataSource = dt2;
            cbMonhoc.DisplayMember = "TENMH";
            cbMonhoc.ValueMember = "MAMH";
            cbMonhoc.SelectedIndex = 0;
        }

        private void DSNienkhoa()
        {
            if (Program.Connect() == 0) return;
            DataTable dt = Program.ExecSqlDataTable("EXEC SP_DS_NIENKHOA");
            cbNienkhoa.DataSource = dt;
            cbNienkhoa.DisplayMember = "NIENKHOA";
            cbNienkhoa.ValueMember = "NIENKHOA";
            cbNienkhoa.SelectedIndex = 0;
        }

        private void DSHocKy()
        {
            cbHocky.Items.Add("1");
            cbHocky.Items.Add("2");
            cbHocky.Items.Add("3");
            cbHocky.Items.Add("4");
            cbHocky.SelectedIndex = 0;

            cbHockyEdit.Items.Add("1");
            cbHockyEdit.Items.Add("2");
            cbHockyEdit.Items.Add("3");
            cbHockyEdit.Items.Add("4");
            cbHockyEdit.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadDSSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String exec = "EXEC SP_DS_LTC @NIENKHOA = '" + cbNienkhoa.SelectedValue.ToString() +
                "', @HOCKY = " + cbHocky.SelectedItem.ToString() +
                ", @MAMH = '" + cbMonhoc.SelectedValue.ToString() +
                "', @SERVER_HIENTAI = '" + Program.mKhoa +
                "', @SERVER_DICH = '" + cbKhoa.SelectedValue.ToString() + "'";
            
            tbLTC.DataSource = Program.ExecSqlDataTable(exec);

            btnGhi.Enabled = btnUndo.Enabled = btnReload.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnLoadLTC.Enabled = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tbLTC.Rows.Count - 1>0 && tbLTC.Rows.Count-1 > tbLTC.CurrentCell.RowIndex)
            {
                btnUndo.Enabled = btnGhi.Enabled = btnReload.Enabled = panelLTC.Enabled = true;
                lamMoiList();
                int index = tbLTC.CurrentCell.RowIndex;
                maLTCHientai = tbLTC.Rows[index].Cells[0].Value.ToString();

                cbKhoaEdit.SelectedValue = tbLTC.Rows[index].Cells[1].Value.ToString();
                rootKhoa = tbLTC.Rows[index].Cells[1].Value.ToString();

                cbMon.SelectedValue = tbLTC.Rows[index].Cells[2].Value.ToString();
                rootMon = tbLTC.Rows[index].Cells[2].Value.ToString();
                

                cbGV.SelectedValue = tbLTC.Rows[index].Cells[3].Value.ToString();
                rootGV = tbLTC.Rows[index].Cells[3].Value.ToString();
                
                txtNienKhoa1.Text = tbLTC.Rows[index].Cells[4].Value.ToString().Substring(0, 4);
                rootNienkhoa1 = tbLTC.Rows[index].Cells[4].Value.ToString().Substring(0, 4);

                txtNienKhoa2.Text = tbLTC.Rows[index].Cells[4].Value.ToString().Substring(5, 4);
                rootNienkhoa2 = tbLTC.Rows[index].Cells[4].Value.ToString().Substring(5, 4);

                cbHockyEdit.SelectedItem = tbLTC.Rows[index].Cells[5].Value.ToString();
                rootHocky = tbLTC.Rows[index].Cells[5].Value.ToString();

                txtNhom.Text = tbLTC.Rows[index].Cells[6].Value.ToString();
                rootNhom = tbLTC.Rows[index].Cells[6].Value.ToString();

                txtSVTT.Text = tbLTC.Rows[index].Cells[7].Value.ToString();
                rootSVTT = tbLTC.Rows[index].Cells[7].Value.ToString();

                checkboxHuy.Checked = (bool)tbLTC.Rows[index].Cells[8].Value;
                rootHuy = (bool)tbLTC.Rows[index].Cells[8].Value;

                ganGiaTriList();
                chucnang = 2;
            }
            
        }

        private void lamMoiList()
        {
            soUndo = 0;
            listGV.Clear();
            listHocky.Clear();
            listHuy.Clear();
            listKhoa.Clear();
            listMon.Clear();
            listNhom.Clear();
            listNienkhoa1.Clear();
            listNienkhoa2.Clear();
            listSVTT.Clear();
            listUndo.Clear();
        }

        private void ganGiaTriBanDau()
        {
            cbKhoaEdit.SelectedValue = rootKhoa;
            cbHockyEdit.SelectedItem = rootHocky;
            cbGV.SelectedValue = rootGV;
            cbMon.SelectedValue = rootMon;
            txtNhom.Text = rootNhom;
            txtNienKhoa1.Text = rootNienkhoa1;
            txtNienKhoa2.Text = rootNienkhoa2;
            txtSVTT.Text = rootSVTT;
            checkboxHuy.Checked = rootHuy;
        }

        private void ganGiaTriList()
        {
            listKhoa.Add(rootKhoa);
            listMon.Add(rootMon);
            listGV.Add(rootGV);
            listNienkhoa1.Add(rootNienkhoa1);
            listNienkhoa2.Add(rootNienkhoa2);
            listHocky.Add(rootHocky);
            listNhom.Add(rootNhom);
            listSVTT.Add(rootSVTT);
            listHuy.Add(rootHuy);
        }

        private void cbKhoaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chucnang != -1)
            {
                listKhoa.Add(cbKhoaEdit.SelectedValue.ToString());
                soUndo++;
                listUndo.Add(1);
            }
        }

        private void cbMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chucnang != -1)
            {
                listMon.Add(cbMon.SelectedValue.ToString());
                soUndo++;
                listUndo.Add(2);
            }
        }

        private void cbGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chucnang != -1)
            {
                listGV.Add(cbGV.SelectedValue.ToString());
                soUndo++;
                listUndo.Add(3);
            }
        }

        private void txtSVTT_EditValueChanged(object sender, EventArgs e)
        {
            if (chucnang != -1)
            {
                listSVTT.Add(txtSVTT.Text.ToString());
                soUndo++;
                listUndo.Add(4);
            }
        }

        private void txtNienKhoa1_EditValueChanged(object sender, EventArgs e)
        {
            if (chucnang != -1)
            {
                listNienkhoa1.Add(txtNienKhoa1.Text.ToString());
                soUndo++;
                listUndo.Add(5);
            }
        }

        private void txtNienKhoa2_EditValueChanged(object sender, EventArgs e)
        {
            if (chucnang != -1)
            {
                listNienkhoa2.Add(txtNienKhoa2.Text.ToString());
                soUndo++;
                listUndo.Add(6);
            }
        }

        private void cbHockyEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chucnang != -1)
            {
                listHocky.Add(cbHockyEdit.SelectedItem.ToString());
                soUndo++;
                listUndo.Add(7);
            }
        }

        private void txtNhom_EditValueChanged(object sender, EventArgs e)
        {
            if (chucnang != -1)
            {
                listNhom.Add(txtNhom.Text.ToString());
                soUndo++;
                listUndo.Add(8);
            }
        }

        private void checkboxHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (chucnang != -1)
            {
                listHuy.Add(checkboxHuy.Checked);
                soUndo++;
                listUndo.Add(9);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // = 1: khoa, = 2: môn, = 3: giảng viên, = 4: svtt, = 5: niên khóa 1, = 6: 
            // niên khóa 2 =7: hoc kỳ, = 8: nhóm, = 9: hủy
            if (soUndo <= 1)
            {
                ganGiaTriBanDau();
                soUndo = 1;
            }
            else
            {
                int last = listUndo.Last();
                listUndo.RemoveAt(listUndo.Count - 1);
                soUndo-=2;
                // khoa
                if (last == 1)
                {
                    listKhoa.RemoveAt(listKhoa.Count - 1);
                    cbKhoaEdit.SelectedValue = listKhoa.Last();
                    listKhoa.RemoveAt(listKhoa.Count - 1);
                }
                // mon
                else if(last == 2)
                {
                    listMon.RemoveAt(listMon.Count - 1);
                    cbMon.SelectedValue = listMon.Last();
                    listMon.RemoveAt(listMon.Count - 1);
                }
                // giang vien
                else if(last == 3)
                {
                    listGV.RemoveAt(listGV.Count - 1);
                    cbGV.SelectedValue = listGV.Last();
                    listGV.RemoveAt(listGV.Count - 1);
                }
                // sinh vien toi thieu
                else if(last == 4)
                {
                    listSVTT.RemoveAt(listSVTT.Count - 1);
                    txtSVTT.Text = listSVTT.Last();
                    listSVTT.RemoveAt(listSVTT.Count - 1);
                }
                // nien khoa 1
                else if(last == 5)
                {
                    listNienkhoa1.RemoveAt(listNienkhoa1.Count - 1);
                    txtNienKhoa1.Text = listNienkhoa1.Last();
                    listNienkhoa1.RemoveAt(listNienkhoa1.Count - 1);
                }
                // nien khoa 2
                else if(last == 6)
                {
                    listNienkhoa2.RemoveAt(listNienkhoa2.Count - 1);
                    txtNienKhoa2.Text = listNienkhoa2.Last();
                    listNienkhoa2.RemoveAt(listNienkhoa2.Count - 1);
                }
                // hoc ky
                else if(last == 7)
                {
                    listHocky.RemoveAt(listHocky.Count - 1);
                    cbHockyEdit.SelectedItem = listHocky.Last();
                    listHocky.RemoveAt(listHocky.Count - 1);
                }
                // nhom
                else if(last == 8)
                {
                    listNhom.RemoveAt(listNhom.Count - 1);
                    txtNhom.Text = listNhom.Last();
                    listNhom.RemoveAt(listNhom.Count - 1);
                }
                // huy
                else if(last == 9)
                {
                    listHuy.RemoveAt(listHuy.Count - 1);
                    checkboxHuy.Checked = listHuy.Last();
                    listHuy.RemoveAt(listHuy.Count - 1);
                }
                listUndo.RemoveAt(listUndo.Count - 1);
            }
            
            //listUndo.Add(soUndo++);
        }

        private void chinhGiaTriPhuongThucThem()
        {
            //
            cbGV.SelectedIndex = 0;
            rootGV = cbGV.SelectedValue.ToString();

            //
            rootHocky = "1";

            //
            rootHuy = false;

            //
            cbKhoaEdit.SelectedIndex = 0;
            rootKhoa = cbKhoaEdit.SelectedValue.ToString();

            //
            cbMon.SelectedIndex = 0;
            rootMon = cbMon.SelectedValue.ToString();

            //
            rootNhom = "1";

            //
            if (Program.Connect() == 0) return;

            Program.ExecSqlDataReader("SP_LAY_NIENKHOA_HIENTAI");

            Program.reader.Read();

            rootNienkhoa1 = Program.reader.GetInt32(0).ToString();
            rootNienkhoa2 = Program.reader.GetInt32(1).ToString();

            Program.reader.Close();

            //
            rootSVTT = "20";


            lamMoiList();
            ganGiaTriBanDau();
            ganGiaTriList();
            soUndo = 0;
            chucnang = 1;

            panelLTC.Enabled = btnGhi.Enabled = btnUndo.Enabled = btnReload.Enabled = btnLoadLTC.Enabled = true;
            btnXoa.Enabled = btnSua.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chinhGiaTriPhuongThucThem();
            //Console.WriteLine(listUndo.Last());
            //listUndo.RemoveAt(listUndo.Count-1);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lamMoiList();
            ganGiaTriBanDau();
            ganGiaTriList();
            soUndo = 0;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chucnang == 1)
            {
                try
                {
                    if (Program.ExecSqlNonQuery("SP_THEM_LTC", CommandType.StoredProcedure, new[] {
                    new SqlParameter("@NIENKHOA", SqlDbType.NChar){Value=txtNienKhoa1.Text.ToString()+"-"+txtNienKhoa2.Text.ToString()},
                    new SqlParameter("@HOCKY", SqlDbType.Int){Value=cbHockyEdit.SelectedItem.ToString()},
                    new SqlParameter("@MAMH", SqlDbType.NChar){Value=cbMon.SelectedValue.ToString()},
                    new SqlParameter("@NHOM", SqlDbType.Int){Value=txtNhom.Text.ToString()},
                    new SqlParameter("@MAGV", SqlDbType.NChar){Value=cbGV.SelectedValue.ToString()},
                    new SqlParameter("@SOSVTOITHIEU", SqlDbType.SmallInt){Value=txtSVTT.Text.ToString()},
                    new SqlParameter("@SERVER_HIENTAI", SqlDbType.NChar){Value=Program.mKhoa},
                    new SqlParameter("@SERVER_THEM", SqlDbType.NChar){Value=cbKhoaEdit.SelectedValue.ToString()},
                    }) == 1)
                    {
                        MessageBox.Show("Thêm lớp tín chỉ thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                    chinhGiaTriPhuongThucThem();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                }
            }
            else if(chucnang == 2)
            {
                try
                {
                    if (Program.ExecSqlNonQuery("SP_CAPNHAT_LTC", CommandType.StoredProcedure, new[] {
                    new SqlParameter("@NIENKHOA", SqlDbType.NChar){Value=txtNienKhoa1.Text.ToString()+"-"+txtNienKhoa2.Text.ToString()},
                    new SqlParameter("@HOCKY", SqlDbType.Int){Value=cbHockyEdit.SelectedItem.ToString()},
                    new SqlParameter("@MALTC", SqlDbType.Int){Value=maLTCHientai},
                    new SqlParameter("@MAMH", SqlDbType.NChar){Value=cbMon.SelectedValue.ToString()},
                    new SqlParameter("@NHOM", SqlDbType.Int){Value=txtNhom.Text.ToString()},
                    new SqlParameter("@MAGV", SqlDbType.NChar){Value=cbGV.SelectedValue.ToString()},
                    new SqlParameter("@SOSVTOITHIEU", SqlDbType.SmallInt){Value=txtSVTT.Text.ToString()},
                    new SqlParameter("@HUY", SqlDbType.Bit){Value=checkboxHuy.Checked.ToString()},
                    new SqlParameter("@SERVER_HIENTAI", SqlDbType.NChar){Value=Program.mKhoa},
                    new SqlParameter("@SERVER_DICH", SqlDbType.NChar){Value=cbKhoaEdit.SelectedValue.ToString()},
                    }) == 1)
                    {
                        MessageBox.Show("Thay đổi thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                    chinhGiaTriPhuongThucThem();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tbLTC.Rows.Count - 1 > 0 && tbLTC.Rows.Count - 1 > tbLTC.CurrentCell.RowIndex)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa bảng này không?", "Thông báo", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (Program.ExecSqlNonQuery("SP_XOA_LTC", CommandType.StoredProcedure, new[] {
                        new SqlParameter("@MALTC", SqlDbType.Int){Value=tbLTC.Rows[tbLTC.CurrentCell.RowIndex].Cells[0].Value.ToString()},
                        new SqlParameter("@SERVER_HIENTAI", SqlDbType.NChar){Value=Program.mKhoa},
                        new SqlParameter("@SERVER_THEM", SqlDbType.NChar){Value=cbKhoa.SelectedValue.ToString()},
                        }) == 1)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                        }
                        chinhGiaTriPhuongThucThem();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            
        }
    }
}