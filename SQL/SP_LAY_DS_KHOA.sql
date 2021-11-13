USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LAY_DS_KHOA]    Script Date: 13/11/2021 4:07:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_LAY_DS_KHOA]
as begin
select * from [dbo].[V_DS_PHANMANH] where TENPM <> 'HOCPHI';
end
GO


