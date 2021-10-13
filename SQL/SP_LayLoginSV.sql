USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LayLoginSV]    Script Date: 13/10/2021 10:31:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_LayLoginSV]
	@masv nchar(10),
	@password nvarchar(40)
as
begin
	declare @makhoa nchar(10);

	set @makhoa = (select K.MAKHOA
	from
		SINHVIEN as S 
	JOIN LOP as L ON S.MASV=@masv and S.PASSWORD=@password and S.MALOP=L.MALOP
	JOIN KHOA as K on L.MAKHOA=K.MAKHOA)

	select 
		MSV=@masv,
		HOTEN=(select HO+' '+TEN from SINHVIEN where MASV=@masv),
		MAKHOA=@makhoa,
		-- TAIKHOAN='SV', 
		-- MATKHAU='123456', 
		TENSERVER=(select TENSERVER from V_DS_PHANMANH where TENPM=@makhoa)
	where @makhoa is not null

end
GO


