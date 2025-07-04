USE [BogusNorthWind1]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 5/12/2025 1:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 5/12/2025 1:16:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[CategoryID] [int] NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [smallint] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Games')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Health')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Books')
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (4, N'Garden')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (1, N'Borders', 2, 37.1780, 5)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (2, N'Cambridgeshire', 3, 15.7208, 4)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (3, N'Buckinghamshire', 3, 27.8529, 4)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (4, N'Berkshire', 2, 14.3991, 1)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (5, N'Buckinghamshire', 4, 22.6544, 3)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (6, N'Borders', 1, 11.5247, 5)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (7, N'Buckinghamshire', 4, 36.9699, 1)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (8, N'Bedfordshire', 4, 39.7025, 5)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (9, N'Borders', 3, 28.1538, 2)
INSERT [dbo].[Products] ([ProductID], [ProductName], [CategoryID], [UnitPrice], [UnitsInStock]) VALUES (10, N'Avon', 4, 24.8027, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
/****** Object:  Index [IX_Products_CategoryID]    Script Date: 5/12/2025 1:16:49 PM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryID] ON [dbo].[Products]
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'CategoryName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'ProductID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'ProductName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Category key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'CategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Price' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'UnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'How many are in stock' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Products', @level2type=N'COLUMN',@level2name=N'UnitsInStock'
GO
USE [master]
GO
ALTER DATABASE [BogusNorthWind1] SET  READ_WRITE 
GO
