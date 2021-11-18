using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC
{
    public partial class Xrpt_BangDiemMonHoc1LTC : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_BangDiemMonHoc1LTC(string khoa, string nienKhoa, int hocKy, string maMH, string tenMH, int nhom)
        {
            InitializeComponent();

            this.sqlDataSource1.Connection.ConnectionString = Program.connString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = nienKhoa;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = hocKy;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = maMH;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = nhom;

            this.labelKhoa.Text = khoa;
            this.labelNK.Text = nienKhoa;
            this.labelHK.Text = hocKy.ToString();
            this.labelMH.Text = tenMH;
            this.labelNhom.Text = nhom.ToString();

            this.sqlDataSource1.Fill();

        }

    }
}
