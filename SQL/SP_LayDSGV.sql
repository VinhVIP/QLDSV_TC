USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LayDSGV]    Script Date: 13/10/2021 4:40:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_LayDSGV] as 
begin
	select MAGV, (TRIM(MAGV)+' - '+HO+' '+TEN) as HOTEN from GIANGVIEN
end
GO


