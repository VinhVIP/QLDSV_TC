USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_PhieuDiemSV]    Script Date: 15/11/2021 11:36:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_PhieuDiemSV]
	@masv nchar(10)
as begin
	select MAMH, DIEM_CC, DIEM_GK, DIEM_CK, (DIEM_CC*0.1+DIEM_GK*0.3+DIEM_CK*0.6) DIEM_HM into #A
	from (select MALTC, DIEM_CC, DIEM_GK, DIEM_CK from DANGKY
		where MASV=@masv and HUYDANGKY='False') as DK
	left join LOPTINCHI LTC on LTC.MALTC=DK.MALTC and LTC.HUYLOP='False';

	select TENMH, MAX(DIEM_HM) as DIEM_HM into #B
	from #A A, MONHOC MH
	where A.MAMH=MH.MAMH
	group by TENMH
	order by TENMH;

	select TENMH, DIEM_CC, DIEM_GK, DIEM_CK, A.DIEM_HM
	from #A A, #B B
	where A.DIEM_HM=B.DIEM_HM;
end;
GO


