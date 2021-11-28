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
    public partial class frmMH : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        public frmMH()
        {
            InitializeComponent();
        }

        

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS_MH);

        }

        private void frmMH_Load(object sender, EventArgs e)
        {
            DS_MH.EnforceConstraints = false;
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connString;
            this.MONHOCTableAdapter.Fill(this.DS_MH.MONHOC);
            this.LOPTINCHITableAdapter.Connection.ConnectionString = Program.connString;
            this.LOPTINCHITableAdapter.Fill(this.DS_MH.LOPTINCHI);
            

        }

        private void btn_ThemMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsMH.Position;
            panelControl1.Enabled = true;
            bdsMH.AddNew();

            btn_ThemMH.Enabled = btn_DelMH.Enabled = btn_Reload.Enabled = btn_Exit.Enabled = false;
            btn_SaveMH.Enabled = btn_Undo.Enabled = true;
            gcMONHOC.Enabled = false;
        }
        private void btn_DelMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String mamh = "";
            if(bdsLTC.Count> 0)
            {
                MessageBox.Show("Không thể xóa môn này vì đã tồn tại lớp tín chỉ", "", MessageBoxButtons.OK);
                return;
            }
            if(MessageBox.Show("Bạn có thật sự muốn xóa  môn học này? ","Xác nhận",
                MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                try
                {
                    mamh = ((DataRowView)bdsMH[bdsMH.Position])["MAMH"].ToString();
                    bdsMH.RemoveCurrent();
                    this.MONHOCTableAdapter.Connection.ConnectionString =Program.connString;
                    this.MONHOCTableAdapter.Update(this.DS_MH.MONHOC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy lối trong việc xóa môn học, bạn hãy thử lại\n" +ex.Message, "",
                        MessageBoxButtons.OK);
                    this.MONHOCTableAdapter.Fill(this.DS_MH.MONHOC);
                    bdsMH.Position = bdsMH.Find("MAMH", mamh);
                    return;
                }
            }
            if (bdsMH.Count == 0) btn_DelMH.Enabled = false;
        }

        private void btn_SaveMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được thiếu!", "", MessageBoxButtons.OK);
                txtMAMH.Focus();
                return;
            }
            if (isMaMHExists(txtMAMH.Text))
            {
                MessageBox.Show("Mã môn học đã tồn tại!", "", MessageBoxButtons.OK);
                txtMAMH.Focus();
                return;
            }
            if (txtTENMH.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn học không được thiếu!", "", MessageBoxButtons.OK);
                txtTENMH.Focus();
                return;
            }
            if (isTenMHExists(txtTENMH.Text))
            {
                MessageBox.Show("Tên môn học đã tồn tại!", "", MessageBoxButtons.OK);
                txtTENMH.Focus();
                return;
            }
            if (txtSOTIETLT.Text.Trim() == "")
            {
                MessageBox.Show("Số tiết lý thuyết không được thiếu!", "", MessageBoxButtons.OK);
                txtSOTIETLT.Focus();
                return;
            }

            foreach (Char c in txtSOTIETLT.Text)
            {
                if (!Char.IsDigit(c))
                {
                    MessageBox.Show("Số tiết lý thuyết phải là 1 số nguyên!", "", MessageBoxButtons.OK);
                    txtSOTIETLT.Focus();
                    return;
                }
            }
            if (txtSOTIETTH.Text.Trim() == "")
            {
                MessageBox.Show("Số tiết thực hành không được thiếu!", "", MessageBoxButtons.OK);
                txtSOTIETTH.Focus();
                return;
            }
            foreach (Char c in txtSOTIETTH.Text)
            {
                if (!Char.IsDigit(c))
                {
                    MessageBox.Show("Số tiết thực hành phải là 1 số nguyên!", "", MessageBoxButtons.OK);
                    txtSOTIETLT.Focus();
                    return;
                }
            }
            
            int checkTongST = (Int32.Parse(txtSOTIETTH.Text) + Int32.Parse(txtSOTIETLT.Text)) % 15;
            if (checkTongST != 0)
            {
                MessageBox.Show("Tổng tiết lý thuyết và thực hành phải là bội của số 15!", "", MessageBoxButtons.OK);
                txtSOTIETTH.Focus();
                return;
            }

            try
            {
                bdsMH.EndEdit();
                bdsMH.ResetCurrentItem();
                MONHOCTableAdapter.Connection.ConnectionString = Program.connString;
                MONHOCTableAdapter.Update(DS_MH.MONHOC);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi : " + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Ghi thành công!", "Thông báo", MessageBoxButtons.OK);
            gcMONHOC.Enabled = true;
            btn_ThemMH.Enabled = btn_DelMH.Enabled = btn_Reload.Enabled = btn_Exit.Enabled = true;
            btn_SaveMH.Enabled = btn_Undo.Enabled = false;
        }

        private void btn_Undo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (btn_ThemMH.Enabled == false)
            {
                bdsMH.CancelEdit();
                bdsMH.RemoveCurrent();
            }
            bdsMH.Position = vitri;
            gcMONHOC.Enabled = true;
            panelControl1.Enabled = false;
            btn_ThemMH.Enabled = btn_DelMH.Enabled = btn_Reload.Enabled = btn_Exit.Enabled = true;
            btn_SaveMH.Enabled = btn_Undo.Enabled = false;
        }

        private void btn_Reload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.MONHOCTableAdapter.Fill(this.DS_MH.MONHOC);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            btn_ThemMH.Enabled = btn_DelMH.Enabled = btn_Reload.Enabled = btn_Exit.Enabled = btn_SaveMH.Enabled = btn_Undo.Enabled = true;
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private bool isMaMHExists(String maMH)
        {
            Program.ExecSqlDataReader("SP_TimMaMH", CommandType.StoredProcedure, new[] {
                new SqlParameter("@MAMH", SqlDbType.NChar){Value=maMH}
            });

            if (Program.reader.Read())
            {
                Program.reader.Close();
                return true;
            }

            Program.reader.Close();
            return false;
        }
        private bool isTenMHExists(String tenMH)
        {
            Program.ExecSqlDataReader("SP_TimTenMH", CommandType.StoredProcedure, new[] {
                new SqlParameter("@TENMH", SqlDbType.NVarChar){Value=tenMH}
            });

            if (Program.reader.Read())
            {
                Program.reader.Close();
                return true;
            }

            Program.reader.Close();
            return false;
        }

        private void gcMONHOC_Click(object sender, EventArgs e)
        {

        }
    }
}