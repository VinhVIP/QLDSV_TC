using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC
{
    public partial class Xrpt_PhieuDiemSV : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_PhieuDiemSV(string maSV)
        {
            InitializeComponent();

            this.sqlDataSource1.Connection.ConnectionString = Program.connString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maSV;


            this.labelMASV.Text = maSV;

            this.sqlDataSource1.Fill();
        }

        public void setInfo(string hoTen, string lop, string khoa)
        {
            labelHoTen.Text = hoTen;
            labelLop.Text = lop;
            labelKhoa.Text = khoa;
        }

    }
}
