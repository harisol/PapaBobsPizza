USE [PapaBobs]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 16-Jul-17 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Size] [int] NOT NULL,
	[Crust] [int] NOT NULL,
	[Sausage] [bit] NOT NULL DEFAULT ((0)),
	[Pepperoni] [bit] NOT NULL DEFAULT ((0)),
	[Onions] [bit] NOT NULL DEFAULT ((0)),
	[GreenPeppers] [bit] NOT NULL DEFAULT ((0)),
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[TotalCost] [smallmoney] NOT NULL,
	[PaymentType] [int] NOT NULL,
	[Completed] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PizzaPrice]    Script Date: 16-Jul-17 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PizzaPrice](
	[Id] [int] NOT NULL,
	[SmallSizeCost] [smallmoney] NOT NULL,
	[MediumSizeCost] [smallmoney] NOT NULL,
	[LargeSizeCost] [smallmoney] NOT NULL,
	[ThickCrustCost] [smallmoney] NOT NULL,
	[ThinCrustCost] [smallmoney] NOT NULL,
	[RegularCrustCost] [smallmoney] NOT NULL,
	[SausageCost] [smallmoney] NOT NULL,
	[PepperoniCost] [smallmoney] NOT NULL,
	[OnionsCost] [smallmoney] NOT NULL,
	[GreenPeppersCost] [smallmoney] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[PizzaPrice] ([Id], [SmallSizeCost], [MediumSizeCost], [LargeSizeCost], [ThickCrustCost], [ThinCrustCost], [RegularCrustCost], [SausageCost], [PepperoniCost], [OnionsCost], [GreenPeppersCost]) VALUES (1, 12.0000, 14.0000, 16.0000, 2.0000, 0.0000, 0.0000, 2.0000, 1.5000, 1.0000, 1.0000)
