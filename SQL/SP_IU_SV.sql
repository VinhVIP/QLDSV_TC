USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_IU_SV]    Script Date: 13/11/2021 4:06:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_IU_SV]
	@SV [dbo].[TYPE_SINHVIEN] READONLY
as begin
merge into SINHVIEN as Target
	using (select MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, DANGHIHOC, PASSWORD, MALOP from @SV) as Source
	on Target.MASV=Source.MASV
	when matched then
		update set Target.HO=Source.HO,
					Target.TEN=Source.TEN,
					Target.PHAI=Source.PHAI,
					Target.DIACHI=Source.DIACHI,
					Target.NGAYSINH=Source.NGAYSINH,
					Target.DANGHIHOC=Source.DANGHIHOC,
					Target.PASSWORD=Source.PASSWORD,
					Target.MALOP=Source.MALOP
	when not matched then
		insert (MASV, HO, TEN, PHAI, DIACHI, NGAYSINH, DANGHIHOC, PASSWORD, MALOP)
		values (Source.MASV, Source.HO, Source.TEN, Source.PHAI, Source.DIACHI, Source.NGAYSINH, Source.DANGHIHOC, Source.PASSWORD, Source.MALOP);
end;
GO


