USE [Lab2]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/23/2024 7:53:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[RegestrationNumber] [nchar](10) NULL,
	[Name] [nchar](10) NULL,
	[Department] [nchar](10) NULL,
	[Session] [nchar](10) NULL,
	[CGPA] [nchar](10) NULL,
	[Address] [nchar](10) NULL
) ON [PRIMARY]
GO
