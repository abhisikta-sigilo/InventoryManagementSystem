USE InventoryManagementSystem;
GO

CREATE TABLE Customers (
    CustomerId BIGINT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL,
    Phone VARCHAR(20),

    CreatedDate DATETIME NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate DATETIME,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Products (
    ProductId BIGINT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(150) NOT NULL,
    Description VARCHAR(500),
    Price DECIMAL(10,2) NOT NULL,

    CreatedDate DATETIME NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate DATETIME,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Inventory (
    InventoryId BIGINT IDENTITY(1,1) PRIMARY KEY,
    ProductId BIGINT UNIQUE NOT NULL,
    Quantity INT NOT NULL,

    CreatedDate DATETIME NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate DATETIME,
    IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Inventory_Product
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

CREATE TABLE Status (
    StatusId INT IDENTITY(1,1) PRIMARY KEY,
    Description VARCHAR(100) NOT NULL,

    CreatedDate DATETIME NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate DATETIME,
    IsDeleted BIT NOT NULL DEFAULT 0
);


CREATE TABLE Orders (
    OrderId BIGINT IDENTITY(1,1) PRIMARY KEY,
    CustomerId BIGINT NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL,
    OrderStatusId INT NOT NULL,
    OrderDate DATETIME NOT NULL,

    CreatedDate DATETIME NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate DATETIME,
    IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Orders_Customer
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),

    CONSTRAINT FK_Orders_Status
    FOREIGN KEY (OrderStatusId) REFERENCES Status(StatusId)
);

CREATE TABLE OrderItems (
    OrderItemId BIGINT IDENTITY(1,1) PRIMARY KEY,
    OrderId BIGINT NOT NULL,
    ProductId BIGINT NOT NULL,
    Quantity INT NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL,

    CreatedDate DATETIME NOT NULL DEFAULT GETUTCDATE(),
    ModifiedDate DATETIME,
    IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_OrderItems_Order
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),

    CONSTRAINT FK_OrderItems_Product
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);