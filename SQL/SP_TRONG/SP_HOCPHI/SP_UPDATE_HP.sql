USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_UPDATE_HP]    Script Date: 12/6/2021 6:40:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SP_UPDATE_HP]
	@TIENHOCPHI TYPE_HOCPHI READONLY
as begin
	merge into HOCPHI as Target
	using (select MASV, NIENKHOA, HOCKY, HOCPHI from @TIENHOCPHI) as Source
	on Target.MASV=Source.MASV and Target.NIENKHOA=Source.NIENKHOA and Target.HOCKY=Source.HOCKY
	when matched then
		update set Target.HOCPHI=Source.HOCPHI;
end;

GO

