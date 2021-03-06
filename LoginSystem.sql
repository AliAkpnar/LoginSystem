USE [LoginSystem]
GO
/****** Object:  Table [dbo].[UserTable]    Script Date: 7.09.2020 16:52:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[surname] [nvarchar](50) NULL,
	[secretquestion] [nvarchar](50) NULL,
	[secretanswer] [nvarchar](50) NULL,
	[isonline] [int] NULL,
	[registertime] [datetime] NULL,
	[verifytime] [datetime] NULL,
	[vertificationcode] [nvarchar](50) NULL,
	[role] [nvarchar](50) NULL,
	[vertified] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
