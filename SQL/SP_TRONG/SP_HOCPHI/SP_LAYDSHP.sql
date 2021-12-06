USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LAYDSHP]    Script Date: 12/6/2021 6:39:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_LAYDSHP]
	@masv nchar(10)
as begin
select NIENKHOA, HOCKY, HOCPHI FROM HOCPHI WHERE MASV = @masv;
end;


GO

