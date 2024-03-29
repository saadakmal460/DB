USE [TestDB_2022_CS_148]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/23/2024 9:10:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Test](
	[Name] [nchar](10) NULL,
	[Roll Number] [nchar](10) NULL,
	[Section] [nchar](10) NULL,
	[Session] [nchar](10) NULL,
	[Degree Program] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Student_Test] ([Name], [Roll Number], [Section], [Session], [Degree Program]) VALUES (N'Ahmad     ', N'144       ', N'C         ', N'2022      ', N'BSc CS    ')
INSERT [dbo].[Student_Test] ([Name], [Roll Number], [Section], [Session], [Degree Program]) VALUES (N'Saad      ', N'148       ', N'C         ', N'2022      ', N'BSc CS    ')
INSERT [dbo].[Student_Test] ([Name], [Roll Number], [Section], [Session], [Degree Program]) VALUES (N'Ali       ', N'104       ', N'A         ', N'2020      ', N'BBA       ')
INSERT [dbo].[Student_Test] ([Name], [Roll Number], [Section], [Session], [Degree Program]) VALUES (N'Robass    ', N'50        ', N'D         ', N'2021      ', N'EE        ')
GO
