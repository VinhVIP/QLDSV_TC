USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_LAY_DSSV_DANGKY]    Script Date: 13/11/2021 4:08:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_LAY_DSSV_DANGKY]
	@MALTC INT
as begin
	select SV.MASV, HOTENSV=HO+' '+TEN, DIEM_CC, DIEM_GK, DIEM_CK
	from (select MASV, DIEM_CC, DIEM_GK, DIEM_CK from DANGKY where MALTC=@MALTC and HUYDANGKY='FALSE') DSDK,
	SINHVIEN SV
	where DSDK.MASV=SV.MASV
	end
GO

