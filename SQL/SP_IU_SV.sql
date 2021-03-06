USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_IU_SV]    Script Date: 24/11/2021 3:36:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_IU_SV] @SV [dbo].[TYPE_SINHVIEN] READONLY
as begin
	declare @msg nvarchar(MAX),
		@masv nchar(10), @ho nvarchar(50), @ten nvarchar(10), @phai bit, @diachi nvarchar(100), @ngaysinh date,
		@danghihoc bit, @malop nchar(10), @password nvarchar(40), @new bit;

	declare @check bit;
	set @msg = '';

	declare cursor_sv cursor
	for select MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, MALOP, DANGHIHOC, PASSWORD, NEW
	from @SV;

	open cursor_sv;

	-- Nhảy đến dòng đầu tiên
	fetch next from cursor_sv into
		@masv, @ho, @ten, @phai, @diachi, @ngaysinh, @malop, @danghihoc, @password, @new;

	while @@FETCH_STATUS = 0
	begin
		set @check = 0;		-- mặc định là k có lỗi

		if exists(select TEN from SINHVIEN where MASV=@masv) 
			set @check = 1;
		else begin
			begin try
				if exists(select TEN from LINK1.QLDSV_TC.dbo.SINHVIEN where MASV=@masv)
					set @check = 1;
			end try
			begin catch
				if exists(select TEN from LINK0.QLDSV_TC.dbo.SINHVIEN where MASV=@masv)
					set @check = 1;
			end catch
		end

		if @new = 0			-- Hiệu chỉnh
			if @check = 0	-- Chưa có trong csdl
				set @msg = @msg + ' ' + @masv;
			else			-- Đã có -> cập nhật
				update SINHVIEN set HO=@ho, TEN=@ten, PHAI=@phai, DIACHI=@diachi, NGAYSINH=@ngaysinh, DANGHIHOC=@danghihoc, PASSWORD=@password, MALOP=@malop
					where MASV=@masv;
		else				-- Thêm mới
			if @check = 0	-- chưa có -> thêm
				insert into SINHVIEN (MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, DANGHIHOC, PASSWORD, MALOP)
					values (@masv, @ho, @ten, @phai, @diachi, @ngaysinh, @danghihoc, @password, @malop);
			else			-- đã có -> lỗi
				set @msg = @msg + ' ' + @masv;
		
		
		-- Nhảy đến dòng tiếp theo
		fetch next from cursor_sv into
			@masv, @ho, @ten, @phai, @diachi, @ngaysinh, @malop, @danghihoc, @password, @new;

	end;

	close cursor_sv;

	deallocate cursor_sv;

	if @msg <> '' RAISERROR (@msg, 11, 18);
end;
GO


