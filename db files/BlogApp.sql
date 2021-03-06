USE [BlogApp]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 25.11.2021 15:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [nvarchar](250) NOT NULL,
	[NumberOfClicks] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 25.11.2021 15:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25.11.2021 15:00:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[Password] [varchar](256) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (8, N'Mobil Uygulama Fikri ve Mobil Uygulama Geliştirme', 0, 1)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (9, N'Site İçi Optimizasyon Ne Demektir? Nasıl Yapılır?', 1, 1)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (10, N'Mobil Uygulama Geliştirmek Neden Önemlidir?', 1, 1)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (13, N'Basit Bir Dijital Pazarlama Planı Nasıl Yapılır?', 4, 2)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (14, N'Web Sitesi Bakımı ve Güncelleme Çalışmaları', 7, 3)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (15, N'Visual Studio Nedir? Ne İçin Kullanılır?', 1, 4)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (1008, N'Yazılım Firması Seçerken Nelere Dikkat Edilmelidir?', 9, 4)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (2008, N'OOP (Nesne Yönelimli Programlama) Nedir?', 0, 1)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (2009, N'Uçtan Uca Şifreleme Nedir ve Kaldırılabilir mi?', 0, 4)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (2010, N'Alt Alan Adı Yani Subdomain Nedir?', 0, 3)
INSERT [dbo].[Blog] ([id], [BlogTitle], [NumberOfClicks], [CategoryId]) VALUES (2011, N'Yazılım Geliştirmede Kalite Güvencesi Nedir?', 3, 1)
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [CategoryName]) VALUES (1, N'Yazılım')
INSERT [dbo].[Category] ([id], [CategoryName]) VALUES (2, N'Dijital Pazarlama')
INSERT [dbo].[Category] ([id], [CategoryName]) VALUES (3, N'Web')
INSERT [dbo].[Category] ([id], [CategoryName]) VALUES (4, N'Sistem')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [Mail], [Password]) VALUES (2, N'baran.saritas0635@gmail.com', N'baran123')
INSERT [dbo].[User] ([id], [Mail], [Password]) VALUES (7, N'baran.saritas0635@gmail.com', N'626172616E2E736172697461733036333540676D61696C2E636F6D626172616E')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Blog] ADD  CONSTRAINT [DF_Blog_NumberOfClicks]  DEFAULT ((0)) FOR [NumberOfClicks]
GO
