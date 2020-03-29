--DROP TABLE Inventorys, Stores, Products
--ALTER TABLE Inventorys
--DROP CONSTRAINT FK_STORE_STOREID

--ALTER TABLE Inventorys
--DROP CONSTRAINT FK_STORES_INVENTORYID

--Alter TAble Products
--DROP CONSTRAINT FK_INVENTORYS_INVENTORYID

--ALTER TABLE Stores
--DROP CONSTRAINT FK_
--drop table products
--Drop table inventorys
ALTER TABLE stores
add constraint FK_INVENTORYS_INVENTORYID 
FOREIGN KEY (InventoryID) REFERENCES Inventorys(InventoryID)

Create Table Inventorys(
InventoryID INT PRIMARY KEY IDENTITY NOT NULL,
Quantity INT,
ProductID INT
CONSTRAINT FK_PRODUCTS_PRODUCTID
REFERENCES Products (ProductID));

ALTER TABLE Inventorys
add ProductID INT NOT NULL
CONSTRAINT FK_PRODUCTS_PRODUCTID
FOREIGN KEY (ProductID)
REFERENCES Products (ProductID)



Create Table Stores(
Address NVARCHAR(50),
InventoryID INT
	CONSTRAINT FK_INVENTORYS_INVENTORYID
	REFERENCES Inventorys (InventoryID),
StoreID INT PRIMARY KEY IDENTITY NOT NULL);

Create Table Customers(
CustomerID INT PRIMARY KEY IDENTITY NOT NULL,
FullName NVARCHAR(40) NOT NULL)


Create Table Orders(
OrderID INT PRIMARY KEY IDENTITY NOT NULL,
Total MONEY,
TimeOrdered DATETIME NOT NULL,
CustomerID INT NOT NULL
CONSTRAINT FK_CUSTOMERS_CUSTOMERID
	REFERENCES Customers (customerID),
StoreID INT NOT NULL
CONSTRAINT FK_STORE_STOREID
	REFERENCES Stores (StoreID)
);




-- each order's details (products ordered and their prices)
--Create Table OrderBreakdown(
--OrderID INT, 
--CONSTRAINT FK_BreakdownToOrders FOREIGN KEY (OrderID) REFERENCES Orders (OrderID),
--ProductOrdered,
--CustomerID INT NOT NULL,
--)


Create Table Products(
ProductID INT PRIMARY KEY IDENTITY NOT NULL,
ProductName NVARCHAR(40) NOT NULL,
Cost MONEY,
);

--alter table Products
--alter column ProductName NVARCHAR(40) NOT NULL

-- INVENTORY IS FOREIGN KEY TO PRODUCTS
select * from Inventorys
-- need trigger to initialize a product for each inventory item
-- otherwise invetoryid will be null in products




-- Insert Initial values
Select *
from Customers;

INSERT INTO Customers(FullName)
VALUES ('Tyler Claypool');

--ALTER TABLE Products
--ALTER COLUMN ProductName NVARCHAR(50);

select * from products
select * from inventorys

INSERT INTO Products(ProductName, Cost)
Values ('Pepperoni pizza', 15.32);


