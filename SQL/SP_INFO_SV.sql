USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_INFO_SV]    Script Date: 17/11/2021 11:37:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_INFO_SV]
	@masv nchar(10)
as begin
	select HO+' '+TEN as HOTEN, RTRIM(LOP.MALOP)+' - '+TENLOP as LOP
	from SINHVIEN, LOP
	where MASV=@masv and SINHVIEN.MALOP=LOP.MALOP;
end;
GO


