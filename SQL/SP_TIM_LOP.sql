USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_TIM_LOP]    Script Date: 13/11/2021 11:11:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_TIM_LOP]
 @malop nchar(10)
as
BEGIN
	SELECT * FROM LOP WHERE MALOP=@malop
END

GO


