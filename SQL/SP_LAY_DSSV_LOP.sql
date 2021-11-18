USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LAY_DSSV_LOP]    Script Date: 13/11/2021 4:08:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_LAY_DSSV_LOP]
@malop nchar(10)
AS BEGIN
select MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, DANGHIHOC, PASSWORD from SINHVIEN where MALOP=@malop;
END
GO


