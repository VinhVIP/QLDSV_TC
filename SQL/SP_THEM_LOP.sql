USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_THEM_LOP]    Script Date: 24/11/2021 3:35:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_THEM_LOP]
	@malop nchar(10),
	@tenlop	nvarchar(50),
	@khoahoc nchar(9),
	@makhoa	nchar(10)
as begin
	declare @msg nvarchar(MAX);
	declare @check bit;
	set @msg = N'Mã lớp bị trùng, vui lòng kiểm tra lại!';
	set @check = 0;

	if exists(select MALOP from LOP where MALOP=@malop) 
		set @check = 1;
	else begin
		begin try
			if exists(select MALOP from LINK1.QLDSV_TC.dbo.LOP where MALOP=@malop)
				set @check = 1;
		end try
		begin catch
			if exists(select MALOP from LINK0.QLDSV_TC.dbo.LOP where MALOP=@malop)
				set @check = 1;
		end catch
	end	

	if @check = 0 
		INSERT INTO LOP (MALOP, TENLOP, KHOAHOC, MAKHOA) values (@malop, @tenlop, @khoahoc, @makhoa);
	else 
		RAISERROR (@msg, 11, 1);

	--if (exists(select MALOP from LOP where MALOP=@malop) or exists(select MALOP from LINK1.QLDSV_TC.dbo.LOP where MALOP=@malop))
	--	RAISERROR ('Mã lớp bị trùng, vui lòng kiểm tra lại!', 11, 1);
	--else 
	--	INSERT INTO LOP (MALOP, TENLOP, KHOAHOC, MAKHOA) values (@malop, @tenlop, @khoahoc, @makhoa);
end
GO


