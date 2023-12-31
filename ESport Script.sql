USE [master]
GO
/****** Object:  Database [ESportCenter]    Script Date: 12/14/2021 9:07:38 AM ******/
CREATE DATABASE [ESportCenter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ESportCenter', FILENAME = N'C:\KSK\C# Project 1\ESportCenter.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ESportCenter_log', FILENAME = N'C:\KSK\C# Project 1\ESportCenter_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ESportCenter] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ESportCenter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ESportCenter] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ESportCenter] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ESportCenter] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ESportCenter] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ESportCenter] SET ARITHABORT OFF 
GO
ALTER DATABASE [ESportCenter] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ESportCenter] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ESportCenter] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ESportCenter] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ESportCenter] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ESportCenter] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ESportCenter] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ESportCenter] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ESportCenter] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ESportCenter] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ESportCenter] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ESportCenter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ESportCenter] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ESportCenter] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ESportCenter] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ESportCenter] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ESportCenter] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ESportCenter] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ESportCenter] SET RECOVERY FULL 
GO
ALTER DATABASE [ESportCenter] SET  MULTI_USER 
GO
ALTER DATABASE [ESportCenter] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ESportCenter] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ESportCenter] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ESportCenter] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ESportCenter]
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_FoodAndDrink]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_FoodAndDrink]
@FoodID		int				=0,
@Name		nvarchar(30)	='',
@Price		int				=0,
@Qty		int				=0,
@action		int				=0
As
Begin

If @action=0
	Insert FoodAndDrink Values(@Name, @Price, @Qty)

If @action=1
	Update FoodAndDrink Set Name=@Name, Price=@Price, Qty=@Qty Where FoodID=@FoodID

If @action=2
	Delete FoodAndDrink Where FoodID=@FoodID

If @action=3
	Update FoodAndDrink Set Qty=Qty-@Qty Where FoodID=@FoodID

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Game]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_Game]
@GameID		int				=0,
@GameName	nvarchar(50)	='',
@Date	    nvarchar(50)	='',
@action		int				=0
As
Begin

If @action=0
	Insert Game Values(@GameName, @Date)

If @action=1
	Update Game Set GameName=@GameName, Date=@Date Where GameID=@GameID

If @action=2
	Delete Game Where GameID=@GameID

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_GameSet]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_GameSet]
@GameSetID		int				=0,
@GameSetType	nvarchar(30)	='',
@Date			nvarchar(50)	='',
@action			int				=0
As
Begin

If @action=0
	Insert GameSet Values(@GameSetType, @Date)

If @action=1
	Update GameSet Set GameSetType=@GameSetType, Date=@Date Where GameSetID=@GameSetID

If @action=2
	Delete GameSet Where GameSetID=@GameSetID

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Play]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_Play]
@PlayID		int				=0,
@PlayDate	nvarchar(30)	='',
@PlayerID	int				=0,
@GameSetID	int				=0,
@GameID		int				=0,
@PricePerHour	int			=0,
@PlayedHours	int			=0,
@TotalFoodCost	int			=0,
@TotalGameCost	int			=0,
@GrandTotal	int				=0,	
@action		int				=0
As
Begin

If @action=0
	Insert Play(PlayDate, PlayerID, GameSetID, GameID, PricePerHour, PlayedHours, TotalFoodCost, TotalGameCost, GrandTotal)Values(@PlayDate, @PlayerID, @GameSetID, @GameID, @PricePerHour, @PlayedHours, @TotalFoodCost, @TotalGameCost, @GrandTotal)

If @action=1
	Delete Play Where PlayID=@PlayID

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_PlayDetail]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_PlayDetail]
@PID		int				=0,
@FoodID		int				=0,
@FoodName	nvarchar(50)	='',
@FoodQty	int				=0,
@FoodPrice	int				=0,
@action		int				=0
As
Begin

If @action=0
	Insert PlayDetail Values(@PID,@FoodID, @FoodName, @FoodQty, @FoodPrice)

If @action=1
	Delete PlayDetail Where PID=@PID

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Registration]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_Registration]
@PlayerID	int				=0,
@PlayerName nvarchar(30)	='',
@Password	nvarchar(30)	='',
@StartDate	nvarchar(30)	='',
@Cash		int				=0,
@action		int				=0
As
Begin

If @action=0
	Insert Registration Values(@PlayerName, @Password, @StartDate, @Cash)

If @action=1
	Update Registration Set PlayerName=@PlayerName, Password=@Password, StartDate=@StartDate, Cash=Cash+@Cash Where PlayerID=@PlayerID

If @action=2
	Delete Registration Where PlayerID=@PlayerID

If @action=3
	Update Registration Set Cash=Cash-@Cash Where PlayerID=@PlayerID And PlayerName=@PlayerName

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_UserSetting]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_Insert_UserSetting]
@UserID		int				=0,
@UserName	nvarchar(30)	='',
@Password	nvarchar(15)	='',
@UserLevel	nvarchar(Max)	='',
@UpdateDate	nvarchar(10)	='',
@action		int				=0
As
Begin

If @action=0
	Insert UserSetting Values(@UserName, @Password, @UserLevel, @UpdateDate) 

If @action=1
	Update UserSetting Set UserName=@UserName, Password=@Password, UserLevel=@UserLevel, UpdateDate=@UpdateDate Where UserID=@UserID

If @action=2
	Delete UserSetting Where UserID=@UserID

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_FoodAndDrink]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_FoodAndDrink]
@para1	nvarchar(100)	='',
@para2	nvarchar(100)	='',
@action	int				=0
As
Begin

If @action=0
	Select ROW_NUMBER() Over(Order By Name) As No, * From FoodAndDrink Order By Name

If @action=1
	Select * From FoodAndDrink Where Name=@para1

If @action=2
	Select ROW_NUMBER() Over(Order By Name) As No, * From FoodAndDrink Where Name Like @para1+'%' Order By Name

If @action=3
	Select ROW_NUMBER() Over(Order By Name) As No, * From FoodAndDrink Where Price Like @para1+'%' Order By Name
		
If @action=4
	Select ROW_NUMBER() Over(Order By Name) As No, * From FoodAndDrink Where Qty Like @para1+'%' Order By Name

If @action=5
	Select ROW_NUMBER() Over(Order By Name) As No, * From FoodAndDrink Where Qty>0 Order By Name

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Game]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_Game]
@para1	nvarchar(100)	='',
@para2	nvarchar(100)	='',
@action	int				=0
As
Begin

If @action=0
	Select ROW_NUMBER() Over(Order By GameName) As No, * From Game Order By GameName

If @action=1
	Select * From Game Where GameName=@para1

If @action=2
	Select ROW_NUMBER() Over(Order By GameName) As No, * From Game Where GameName Like @para1+'%' Order By GameName

If @action=3
	Select ROW_NUMBER() Over(Order By GameName) As No, * From Game Where Date Like @para1+'%' Order By GameName


End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_GameSet]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_GameSet]
@para1	nvarchar(100)	='',
@para2	nvarchar(100)	='',
@action	int				=0
As
Begin

If @action=0
	Select ROW_NUMBER() Over(Order By GameSetType) As No, * From GameSet Order By GameSetType

If @action=1
	Select * From GameSet Where GameSetType=@para1

If @action=2
	Select ROW_NUMBER() Over(Order By GameSetType) As No, * From GameSet Where GameSetType Like @para1+'%' Order By GameSetType

If @action=3
	Select ROW_NUMBER() Over(Order By GameSetType) As No, * From GameSet Where Date Like @para1+'%' Order By GameSetType


End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Play]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_Play]
@para1	nvarchar(16)	='',
@para2	nvarchar(16)	='',
@action	int				=0
As
Begin

If @action=0
	Select ROW_NUMBER() Over(Order By PlayDate Desc) As No, * From vi_Play Order By PlayDate Desc
	
If @action=1
	Select Max(PlayID) As PlayID From Play 

If @action=2
	Select ROW_NUMBER() Over(Order By PlayDate Desc) As No, * From vi_Play Where PlayDate Like @para1+'%' Order By PlayDate Desc	

If @action=3
	Select ROW_NUMBER() Over(Order By PlayDate Desc) As No, * From vi_Play Where PlayerName Like @para1+'%' Order By PlayDate Desc

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_PlayDetail]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_PlayDetail]
@para1	nvarchar(100)	='',
@para2	nvarchar(100)	='',
@action	int				=0
As
Begin

If @action=0
	Select ROW_NUMBER() Over(Order By FoodName) As No, * From PlayDetail Order By FoodName

If @action=1
	Select ROW_NUMBER() Over(Order By FoodName) As No, * From PlayDetail Where PID=@para1 Order By FoodName

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Registration]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_Registration]
@para1 nvarchar(50) ='',
@para2 nvarchar(50) ='',
@action	int			=0
As
Begin

If @action=0
	Select ROW_NUMBER() Over(Order By PlayerName) As No, * From Registration Order By PlayerName

If @action=1
	Select * From Registration Where PlayerName=@para1

If @action=2
	Select ROW_NUMBER() Over(Order By PlayerName) As No, * From Registration Where PlayerName Like @para1+'%' Order By PlayerName

If @action=3
	Select ROW_NUMBER() Over(Order By PlayerName) As No, * From Registration Where StartDate Like @para1+'%' Order By PlayerName

If @action=4
	Select Cash From Registration As Cash Where PlayerID=@para1

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_UserSetting]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[SP_Select_UserSetting]
@para1	nvarchar(max)	='',
@para2	nvarchar(max)	='',
@action int				=0
As
Begin

If @action=0
	Select ROW_NUMBER() Over(Order By UserName) As No, * From UserSetting Order By UserName

If @action=1
	Select * From UserSetting Where UserName=@para1 And Password=@para2

If @action=2
	Select ROW_NUMBER() Over(Order By UserName) As No, * From UserSetting Where UserName Like @para1+'%' Order By UserName

End

GO
/****** Object:  Table [dbo].[FoodAndDrink]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodAndDrink](
	[FoodID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NULL,
	[Price] [int] NULL,
	[Qty] [int] NULL,
 CONSTRAINT [PK_FoodAndDrink] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Game]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[GameID] [int] IDENTITY(1,1) NOT NULL,
	[GameName] [nvarchar](30) NULL,
	[Date] [nvarchar](50) NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[GameID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GameSet]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameSet](
	[GameSetID] [int] IDENTITY(1,1) NOT NULL,
	[GameSetType] [nvarchar](50) NULL,
	[Date] [nvarchar](50) NULL,
 CONSTRAINT [PK_GameSet] PRIMARY KEY CLUSTERED 
(
	[GameSetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Play]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Play](
	[PlayID] [int] IDENTITY(1,1) NOT NULL,
	[PlayDate] [nvarchar](50) NULL,
	[PlayerID] [int] NOT NULL,
	[GameSetID] [int] NOT NULL,
	[GameID] [int] NOT NULL,
	[PricePerHour] [int] NULL,
	[PlayedHours] [int] NULL,
	[TotalFoodCost] [int] NULL,
	[TotalGameCost] [int] NULL,
	[GrandTotal] [int] NULL,
 CONSTRAINT [PK_Play] PRIMARY KEY CLUSTERED 
(
	[PlayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlayDetail]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayDetail](
	[PID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[FoodName] [nvarchar](50) NULL,
	[FoodQty] [int] NULL,
	[FoodPrice] [int] NULL,
 CONSTRAINT [PK_PlayDetail] PRIMARY KEY CLUSTERED 
(
	[PID] ASC,
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Registration]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[StartDate] [nvarchar](50) NULL,
	[Cash] [int] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSetting]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSetting](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[UserLevel] [nvarchar](max) NULL,
	[UpdateDate] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserSetting] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[vi_Play]    Script Date: 12/14/2021 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_Play]
AS
SELECT dbo.Play.PlayID, dbo.Play.PlayDate, dbo.Registration.PlayerName, dbo.GameSet.GameSetType, dbo.Game.GameName, dbo.Play.PricePerHour, dbo.Play.PlayedHours, dbo.Play.TotalFoodCost, dbo.Play.TotalGameCost, dbo.Play.GrandTotal
FROM  dbo.Play INNER JOIN
         dbo.Registration ON dbo.Play.PlayerID = dbo.Registration.PlayerID INNER JOIN
         dbo.GameSet ON dbo.Play.GameSetID = dbo.GameSet.GameSetID INNER JOIN
         dbo.Game ON dbo.Play.GameID = dbo.Game.GameID

GO
SET IDENTITY_INSERT [dbo].[FoodAndDrink] ON 

INSERT [dbo].[FoodAndDrink] ([FoodID], [Name], [Price], [Qty]) VALUES (1, N'Humburger', 2500, 32)
INSERT [dbo].[FoodAndDrink] ([FoodID], [Name], [Price], [Qty]) VALUES (2, N'Cola', 800, 42)
INSERT [dbo].[FoodAndDrink] ([FoodID], [Name], [Price], [Qty]) VALUES (3, N'Sandwish', 1500, 40)
INSERT [dbo].[FoodAndDrink] ([FoodID], [Name], [Price], [Qty]) VALUES (4, N'Popcorn', 1000, 47)
INSERT [dbo].[FoodAndDrink] ([FoodID], [Name], [Price], [Qty]) VALUES (1004, N'CottonCandy', 500, 0)
SET IDENTITY_INSERT [dbo].[FoodAndDrink] OFF
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([GameID], [GameName], [Date]) VALUES (1, N'Dota 2', N'11/08/2021')
INSERT [dbo].[Game] ([GameID], [GameName], [Date]) VALUES (2, N'FIFA', N'11/08/2021')
INSERT [dbo].[Game] ([GameID], [GameName], [Date]) VALUES (3, N'Call Of Duty', N'11/29/2021')
INSERT [dbo].[Game] ([GameID], [GameName], [Date]) VALUES (4, N'Osu', N'11/29/2021')
SET IDENTITY_INSERT [dbo].[Game] OFF
SET IDENTITY_INSERT [dbo].[GameSet] ON 

INSERT [dbo].[GameSet] ([GameSetID], [GameSetType], [Date]) VALUES (1, N'PC1', N'11/10/2021')
INSERT [dbo].[GameSet] ([GameSetID], [GameSetType], [Date]) VALUES (2, N'PC2', N'11/10/2021')
INSERT [dbo].[GameSet] ([GameSetID], [GameSetType], [Date]) VALUES (3, N'PC3', N'11/29/2021')
INSERT [dbo].[GameSet] ([GameSetID], [GameSetType], [Date]) VALUES (4, N'PC4', N'11/29/2021')
SET IDENTITY_INSERT [dbo].[GameSet] OFF
SET IDENTITY_INSERT [dbo].[Play] ON 

INSERT [dbo].[Play] ([PlayID], [PlayDate], [PlayerID], [GameSetID], [GameID], [PricePerHour], [PlayedHours], [TotalFoodCost], [TotalGameCost], [GrandTotal]) VALUES (7, N'11/22/2021', 2, 1, 1, 500, 2, 800, 1000, 1800)
INSERT [dbo].[Play] ([PlayID], [PlayDate], [PlayerID], [GameSetID], [GameID], [PricePerHour], [PlayedHours], [TotalFoodCost], [TotalGameCost], [GrandTotal]) VALUES (8, N'11/22/2021', 1, 1, 1, 500, 2, 800, 1000, 1800)
INSERT [dbo].[Play] ([PlayID], [PlayDate], [PlayerID], [GameSetID], [GameID], [PricePerHour], [PlayedHours], [TotalFoodCost], [TotalGameCost], [GrandTotal]) VALUES (9, N'11/22/2021', 2, 1, 1, 500, 2, 0, 1000, 1000)
INSERT [dbo].[Play] ([PlayID], [PlayDate], [PlayerID], [GameSetID], [GameID], [PricePerHour], [PlayedHours], [TotalFoodCost], [TotalGameCost], [GrandTotal]) VALUES (12, N'11/22/2021', 2, 2, 2, 500, 4, 1500, 2000, 3500)
INSERT [dbo].[Play] ([PlayID], [PlayDate], [PlayerID], [GameSetID], [GameID], [PricePerHour], [PlayedHours], [TotalFoodCost], [TotalGameCost], [GrandTotal]) VALUES (13, N'11/22/2021', 1, 1, 2, 500, 5, 7000, 2500, 9500)
INSERT [dbo].[Play] ([PlayID], [PlayDate], [PlayerID], [GameSetID], [GameID], [PricePerHour], [PlayedHours], [TotalFoodCost], [TotalGameCost], [GrandTotal]) VALUES (14, N'11/23/2021', 1, 2, 2, 500, 9, 7500, 4500, 12000)
INSERT [dbo].[Play] ([PlayID], [PlayDate], [PlayerID], [GameSetID], [GameID], [PricePerHour], [PlayedHours], [TotalFoodCost], [TotalGameCost], [GrandTotal]) VALUES (15, N'11/29/2021', 7, 3, 3, 500, 6, 2000, 3000, 5000)
INSERT [dbo].[Play] ([PlayID], [PlayDate], [PlayerID], [GameSetID], [GameID], [PricePerHour], [PlayedHours], [TotalFoodCost], [TotalGameCost], [GrandTotal]) VALUES (16, N'11/29/2021', 7, 4, 4, 500, 1, 1800, 500, 2300)
SET IDENTITY_INSERT [dbo].[Play] OFF
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (7, 2, N'Cola', 1, 800)
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (8, 2, N'Cola', 1, 800)
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (12, 3, N'Sandwish', 1, 1500)
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (13, 1, N'Humburger', 1, 2500)
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (13, 3, N'Sandwish', 3, 1500)
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (14, 3, N'Sandwish', 5, 1500)
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (15, 4, N'Popcorn', 2, 1000)
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (16, 2, N'Cola', 1, 800)
INSERT [dbo].[PlayDetail] ([PID], [FoodID], [FoodName], [FoodQty], [FoodPrice]) VALUES (16, 4, N'Popcorn', 1, 1000)
SET IDENTITY_INSERT [dbo].[Registration] ON 

INSERT [dbo].[Registration] ([PlayerID], [PlayerName], [Password], [StartDate], [Cash]) VALUES (1, N'Skylar', N'1234', N'12/06/2021', 31500)
INSERT [dbo].[Registration] ([PlayerID], [PlayerName], [Password], [StartDate], [Cash]) VALUES (2, N'Lisa', N'1234', N'11/10/2021', 20500)
INSERT [dbo].[Registration] ([PlayerID], [PlayerName], [Password], [StartDate], [Cash]) VALUES (7, N'Khant', N'1234', N'11/29/2021', 42700)
INSERT [dbo].[Registration] ([PlayerID], [PlayerName], [Password], [StartDate], [Cash]) VALUES (1003, N'Shin', N'1234', N'12/07/2021', 6000)
SET IDENTITY_INSERT [dbo].[Registration] OFF
SET IDENTITY_INSERT [dbo].[UserSetting] ON 

INSERT [dbo].[UserSetting] ([UserID], [UserName], [Password], [UserLevel], [UpdateDate]) VALUES (3, N'Skylar', N'1234', N'Registration,GameSet,Game,FoodAndDrink,UserSetting,Play,', N'12/06/2021')
SET IDENTITY_INSERT [dbo].[UserSetting] OFF
ALTER TABLE [dbo].[FoodAndDrink] ADD  CONSTRAINT [DF_FoodAndDrink_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[FoodAndDrink] ADD  CONSTRAINT [DF_FoodAndDrink_Qty]  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[Play] ADD  CONSTRAINT [DF_Play_PricePerHour]  DEFAULT ((0)) FOR [PricePerHour]
GO
ALTER TABLE [dbo].[Play] ADD  CONSTRAINT [DF_Play_PlayedHours]  DEFAULT ((0)) FOR [PlayedHours]
GO
ALTER TABLE [dbo].[Play] ADD  CONSTRAINT [DF_Play_TotalFoodCost]  DEFAULT ((0)) FOR [TotalFoodCost]
GO
ALTER TABLE [dbo].[Play] ADD  CONSTRAINT [DF_Play_TotalGameCost]  DEFAULT ((0)) FOR [TotalGameCost]
GO
ALTER TABLE [dbo].[Play] ADD  CONSTRAINT [DF_Play_GrandTotal]  DEFAULT ((0)) FOR [GrandTotal]
GO
ALTER TABLE [dbo].[PlayDetail] ADD  CONSTRAINT [DF_PlayDetail_FoodQty]  DEFAULT ((0)) FOR [FoodQty]
GO
ALTER TABLE [dbo].[PlayDetail] ADD  CONSTRAINT [DF_PlayDetail_FoodPrice]  DEFAULT ((0)) FOR [FoodPrice]
GO
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_Password]  DEFAULT ((0)) FOR [Password]
GO
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_StartDate]  DEFAULT ((0)) FOR [StartDate]
GO
ALTER TABLE [dbo].[Registration] ADD  CONSTRAINT [DF_Registration_Cash]  DEFAULT ((0)) FOR [Cash]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Play"
            Begin Extent = 
               Top = 15
               Left = 96
               Bottom = 324
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Registration"
            Begin Extent = 
               Top = 15
               Left = 527
               Bottom = 324
               Right = 855
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GameSet"
            Begin Extent = 
               Top = 15
               Left = 951
               Bottom = 281
               Right = 1279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Game"
            Begin Extent = 
               Top = 15
               Left = 1375
               Bottom = 281
               Right = 1703
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Play'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Play'
GO
USE [master]
GO
ALTER DATABASE [ESportCenter] SET  READ_WRITE 
GO
