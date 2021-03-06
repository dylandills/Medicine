CREATE DATABASE [medicine]
GO

USE [medicine]
GO
/****** Object:  Table [dbo].[categories_diseases]    Script Date: 6/19/2017 10:03:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories_diseases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categories_remedies]    Script Date: 6/19/2017 10:03:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories_remedies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[diseases]    Script Date: 6/19/2017 10:03:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diseases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[symtoms] [text] NULL,
	[image] [varchar](255) NULL,
	[category_id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[diseases_remedies]    Script Date: 6/19/2017 10:03:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[diseases_remedies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[diseases_id] [int] NULL,
	[remedies_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[remedies]    Script Date: 6/19/2017 10:03:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[remedies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[side_effect] [varchar](255) NULL,
	[image] [varchar](255) NULL,
	[categories_id] [int] NULL
) ON [PRIMARY]

GO
