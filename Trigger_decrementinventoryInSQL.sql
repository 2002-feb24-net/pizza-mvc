

CREATE TRIGGER dbo.TR_InventoryDecrementForEachProductIDINSERT3 ON dbo.ORDERLINES 
	after INSERT
	AS
	BEGIN

		  update Inventorys
		  set inventorys.quantity = inventorys.quantity - inserted.quantity
		  from inserted
		  where inventorys.productid = inserted.productid
	END

	select * from Inventorys
	insert into OrderLines (ProductID, OrderID, Quantity)
	Values (7, 8, 5)

