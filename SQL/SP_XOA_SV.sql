USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_XOA_SV]    Script Date: 13/11/2021 4:11:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_XOA_SV]
	@masv nchar(10)
as begin
	IF EXISTS (SELECT MASV from DANGKY where MASV=@masv)
		RAISERROR ('Sinh viên đã đăng ký LTC, không thể xóa!', 11, 1);
	ELSE
		DELETE FROM SINHVIEN WHERE MASV=@masv;
end
GO


