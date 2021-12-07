USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_HPDADONG]    Script Date: 12/6/2021 6:24:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE proc [dbo].[SP_HPDADONG]
@MASV nchar(10),
@NIENKHOA nchar(9),
@HOCKY INT
as begin
	IF EXISTS (SELECT * FROM CT_DONGHOCPHI WHERE MASV=@MASV AND NIENKHOA =@NIENKHOA AND HOCKY =@HOCKY)
		SELECT SUM(SOTIENDONG) FROM CT_DONGHOCPHI WHERE MASV=@MASV AND NIENKHOA =@NIENKHOA AND HOCKY =@HOCKY;
	ELSE
		RETURN 0;
end;
GO

