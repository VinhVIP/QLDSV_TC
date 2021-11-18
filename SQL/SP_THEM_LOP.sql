USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_THEM_LOP]    Script Date: 17/11/2021 11:37:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_THEM_LOP]
	@malop nchar(10),
	@tenlop	nvarchar(50),
	@khoahoc nchar(9),
	@makhoa	nchar(10)
as begin
	if (exists(select MALOP from LOP where MALOP=@malop) or exists(select MALOP from LINK1.QLDSV_TC.dbo.LOP where MALOP=@malop))
		RAISERROR ('Mã lớp bị trùng, vui lòng kiểm tra lại!', 11, 1);
	else 
		INSERT INTO LOP (MALOP, TENLOP, KHOAHOC, MAKHOA) values (@malop, @tenlop, @khoahoc, @makhoa);
end
GO


