USE [QLDSV_TC]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- LẤY NIÊN KHOA (MẶC ĐỊNH) ĐỂ HIỆN LÊN MÀN HÌNH
create proc [dbo].[SP_LAY_NIENKHOA_HIENTAI]
as begin
	DECLARE @param AS INT
	DECLARE @current_year AS INT
	SET @param = 1
	SELECT @current_year = YEAR(GETDATE())
	select YEAR1 = @current_year, YEAR2 = @current_year + @param
end
GO