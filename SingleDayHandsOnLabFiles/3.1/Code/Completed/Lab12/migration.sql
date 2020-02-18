IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    IF SCHEMA_ID(N'Store') IS NULL EXEC(N'CREATE SCHEMA [Store];');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE TABLE [Store].[Categories] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [CategoryName] nvarchar(50) NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE TABLE [Store].[Customers] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [FullName] nvarchar(50) NULL,
        [EmailAddress] nvarchar(50) NOT NULL,
        [Password] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE TABLE [Store].[Products] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [Description] nvarchar(3800) NULL,
        [ModelNumber] nvarchar(50) NULL,
        [ModelName] nvarchar(50) NULL,
        [ProductImage] nvarchar(150) NULL,
        [ProductImageLarge] nvarchar(150) NULL,
        [ProductImageThumb] nvarchar(150) NULL,
        [IsFeatured] bit NOT NULL,
        [UnitCost] money NOT NULL,
        [CurrentPrice] money NOT NULL,
        [UnitsInStock] int NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Store].[Categories] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE TABLE [Store].[Orders] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [OrderDate] datetime NOT NULL DEFAULT (getdate()),
        [ShipDate] datetime NOT NULL DEFAULT (getdate()),
        [CustomerId] int NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Store].[Customers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE TABLE [Store].[ShoppingCartRecords] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [DateCreated] datetime NULL DEFAULT (getdate()),
        [CustomerId] int NOT NULL,
        [Quantity] int NOT NULL DEFAULT 1,
        [LineItemTotal] decimal(18,2) NOT NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_ShoppingCartRecords] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShoppingCartRecords_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Store].[Customers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_ShoppingCartRecords_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Store].[Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE TABLE [Store].[OrderDetails] (
        [Id] int NOT NULL IDENTITY,
        [TimeStamp] rowversion NULL,
        [OrderId] int NOT NULL,
        [ProductId] int NOT NULL,
        [Quantity] int NOT NULL,
        [UnitCost] money NOT NULL,
        CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Store].[Orders] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Store].[Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Customers] ON [Store].[Customers] ([EmailAddress]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE INDEX [IX_OrderDetails_OrderId] ON [Store].[OrderDetails] ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE INDEX [IX_OrderDetails_ProductId] ON [Store].[OrderDetails] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE INDEX [IX_Orders_CustomerId] ON [Store].[Orders] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Store].[Products] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE INDEX [IX_ShoppingCartRecords_CustomerId] ON [Store].[ShoppingCartRecords] ([CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE INDEX [IX_ShoppingCartRecords_ProductId] ON [Store].[ShoppingCartRecords] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_ShoppingCart] ON [Store].[ShoppingCartRecords] ([Id], [ProductId], [CustomerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004030135_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191004030135_Initial', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004031037_TSQL')
BEGIN

    CREATE VIEW [Store].[OrderDetailWithProductInfo]
    AS
    SELECT        
      od.Id, od.TimeStamp, od.OrderId, od.ProductId, od.Quantity, od.UnitCost, 
      od.Quantity * od.UnitCost AS LineItemTotal, 
      p.ModelName, p.Description, p.ModelNumber, p.ProductImage, p.ProductImageLarge, 
      p.ProductImageThumb, p.CategoryId, p.UnitsInStock, p.CurrentPrice, c.CategoryName
    FROM  Store.OrderDetails od INNER JOIN Store.Orders o ON o.Id = od.OrderId
    INNER JOIN Store.Products AS p ON od.ProductId = p.Id INNER JOIN
     Store.Categories AS c ON p.CategoryId = c.id
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004031037_TSQL')
BEGIN

    CREATE VIEW [Store].[CartRecordWithProductInfo]
    AS
    SELECT scr.Id, scr.TimeStamp, scr.DateCreated, scr.CustomerId, scr.Quantity,
            scr.LineItemTotal,
           scr.ProductId, p.ModelName, p.Description,
            p.ModelNumber, p.ProductImage, 
            p.ProductImageLarge, p.ProductImageThumb, 
            p.CategoryId, p.UnitsInStock, p.CurrentPrice, c.CategoryName 
    FROM Store.ShoppingCartRecords scr 
    	INNER JOIN Store.Products p ON p.Id = scr.ProductId
    	INNER JOIN Store.Categories c ON c.Id = p.CategoryId
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004031037_TSQL')
BEGIN

        CREATE FUNCTION Store.GetOrderTotal ( @OrderId INT )
        RETURNS MONEY WITH SCHEMABINDING 
        BEGIN 
          DECLARE @Result MONEY; 
          SELECT @Result = SUM([Quantity]*[UnitCost]) FROM Store.OrderDetails 
          WHERE OrderId = @OrderId; 
          RETURN coalesce(@Result,0) 
        END
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004031037_TSQL')
BEGIN

        CREATE PROCEDURE [Store].[PurchaseItemsInCart](@customerId INT = 0, @orderId INT OUTPUT) AS 
        BEGIN 
          SET NOCOUNT ON; 
          INSERT INTO Store.Orders (CustomerId, OrderDate, ShipDate) 
            VALUES(@customerId, GETDATE(), GETDATE()); 
          SET @orderId = SCOPE_IDENTITY(); 
          DECLARE @TranName VARCHAR(20);SELECT @TranName = 'CommitOrder'; 
          BEGIN TRANSACTION @TranName; 
          BEGIN TRY 
           INSERT INTO Store.OrderDetails (OrderId, ProductId, Quantity, UnitCost) 
           SELECT @orderId, scr.ProductId, scr.Quantity, p.CurrentPrice 
           FROM Store.ShoppingCartRecords scr 
             INNER JOIN Store.Products p ON p.Id = scr.ProductId 
           WHERE scr.CustomerId = @customerId; 
           DELETE FROM Store.ShoppingCartRecords WHERE CustomerId = @customerId; 
           COMMIT TRANSACTION @TranName; 
          END TRY 
          BEGIN CATCH 
            ROLLBACK TRANSACTION @TranName; 
            SET @OrderId = -1; 
          END CATCH; 
        END;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004031037_TSQL')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191004031037_TSQL', N'3.0.0');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004033450_Final')
BEGIN
    ALTER TABLE [Store].[Orders] ADD [OrderTotal] AS Store.GetOrderTotal([Id]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004033450_Final')
BEGIN
    ALTER TABLE [Store].[OrderDetails] ADD [LineItemTotal] AS [Quantity]*[UnitCost];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20191004033450_Final')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20191004033450_Final', N'3.0.0');
END;

GO

