USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LAY_TEN_KHOA]    Script Date: 12/6/2021 6:39:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_LAY_TEN_KHOA]
@MAKHOA nChar(10)
as begin
select TENKHOA from KHOA where MAKHOA = @MAKHOA;
end

GO

