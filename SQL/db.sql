USE [OAuth2]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 2/4/2013 7:29:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Application](
	[ApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[ApplicationName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2/4/2013 7:29:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [uniqueidentifier] NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provision]    Script Date: 2/4/2013 7:29:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provision](
	[ProvisionId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[ApplicationId] [int] NOT NULL,
	[Domain] [nvarchar](100) NULL,
	[RedirectUrl] [nvarchar](150) NULL,
	[IsEnabled] [bit] NOT NULL,
	[Secret] [uniqueidentifier] NOT NULL,
	[CustomAppData] [nvarchar](max) NULL,
 CONSTRAINT [PK_Provision] PRIMARY KEY CLUSTERED 
(
	[ProvisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Token]    Script Date: 2/4/2013 7:29:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Token](
	[TokenId] [uniqueidentifier] NOT NULL,
	[ProvisionId] [int] NOT NULL,
	[ExpiryDate] [datetime] NULL,
 CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
(
	[TokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CustomerId]  DEFAULT (newid()) FOR [CustomerId]
GO
ALTER TABLE [dbo].[Provision] ADD  CONSTRAINT [DF_Provision_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[Provision] ADD  CONSTRAINT [DF_Provision_Secret]  DEFAULT (newid()) FOR [Secret]
GO
ALTER TABLE [dbo].[Token] ADD  CONSTRAINT [DF_Token_TokenId]  DEFAULT (newid()) FOR [TokenId]
GO
ALTER TABLE [dbo].[Provision]  WITH CHECK ADD  CONSTRAINT [FK_Provision_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([ApplicationId])
GO
ALTER TABLE [dbo].[Provision] CHECK CONSTRAINT [FK_Provision_Application]
GO
ALTER TABLE [dbo].[Provision]  WITH CHECK ADD  CONSTRAINT [FK_Provision_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[Provision] CHECK CONSTRAINT [FK_Provision_Customer]
GO
ALTER TABLE [dbo].[Token]  WITH CHECK ADD  CONSTRAINT [FK_Token_Provision] FOREIGN KEY([ProvisionId])
REFERENCES [dbo].[Provision] ([ProvisionId])
GO
ALTER TABLE [dbo].[Token] CHECK CONSTRAINT [FK_Token_Provision]
GO
