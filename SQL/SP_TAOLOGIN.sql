USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_TAOLOGIN]    Script Date: 13/11/2021 4:09:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_TAOLOGIN]
  @LGNAME VARCHAR(50),
  @PASS VARCHAR(50),
  @USERNAME VARCHAR(50),
  @ROLE VARCHAR(50)
AS
  DECLARE @RET INT
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'QLDSV_TC'
  IF (@RET =1)  -- LOGIN NAME BI TRUNG
     RETURN 1
 
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
	BEGIN
		EXEC SP_DROPLOGIN @LGNAME
		RETURN 2
	END

  EXEC sp_addrolemember @ROLE, @USERNAME

  IF @ROLE= 'PGV' OR @ROLE= 'KHOA' OR @ROLE='PKT'
	BEGIN 
		EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
		EXEC sp_addsrvrolemember @LGNAME, 'ProcessAdmin'
	END
  ELSE IF @ROLE = 'SV'
	BEGIN
		EXEC sp_addsrvrolemember @LGNAME, 'public'
	END
RETURN 0  -- THANH CONG
GO


