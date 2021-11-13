USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LAY_DS_LTC]    Script Date: 13/11/2021 4:08:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_LAY_DS_LTC]
	@NK nvarchar(10),
	@HK int
as
begin
	select MALTC, TENMH, NHOM, HOTEN = HO +' '+TEN
	from (select MALTC, MAMH, NHOM, MAGV FROM LOPTINCHI 
		where NIENKHOA=@NK AND HOCKY=@HK AND HUYLOP='FALSE') LTC,
		MONHOC MH, GIANGVIEN GV
		where LTC.MAMH=MH.MAMH AND LTC.MAGV=GV.MAGV
end
GO


