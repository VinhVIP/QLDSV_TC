using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV_TC
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private BarButtonItem lastButtonItem = null;    
        private UserControl lastControl = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin của user ở góc dưới màn hình
            txtLoginInfo.Caption = Program.fullName + " - " + Program.username + " - " + Program.role;
        }

        /**
         * Hiển thị UserControl được chọn khi click vào 1 buttonItem trên ribbon menu
         * Highlight buttonItem được chọn và bỏ highlight những buttonItem khác
         * 
         * @param control       UserControl cần được hiển thị
         * @param buttonItem    item trên ribbon menu được click
         */
        private void showUserControl(UserControl control, BarButtonItem buttonItem)
        {
            // Nếu chọn lại buttonItem cũ thì k làm gì hết
            if (lastButtonItem != null && lastButtonItem.Equals(buttonItem)) return;

            // Giải phóng vùng nhớ của UserControl trước đó
            if (lastControl != null) lastControl.Dispose();

            // Xóa vùng vẽ, và vẽ UserControl lên panel
            panel.Controls.Clear();
            panel.Dock = DockStyle.Fill;
            control.Dock = DockStyle.Fill;
            panel.Controls.Add(control);

            // Đổi màu cho buttonItem
            buttonItem.ItemAppearance.Normal.BackColor = Color.Snow;
            if (lastButtonItem != null) lastButtonItem.ItemAppearance.Normal.BackColor = Color.Gainsboro;

            lastButtonItem = buttonItem;
            lastControl = control;
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmLogin().Show();
            this.Close();
        }

        private void btnNhapLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            showUserControl(new frmNhapLop(), btnNhapLop);
        }

        private void btnNhapMH_ItemClick(object sender, ItemClickEventArgs e)
        {
            showUserControl(new frmNhapMH(), btnNhapMH);
        }

        private void btnTaoTK_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.role.Equals("SV")) return;

            showUserControl(new frmTaoTK(), btnTaoTK);
        }
    }
}