USE [League]
GO
/****** Object:  Table [dbo].[Fixture]    Script Date: 19.11.2019 15:13:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fixture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Home] [int] NOT NULL,
	[Away] [int] NOT NULL,
	[Week] [smallint] NOT NULL,
	[HomeScore] [smallint] NOT NULL,
	[AwayScore] [smallint] NOT NULL,
 CONSTRAINT [PK_Fixture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 19.11.2019 15:13:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Point] [smallint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ChangeDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([Id], [Name], [Point], [CreateDate], [ChangeDate], [IsDeleted]) VALUES (65, N'bjk', 0, CAST(N'2019-11-19T15:06:32.290' AS DateTime), CAST(N'2019-11-19T15:06:57.923' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Team] OFF
ALTER TABLE [dbo].[Team] ADD  CONSTRAINT [DF_Team_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
