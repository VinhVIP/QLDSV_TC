USE [QLDSV_TC]
GO

/****** Object:  StoredProcedure [dbo].[SP_SUM_HP_LOP]    Script Date: 12/6/2021 6:40:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[SP_SUM_HP_LOP]
	@MALOP		nChar(10),
	@NIENKHOA	nchar(9),
	@HOCKY		Int
as begin
	select ISNULL(SUM(CT.SOTIENDONG),0) as Tong
	from (select MASV, SOTIENDONG  from CT_DONGHOCPHI where NIENKHOA=@NIENKHOA and HOCKY=@HOCKY) as CT,
	(select SVL.MASV from	
				(select MASV from SINHVIEN
				where MALOP=@MALOP AND DANGHIHOC ='FALSE') as SVL,
				(SELECT DISTINCT MASV FROM LINK0.QLDSV_TC.DBO.DANGKY AS DK,
						(SELECT MALTC FROM LINK0.QLDSV_TC.DBO.LOPTINCHI WHERE NIENKHOA = @NIENKHOA AND HOCKY =@HOCKY AND HUYLOP = 'FALSE') AS LTC
				WHERE DK.MALTC =LTC.MALTC AND DK.HUYDANGKY ='FALSE') as SVDK
		where SVL.MASV =SVDK.MASV) as SV
	where CT.MASV = SV.MASV				
	
	
END;

GO

