using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC
{
    public partial class Xrpt_DS_LTC : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_DS_LTC(String nienKhoa, String hocKy, String khoa)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = nienKhoa;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = hocKy;

            this.labelKhoa.Text = khoa;
            this.labelNK.Text = nienKhoa;
            this.labelHK.Text = hocKy.ToString();

            this.sqlDataSource1.Fill();
        }

    }
}
