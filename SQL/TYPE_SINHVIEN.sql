USE [QLDSV_TC]
GO

/****** Object:  UserDefinedTableType [dbo].[TYPE_SINHVIEN]    Script Date: 24/11/2021 9:41:07 AM ******/
CREATE TYPE [dbo].[TYPE_SINHVIEN] AS TABLE(
	[MASV] [nchar](10) NOT NULL,
	[HO] [nvarchar](50) NOT NULL,
	[TEN] [nvarchar](10) NOT NULL,
	[PHAI] [bit] NOT NULL,
	[DIACHI] [nvarchar](100) NULL,
	[NGAYSINH] [date] NULL,
	[MALOP] [nchar](10) NOT NULL,
	[DANGHIHOC] [bit] NOT NULL,
	[PASSWORD] [nvarchar](40) NULL,
	[NEW] [bit] NOT NULL
)
GO


