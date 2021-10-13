USE [QLDSV_TC]
GO

/****** Object:  View [dbo].[V_DS_PHANMANH]    Script Date: 13/10/2021 10:28:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[V_DS_PHANMANH]
AS
SELECT  TENPM=PUBS.description, TENSERVER = subscriber_server
   FROM dbo.sysmergepublications PUBS,  dbo.sysmergesubscriptions SUBS
   WHERE PUBS.pubid= SUBS.PUBID  AND PUBS.publisher <> SUBS.subscriber_server
GO


