USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_BangDiemTongKetLop]    Script Date: 16/11/2021 9:25:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_BangDiemTongKetLop] @malop nchar(10)
as begin
	select RTRIM(SV.MASV)+' - ' +HO+' '+TEN as INFO, TENMH, (DIEM_CC*0.1+DIEM_GK*0.3+DIEM_CK*0.6) AS DIEM 
	from (select MASV, HO, TEN from SINHVIEN where MALOP=@malop) as SV
	left join DANGKY DK on DK.HUYDANGKY='False' and DK.MASV=SV.MASV
	left join (select MALTC, TENMH from LOPTINCHI LTC, MONHOC MH where LTC.HUYLOP='False' and LTC.MAMH=MH.MAMH) as A
	on A.MALTC=DK.MALTC
end;
GO


