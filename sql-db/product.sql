CREATE TABLE Product (
    No INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    FeeRate DECIMAL(5,4) NOT NULL
);