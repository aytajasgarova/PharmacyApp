USE [master]
GO
/****** Object:  Database [PharmacyDB]    Script Date: 4/14/2022 9:58:27 PM ******/
CREATE DATABASE [PharmacyDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PharmacyDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PharmacyDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PharmacyDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PharmacyDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PharmacyDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PharmacyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PharmacyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PharmacyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PharmacyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PharmacyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PharmacyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PharmacyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PharmacyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PharmacyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PharmacyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PharmacyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PharmacyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PharmacyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PharmacyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PharmacyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PharmacyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PharmacyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PharmacyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PharmacyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PharmacyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PharmacyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PharmacyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PharmacyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PharmacyDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PharmacyDB] SET  MULTI_USER 
GO
ALTER DATABASE [PharmacyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PharmacyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PharmacyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PharmacyDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PharmacyDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PharmacyDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PharmacyDB] SET QUERY_STORE = OFF
GO
USE [PharmacyDB]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 4/14/2022 9:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Firms]    Script Date: 4/14/2022 9:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Firms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicines]    Script Date: 4/14/2022 9:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MedicineName] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[Description] [nvarchar](300) NULL,
	[IsReceipt] [bit] NOT NULL,
	[ProDate] [datetime] NOT NULL,
	[ExperienceDate] [datetime] NOT NULL,
	[Barcode] [varchar](20) NULL,
	[FirmID] [int] NULL,
 CONSTRAINT [PK_Medicines] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicineToTags]    Script Date: 4/14/2022 9:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicineToTags](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MedicineID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_MedicineToTags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/14/2022 9:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MedicineID] [int] NOT NULL,
	[WorkerID] [int] NOT NULL,
	[PurchaseDate] [datetime] NULL,
	[Amount] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 4/14/2022 9:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 4/14/2022 9:58:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Workers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Firms] ON 

INSERT [dbo].[Firms] ([ID], [Name]) VALUES (1, N'Planeta')
INSERT [dbo].[Firms] ([ID], [Name]) VALUES (2, N'Zəfəran')
INSERT [dbo].[Firms] ([ID], [Name]) VALUES (3, N'Vita')
INSERT [dbo].[Firms] ([ID], [Name]) VALUES (4, N'Zeytun ')
SET IDENTITY_INSERT [dbo].[Firms] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicines] ON 

INSERT [dbo].[Medicines] ([ID], [MedicineName], [Price], [Quantity], [Description], [IsReceipt], [ProDate], [ExperienceDate], [Barcode], [FirmID]) VALUES (1, N'AEvit', CAST(2.40 AS Decimal(18, 2)), 2, N'Əgər yaddaş zəifliyiniz, göz zəifliyiniz varsa, həmçinin saçınız tökülürsə, dəriniz qurudursa bu dərmandan istifadə edə bilərsiniz.', 1, CAST(N'2021-08-01T19:03:05.000' AS DateTime), CAST(N'2022-04-07T19:03:05.730' AS DateTime), N'123', 4)
INSERT [dbo].[Medicines] ([ID], [MedicineName], [Price], [Quantity], [Description], [IsReceipt], [ProDate], [ExperienceDate], [Barcode], [FirmID]) VALUES (2, N'Nimesil', CAST(0.45 AS Decimal(18, 2)), 5, N'Soyuqlama, bədən ağrıları üçün qəbul edilir. İlıq suya əlavə edilib, qarışdırılır. ', 0, CAST(N'2021-05-01T23:05:59.000' AS DateTime), CAST(N'2020-04-07T23:05:59.643' AS DateTime), N'123456789012', 3)
INSERT [dbo].[Medicines] ([ID], [MedicineName], [Price], [Quantity], [Description], [IsReceipt], [ProDate], [ExperienceDate], [Barcode], [FirmID]) VALUES (3, N'Qripxot', CAST(1.00 AS Decimal(18, 2)), 0, N'İlıq suya əlavə edilib içilir.', 0, CAST(N'2021-08-01T23:13:15.000' AS DateTime), CAST(N'2023-01-01T23:13:15.000' AS DateTime), N'324157846636', 2)
INSERT [dbo].[Medicines] ([ID], [MedicineName], [Price], [Quantity], [Description], [IsReceipt], [ProDate], [ExperienceDate], [Barcode], [FirmID]) VALUES (4, N'Spazmaqon', CAST(3.00 AS Decimal(18, 2)), 5, N'Ağrıkəsicidir', 0, CAST(N'2020-11-01T23:23:29.000' AS DateTime), CAST(N'2022-04-30T23:23:29.893' AS DateTime), N'647364775646', 1)
INSERT [dbo].[Medicines] ([ID], [MedicineName], [Price], [Quantity], [Description], [IsReceipt], [ProDate], [ExperienceDate], [Barcode], [FirmID]) VALUES (6, N'Ketanol', CAST(5.00 AS Decimal(18, 2)), 5, N'Şiddətli ağrılarda istifadə olunur', 0, CAST(N'2021-02-02T00:00:00.000' AS DateTime), CAST(N'2022-04-30T00:00:00.000' AS DateTime), N'786786766757', 4)
INSERT [dbo].[Medicines] ([ID], [MedicineName], [Price], [Quantity], [Description], [IsReceipt], [ProDate], [ExperienceDate], [Barcode], [FirmID]) VALUES (1002, N'Tempalqin', CAST(4.00 AS Decimal(18, 2)), 0, N'Baş ağrısı üçün', 0, CAST(N'2022-04-11T21:39:29.123' AS DateTime), CAST(N'2023-03-01T21:39:29.000' AS DateTime), N'657464565746', 1)
INSERT [dbo].[Medicines] ([ID], [MedicineName], [Price], [Quantity], [Description], [IsReceipt], [ProDate], [ExperienceDate], [Barcode], [FirmID]) VALUES (1003, N'Dermoveyt', CAST(3.00 AS Decimal(18, 2)), -1, N'Dəri xəstəliyi üçün', 1, CAST(N'2022-04-01T00:00:00.000' AS DateTime), CAST(N'2022-04-30T00:00:00.000' AS DateTime), N'5900008012010', 4)
INSERT [dbo].[Medicines] ([ID], [MedicineName], [Price], [Quantity], [Description], [IsReceipt], [ProDate], [ExperienceDate], [Barcode], [FirmID]) VALUES (1004, N'Festal', CAST(5.00 AS Decimal(18, 2)), 3, N'Ödəmi götürür', 0, CAST(N'2021-06-08T20:27:14.000' AS DateTime), CAST(N'2022-08-24T20:27:14.000' AS DateTime), N'3600531566869', 2)
SET IDENTITY_INSERT [dbo].[Medicines] OFF
GO
SET IDENTITY_INSERT [dbo].[MedicineToTags] ON 

INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (1, 1, 7)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (2, 1, 8)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (3, 2, 3)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (4, 2, 6)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (5, 2, 4)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (6, 2, 2)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (7, 3, 3)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (8, 3, 6)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (9, 4, 1)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (10, 6, 2)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (1003, 1002, 1)
INSERT [dbo].[MedicineToTags] ([ID], [MedicineID], [TagID]) VALUES (2003, 1004, 1002)
SET IDENTITY_INSERT [dbo].[MedicineToTags] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (1, 3, 1, CAST(N'2022-04-12T11:57:13.350' AS DateTime), 3, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (2, 1002, 1, CAST(N'2022-04-12T11:57:16.683' AS DateTime), 1, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (4, 3, 1, CAST(N'2022-04-12T12:52:43.430' AS DateTime), 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (5, 1002, 1, CAST(N'2022-04-12T12:52:43.453' AS DateTime), 1, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (6, 3, 1, CAST(N'2022-04-12T12:55:02.567' AS DateTime), 5, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (7, 1002, 1, CAST(N'2022-04-12T12:55:02.590' AS DateTime), 3, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (8, 3, 1, CAST(N'2022-04-12T13:42:35.253' AS DateTime), 5, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (9, 1002, 1, CAST(N'2022-04-12T13:42:35.280' AS DateTime), 3, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (10, 1002, 1, CAST(N'2022-04-12T13:56:38.310' AS DateTime), 1, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (11, 4, 1, CAST(N'2022-04-12T14:06:51.670' AS DateTime), 5, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (12, 6, 1, CAST(N'2022-04-12T14:06:51.707' AS DateTime), 2, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (13, 3, 1, CAST(N'2022-04-12T14:06:51.710' AS DateTime), 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (1002, 1003, 1, CAST(N'2022-04-14T20:17:56.407' AS DateTime), 3, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (1003, 1003, 1, CAST(N'2022-04-14T20:21:35.293' AS DateTime), 1, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (2002, 1004, 1, CAST(N'2022-04-14T21:09:22.570' AS DateTime), 7, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[Orders] ([ID], [MedicineID], [WorkerID], [PurchaseDate], [Amount], [Price]) VALUES (2003, 1003, 1, CAST(N'2022-04-14T21:09:22.660' AS DateTime), 2, CAST(3.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([ID], [Name]) VALUES (1, N'Baş ağrısı')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (2, N'Ağrı kəsici')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (3, N'Qrip')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (4, N'Qızdırma')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (5, N'Diş ağrısı')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (6, N'Soyuqdəymə')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (7, N'Saç tökülməsi')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (8, N'Göz zəifliyi')
INSERT [dbo].[Tags] ([ID], [Name]) VALUES (1002, N'Mədə ağrısı')
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
SET IDENTITY_INSERT [dbo].[Workers] ON 

INSERT [dbo].[Workers] ([ID], [Fullname], [Username], [Password]) VALUES (1, N'aytac', N'aytac@mail.ru', N'aytac123')
SET IDENTITY_INSERT [dbo].[Workers] OFF
GO
ALTER TABLE [dbo].[Medicines]  WITH CHECK ADD  CONSTRAINT [FK_Medicines_Firms] FOREIGN KEY([FirmID])
REFERENCES [dbo].[Firms] ([ID])
GO
ALTER TABLE [dbo].[Medicines] CHECK CONSTRAINT [FK_Medicines_Firms]
GO
ALTER TABLE [dbo].[MedicineToTags]  WITH CHECK ADD  CONSTRAINT [FK_MedicineToTags_Medicines] FOREIGN KEY([MedicineID])
REFERENCES [dbo].[Medicines] ([ID])
GO
ALTER TABLE [dbo].[MedicineToTags] CHECK CONSTRAINT [FK_MedicineToTags_Medicines]
GO
ALTER TABLE [dbo].[MedicineToTags]  WITH CHECK ADD  CONSTRAINT [FK_MedicineToTags_Tags] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([ID])
GO
ALTER TABLE [dbo].[MedicineToTags] CHECK CONSTRAINT [FK_MedicineToTags_Tags]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Medicines] FOREIGN KEY([MedicineID])
REFERENCES [dbo].[Medicines] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Medicines]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Workers] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[Workers] ([ID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Workers]
GO
USE [master]
GO
ALTER DATABASE [PharmacyDB] SET  READ_WRITE 
GO
