USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LayDSPM]    Script Date: 13/10/2021 10:28:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_LayDSPM]
AS
BEGIN
	select * from [dbo].[V_DS_PHANMANH]
END
GO


