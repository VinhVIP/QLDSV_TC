USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_BangDiemMonHoc1LTC]    Script Date: 14/11/2021 11:14:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[SP_BangDiemMonHoc1LTC]
	@nienkhoa nchar(9),
	@hocky int,
	@mamh nchar(10),
	@nhom int
as begin
	select MALTC into #LTC
	from LOPTINCHI 
	where MAMH=@mamh and NIENKHOA=@nienkhoa and HOCKY=@hocky and NHOM=@nhom;

	select MASV, DIEM_CC, DIEM_GK, DIEM_CK into #DK
	from DANGKY DK, #LTC LTC
	where DK.HUYDANGKY='False' and DK.MALTC=LTC.MALTC;

	select SV.MASV, HO, TEN, DIEM_CC, DIEM_GK, DIEM_CK
	from SINHVIEN SV, #DK DK
	where SV.MASV=DK.MASV
	order by TEN, HO;
end;
GO


