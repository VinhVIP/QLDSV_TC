USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_UPDATE_DIEM]    Script Date: 13/11/2021 4:09:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_UPDATE_DIEM]
	@DIEMTHI TYPE_DANGKY READONLY
as begin
	merge into DANGKY as Target
	using (select MALTC, MASV, DIEM_CC, DIEM_GK, DIEM_CK from @DIEMTHI) as Source
	on Target.MALTC=Source.MALTC and Target.MASV=Source.MASV
	when matched then
		update set Target.DIEM_CC=Source.DIEM_CC,
					Target.DIEM_GK=Source.DIEM_GK,
					Target.DIEM_CK=Source.DIEM_CK;
end;
GO


