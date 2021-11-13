/* TYPE phải tự query ở các site phân mảnh, k thể phân tán */
USE [QLDSV_TC]
GO

/****** Object:  UserDefinedTableType [dbo].[TYPE_DANGKY]    Script Date: 13/11/2021 11:09:52 PM ******/
CREATE TYPE [dbo].[TYPE_DANGKY] AS TABLE(
	[MALTC] [int] NULL,
	[MASV] [nchar](10) NULL,
	[DIEM_CC] [int] NULL,
	[DIEM_GK] [float] NULL,
	[DIEM_CK] [float] NULL
)
GO


