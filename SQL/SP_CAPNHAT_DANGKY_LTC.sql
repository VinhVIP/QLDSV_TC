﻿USE [QLDSV_TC]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- LUU Y: CHO SINH VIEN DUOC PHEP TRUY CAP VAO SP NAY
create proc [dbo].[SP_CAPNHAT_DANGKY_LTC]
	@MASV NCHAR(10),
	@MALTC INT,
	@HUY BIT
as
begin
	BEGIN TRY
		IF(EXISTS(SELECT MALTC FROM DANGKY WHERE MALTC = @MALTC AND MASV = @MASV))
			UPDATE DANGKY
			SET HUYDANGKY = @HUY
			WHERE MALTC = @MALTC AND MASV = @MASV
		ELSE
			INSERT INTO DANGKY (MALTC, MASV, HUYDANGKY) VALUES (@MALTC, @MASV, @HUY)
	
	END TRY
	BEGIN CATCH
		RAISERROR ('Có lỗi xảy ra. Vui lòng kiểm tra lại', 11, 1);
	END CATCH
end
GO