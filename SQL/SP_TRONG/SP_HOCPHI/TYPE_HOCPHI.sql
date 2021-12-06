USE [QLDSV_TC]
GO

/****** Object:  UserDefinedTableType [dbo].[TYPE_HOCPHI]    Script Date: 12/6/2021 6:42:13 PM ******/
CREATE TYPE [dbo].[TYPE_HOCPHI] AS TABLE(
	[MASV] [nchar](10) NULL,
	[NIENKHOA] [nchar](9) NULL,
	[HOCKY] [int] NULL,
	[HOCPHI] [int] NULL
)
GO

