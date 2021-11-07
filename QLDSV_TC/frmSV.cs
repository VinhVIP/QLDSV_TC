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
    public partial class frmSV : DevExpress.XtraEditors.XtraForm
    {

        private String maKhoa;
        private int lastPosition;

        public frmSV()
        {
            InitializeComponent();
        }

        private void frmSV_Load(object sender, EventArgs e)
        {
            DS_SV.EnforceConstraints = false;

            this.LOPTableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTableAdapter.Fill(this.DS_SV.LOP);

            this.SVTableAdapter.Connection.ConnectionString = Program.connString;
            this.SVTableAdapter.Fill(this.DS_SV.SINHVIEN);

            comboKhoa.DataSource = Program.bindingSourcePM;
            comboKhoa.DisplayMember = "TENPM";
            comboKhoa.ValueMember = "TENSERVER";

            comboKhoa.SelectedIndex = Program.mKhoa;
            comboKhoa.Enabled = Program.role == "PGV";

            maKhoa = comboKhoa.Text;

            this.ContextMenuStrip = contextMenuStrip1;

            initState();
        }

        private void initState()
        {
            btnUndo.Enabled = false;

            panelLop.Enabled = false;

            gcLOP.Enabled = true;
        }

        private void comboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                return;
            }

            Program.server = comboKhoa.SelectedValue.ToString();

            if (comboKhoa.SelectedIndex != Program.mKhoa)
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
                LOPTableAdapter.Connection.ConnectionString = Program.connString;
                LOPTableAdapter.Fill(DS_SV.LOP);

                SVTableAdapter.Connection.ConnectionString = Program.connString;
                SVTableAdapter.Fill(DS_SV.SINHVIEN);

                maKhoa = comboKhoa.Text;

                initState();
            }
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            int removePos = bdsSV.Position;
            if(removePos != -1)
            {
                bdsSV.RemoveAt(removePos);
            }

     
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            bdsSV.AddNew();

            // gcSV.Rows.Add("D21", "N21", "Tran", "Vinh", true, "HCM", "01/01/2000", false, "");

            DataView dv = (DataView)gcSV.DataSource;

            DataTable dataTable = ((DataView)gcSV.DataSource).Table;

            DataRow drToAdd = dataTable.NewRow();

            drToAdd["MALOP"] = "Value1";
            drToAdd["MASV"] = "Value2";
            drToAdd["HO"] = "Value2";
            drToAdd["TEN"] = "Value2";
            drToAdd["PHAI"] = true;
            drToAdd["DIACHI"] = "Value2";
            drToAdd["NGAYSINH"] = "01/01/2000";
            drToAdd["DANGHIHOC"] = false;
            drToAdd["PASSWORD"] = "Value2";

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.AddNew();

            gcLOP.Focus();
            txtMaKhoa.Text = maKhoa;

            lastPosition = bdsLOP.Position;

            btnThem.Enabled = btnXoa.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled =  btnUndo.Enabled = true;

            gcLOP.Enabled = false;
            panelLop.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //// Kiểm tra các ràng buộc
            //if (txtMaLop.Text.Trim() == "")
            //{
            //    MessageBox.Show("Mã lớp không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
            //    txtMaLop.Focus();
            //    return;
            //}
            //if (txtTenLop.Text.Trim() == "")
            //{
            //    MessageBox.Show("Tên lớp không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
            //    txtTenLop.Focus();
            //    return;
            //}
            //if (txtKhoaHoc.Text.Trim() == "")
            //{
            //    MessageBox.Show("Khóa học không được bỏ trống!", "Thông báo", MessageBoxButtons.OK);
            //    txtKhoaHoc.Focus();
            //    return;
            //}

            //// Kiêm tra thêm / hiệu chỉnh
            //if (lastAction == "add")
            //{
            //    if (isMaLopExists(txtMaLop.Text.Trim())) return;

            //    if (Program.ConnectPublisher() == 1)
            //    {
            //        if (isMaLopExists(txtMaLop.Text.Trim())) return;
            //    }
            //    Program.Connect();
            //}
            //else if (lastAction == "edit")
            //{

            //}

            try
            {
                bdsLOP.EndEdit();
                bdsLOP.ResetCurrentItem();
                LOPTableAdapter.Connection.ConnectionString = Program.connString;
                LOPTableAdapter.Update(DS_SV.LOP);

                bdsSV.EndEdit();
                bdsSV.ResetCurrentItem();
                SVTableAdapter.Connection.ConnectionString = Program.connString;
                SVTableAdapter.Update(DS_SV.SINHVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi : " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);

            gcLOP.Enabled = true;
            panelLop.Enabled = false;

        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LOPTableAdapter.Fill(DS_SV.LOP);
                SVTableAdapter.Fill(DS_SV.SINHVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLOP.CancelEdit();
            bdsLOP.RemoveAt(bdsLOP.Count - 1);
                
            gcLOP.Enabled = true;
            panelLop.Enabled = false;

            btnUndo.Enabled = false;
            btnThem.Enabled =  btnXoa.Enabled = btnReload.Enabled = true;
        }

        private bool isMaLopExists(String maLop)
        {
            Program.ExecSqlDataReader("SP_TimLop", CommandType.StoredProcedure, new[] {
                new SqlParameter("@malop", SqlDbType.NVarChar){Value=maLop}
            });

            if (Program.reader.Read())
            {
                MessageBox.Show("Mã lớp đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                txtMaLop.Focus();
                Program.reader.Close();
                return true;
            }

            Program.reader.Close();
            return false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsSV.Count > 0)
            {
                MessageBox.Show("Lớp đã có sinh viên nên không thể xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn thực sự muốn xóa lớp này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                String maLop = "";
                try
                {
                    maLop = ((DataRowView)bdsLOP[bdsLOP.Position])["MALOP"].ToString();
                    bdsLOP.RemoveCurrent();
                    LOPTableAdapter.Connection.ConnectionString = Program.connString;
                    LOPTableAdapter.Update(DS_SV.LOP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    LOPTableAdapter.Fill(DS_SV.LOP);
                    bdsLOP.Position = bdsLOP.Find("MALOP", maLop);
                }

            }

            if (bdsLOP.Count == 0) btnXoa.Enabled = false;
        }
    }
}