﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLDSV_TC
{
    public partial class Xrpt_BangDiemTongKetLop : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_BangDiemTongKetLop(string maLop)
        {
            InitializeComponent();

            this.sqlDataSource1.Connection.ConnectionString = Program.connString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = maLop;

            this.labelLop.Text = maLop;

            this.sqlDataSource1.Fill();
        }


        public void setInfo(string maLop, string tenLop, string khoahoc, string khoa)
        {
            labelLop.Text = maLop.Trim() + " - " + tenLop;
            labelKhoaHoc.Text = khoahoc;
            labelKhoa.Text = khoa;
        }
    }
}
