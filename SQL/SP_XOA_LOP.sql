USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_XOA_LOP]    Script Date: 13/11/2021 4:10:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_XOA_LOP]
	@malop nchar(10)
as begin
	IF EXISTS (SELECT MASV from SINHVIEN where MALOP=@malop)
		RAISERROR ('Lớp đã có sinh viên', 11, 1);
	ELSE 
		DELETE FROM LOP WHERE MALOP=@malop;
end;
GO


