USE [QLDSV_TC]
GO
/****** Object:  StoredProcedure [dbo].[SP_IU_SV]    Script Date: 24/11/2021 9:14:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_IU_SV] @SV [dbo].[TYPE_SINHVIEN] READONLY
as begin
	declare @msg nvarchar(MAX),
		@masv nchar(10), @ho nvarchar(50), @ten nvarchar(10), @phai bit, @diachi nvarchar(100), @ngaysinh date,
		@danghihoc bit, @malop nchar(10), @password nvarchar(40), @new bit;
	
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
		if @new = 1 -- Thêm mới
			begin
				if exists(select TEN from SINHVIEN where MASV=@masv) or 
					exists(select TEN from LINK1.QLDSV_TC.dbo.SINHVIEN where MASV=@masv)
					set @msg = @msg + ' ' + @masv;
				else
					insert into SINHVIEN (MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, DANGHIHOC, PASSWORD, MALOP)
						values (@masv, @ho, @ten, @phai, @diachi, @ngaysinh, @danghihoc, @password, @malop);
			end
		else	-- Hiệu chỉnh
			begin	
				if exists(select TEN from SINHVIEN where MASV=@masv)
					update SINHVIEN set HO=@ho, TEN=@ten, PHAI=@phai, DIACHI=@diachi, NGAYSINH=@ngaysinh, DANGHIHOC=@danghihoc, PASSWORD=@password, MALOP=@malop
					where MASV=@masv
				else 
					set @msg = @msg + ' ' + @masv;
			end;

		-- Nhảy đến dòng tiếp theo
		fetch next from cursor_sv into
			@masv, @ho, @ten, @phai, @diachi, @ngaysinh, @malop, @danghihoc, @password, @new;

	end;

	close cursor_sv;

	deallocate cursor_sv;

	if @msg <> ''
		RAISERROR (@msg, 11, 18);

	--merge into SINHVIEN as Target
	--using (select MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, DANGHIHOC, PASSWORD, MALOP, NEW from @SV) as Source
	--on Target.MASV=Source.MASV
	--when not matched then
	--	insert (MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, DANGHIHOC, PASSWORD, MALOP)
	--	values (Source.MASV, Source.HO, Source.TEN, Source.PHAI, Source.DIACHI, Source.NGAYSINH, Source.DANGHIHOC, Source.PASSWORD, Source.MALOP)
	--when matched and Source.NEW=0 then
	--	update set Target.HO=Source.HO,
	--				Target.TEN=Source.TEN,
	--				Target.PHAI=Source.PHAI,
	--				Target.DIACHI=Source.DIACHI,
	--				Target.NGAYSINH=Source.NGAYSINH,
	--				Target.DANGHIHOC=Source.DANGHIHOC,
	--				Target.PASSWORD=Source.PASSWORD,
	--				Target.MALOP=Source.MALOP;
end;