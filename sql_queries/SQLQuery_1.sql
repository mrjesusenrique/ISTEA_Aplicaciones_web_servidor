use ISTEA_AWS;

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO Products (ProductName, Price) VALUES ('Apple', 0.50); 
INSERT INTO Products (ProductName, Price) VALUES ('Banana', 0.30); 
INSERT INTO Products (ProductName, Price) VALUES ('Orange', 0.60); 
INSERT INTO Products (ProductName, Price) VALUES ('Grapes', 2.00); 
INSERT INTO Products (ProductName, Price) VALUES ('Watermelon', 3.00);

select * from Products;