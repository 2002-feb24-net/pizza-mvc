
CREATE TRIGGER OrderTotalOnOrderlinesInsert
       ON Orderlines
AFTER INSERT
AS
BEGIN
       SET NOCOUNT ON;
 
       DECLARE @OrderlineCost MONEY
	   DECLARE @OrderlineQuantity INT
	   DECLARE @ProductId INT
	   Declare @ProductCost MONEY
 
       SELECT @ProductId = INSERTED.ProductID       
       FROM INSERTED

	   SELECT @ProductCost = Cost
	   FROM Products
	   WHERE ProductID = @ProductId

	   SELECT @OrderlineQuantity = INSERTED.Quantity       
       FROM INSERTED

	   SELECT @OrderlineCost = (@orderlineQuantity * @ProductCost)

	   UPDATE Orders
	   SET Total = Total + @OrderlineCost




 
END
