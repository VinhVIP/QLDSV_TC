USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_DANGNHAP]    Script Date: 13/10/2021 10:26:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_DANGNHAP]
	@TENLOGIN NVARCHAR (50)
AS
BEGIN
	DECLARE @TENUSER NVARCHAR(50)

	SELECT @TENUSER=NAME FROM sys.sysusers WHERE sid = SUSER_SID(@TENLOGIN)
 
	SELECT USERNAME = @TENUSER, 
		HOTEN = (SELECT HO + ' '+ TEN FROM GIANGVIEN  WHERE MAGV = @TENUSER),
		TENNHOM = NAME
	FROM sys.sysusers 
	WHERE UID = (SELECT GROUPUID 
				FROM SYS.SYSMEMBERS
				WHERE MEMBERUID = (SELECT UID FROM sys.sysusers WHERE NAME=@TENUSER))
END
GO

