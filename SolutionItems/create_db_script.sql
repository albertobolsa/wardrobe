USE [DB_9EE618_wardrobeTest]
GO
/****** Object:  Table [dbo].[ClothingItem]    Script Date: 26/03/2018 23:03:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClothingItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [varchar](200) NULL,
	[Size] [varchar](200) NULL,
	[PurchaseLocation] [varchar](200) NULL,
	[Price] [decimal](18, 0) NULL,
	[Currency] [varchar](50) NULL,
	[IsFit] [bit] NULL,
	[IsArchived] [bit] NULL,
	[Timestamp] [smalldatetime] NULL,
	[LocationId] [uniqueidentifier] NULL,
	[Comments] [varchar](200) NULL,
 CONSTRAINT [PK_ClothingItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClothingItemImage]    Script Date: 26/03/2018 23:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClothingItemImage](
	[ClothingItemId] [uniqueidentifier] NOT NULL,
	[ImageId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ClothingItemImage] PRIMARY KEY CLUSTERED 
(
	[ClothingItemId] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 26/03/2018 23:03:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NULL,
	[ImageFile] [varbinary](max) NULL,
	[Timestamp] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 26/03/2018 23:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Latitude] [decimal](9, 6) NULL,
	[Longitude] [decimal](9, 6) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Timestamp] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogMessage]    Script Date: 26/03/2018 23:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogMessage](
	[Message] [varchar](max) NOT NULL,
	[Timestamp] [smalldatetime] NOT NULL,
	[LogLevel] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Stacktrace] [varchar](max) NULL,
	[Source] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LogMessage_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 26/03/2018 23:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClothingItem] ADD  CONSTRAINT [DF_ClothingItem_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Image] ADD  CONSTRAINT [DF_Image_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[Location] ADD  CONSTRAINT [DF_Location_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[LogMessage] ADD  CONSTRAINT [DF_LogMessage_Timestamp]  DEFAULT (getdate()) FOR [Timestamp]
GO
ALTER TABLE [dbo].[ClothingItem]  WITH CHECK ADD  CONSTRAINT [FK_ClothingItem_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[ClothingItem] CHECK CONSTRAINT [FK_ClothingItem_Location]
GO
ALTER TABLE [dbo].[ClothingItemImage]  WITH CHECK ADD  CONSTRAINT [FK_ClothingItemImage_ClothingItem] FOREIGN KEY([ClothingItemId])
REFERENCES [dbo].[ClothingItem] ([Id])
GO
ALTER TABLE [dbo].[ClothingItemImage] CHECK CONSTRAINT [FK_ClothingItemImage_ClothingItem]
GO
ALTER TABLE [dbo].[ClothingItemImage]  WITH CHECK ADD  CONSTRAINT [FK_ClothingItemImage_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([Id])
GO
ALTER TABLE [dbo].[ClothingItemImage] CHECK CONSTRAINT [FK_ClothingItemImage_Image]
GO
ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_Location_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_User]
GO
