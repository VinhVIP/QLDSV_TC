using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC
{
    public partial class Xrpt_DSSV_1LTC_new : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_DSSV_1LTC_new(String nienKhoa, String hocKy, String khoa, String monhoc, String nhom, String maLTC)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = int.Parse(maLTC);

            this.labelKhoa.Text = khoa;
            this.labelNK.Text = nienKhoa;
            this.labelHK.Text = hocKy;
            this.labelMH.Text = monhoc;
            this.labelNhom.Text = nhom;

            this.sqlDataSource1.Fill();
        }

    }
}
