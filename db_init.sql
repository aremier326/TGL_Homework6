USE [master]
GO
/****** Object:  Database [Homework6DB]    Script Date: 31-Aug-22 22:48:43 ******/
CREATE DATABASE [Homework6DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Homework6DB', FILENAME = N'/var/opt/mssql/data/Homework6DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Homework6DB_log', FILENAME = N'/var/opt/mssql/data/Homework6DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Homework6DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Homework6DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Homework6DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Homework6DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Homework6DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Homework6DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Homework6DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Homework6DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Homework6DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Homework6DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Homework6DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Homework6DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Homework6DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Homework6DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Homework6DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Homework6DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Homework6DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Homework6DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Homework6DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Homework6DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Homework6DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Homework6DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Homework6DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Homework6DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Homework6DB] SET RECOVERY FULL 
GO
ALTER DATABASE [Homework6DB] SET  MULTI_USER 
GO
ALTER DATABASE [Homework6DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Homework6DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Homework6DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Homework6DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Homework6DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Homework6DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Homework6DB', N'ON'
GO
ALTER DATABASE [Homework6DB] SET QUERY_STORE = OFF
GO
USE [Homework6DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 31-Aug-22 22:48:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Breeds]    Script Date: 31-Aug-22 22:48:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Breeds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Breeds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puppies]    Script Date: 31-Aug-22 22:48:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puppies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Gender] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[Weight] [float] NOT NULL,
	[Height] [float] NOT NULL,
	[FurColor] [int] NOT NULL,
	[BreedId] [int] NOT NULL,
 CONSTRAINT [PK_Puppies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220831083307_InitialMigration', N'6.0.7')
GO
SET IDENTITY_INSERT [dbo].[Breeds] ON 

INSERT [dbo].[Breeds] ([Id], [Name]) VALUES (1, N'Golden Retriever')
INSERT [dbo].[Breeds] ([Id], [Name]) VALUES (2, N'Labrador Retriever')
INSERT [dbo].[Breeds] ([Id], [Name]) VALUES (3, N'French Bulldog')
INSERT [dbo].[Breeds] ([Id], [Name]) VALUES (4, N'Beagle')
INSERT [dbo].[Breeds] ([Id], [Name]) VALUES (5, N'German Shepherd Dog')
INSERT [dbo].[Breeds] ([Id], [Name]) VALUES (6, N'Poodle')
INSERT [dbo].[Breeds] ([Id], [Name]) VALUES (7, N'Bulldog')
SET IDENTITY_INSERT [dbo].[Breeds] OFF
GO
SET IDENTITY_INSERT [dbo].[Puppies] ON 

INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (5, N'Coco', 0, 3, 10, 20, 0, 1)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (6, N'Astra', 0, 1, 0.5, 30, 3, 3)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (7, N'Lore', 0, 8, 18.5, 56, 2, 2)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (8, N'Luna', 1, 5, 20, 50, 2, 4)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (9, N'Bella', 1, 10, 10, 36, 1, 6)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (10, N'Lucy', 1, 1, 2, 20, 0, 7)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (11, N'Kiki', 1, 14, 60, 80, 0, 5)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (12, N'Uggie', 1, 9, 35, 73.5, 3, 4)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (13, N'Snowdrop', 1, 2, 23.43, 50.3, 5, 1)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (14, N'Bailey', 0, 18, 64, 117, 0, 5)
INSERT [dbo].[Puppies] ([Id], [Name], [Gender], [Age], [Weight], [Height], [FurColor], [BreedId]) VALUES (15, N'Charlie', 0, 1, 13, 49.4, 1, 3)
SET IDENTITY_INSERT [dbo].[Puppies] OFF
GO
/****** Object:  Index [IX_Puppies_BreedId]    Script Date: 31-Aug-22 22:48:43 ******/
CREATE NONCLUSTERED INDEX [IX_Puppies_BreedId] ON [dbo].[Puppies]
(
	[BreedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Puppies]  WITH CHECK ADD  CONSTRAINT [FK_Puppies_Breeds_BreedId] FOREIGN KEY([BreedId])
REFERENCES [dbo].[Breeds] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Puppies] CHECK CONSTRAINT [FK_Puppies_Breeds_BreedId]
GO
USE [master]
GO
ALTER DATABASE [Homework6DB] SET  READ_WRITE 
GO
