using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC
{
    public partial class Xrpt_InDSHP_LOP : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_InDSHP_LOP(String maLop, String nienKhoa, int hocKy)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maLop;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = nienKhoa;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = hocKy;
            this.sqlDataSource1.Fill();
            

        }
        public void setInfo(string maLop, string Khoa, Int64 tong)
        {
            lblMaLop.Text = maLop.Trim();
            lblKhoa.Text = Khoa.Trim();

            lblTongDaDong.Text = Program.NumberToText(tong);
            
        }
        
         
    }
}
