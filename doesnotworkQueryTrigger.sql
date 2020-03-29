

CREATE TRIGGER dbo.TR_InventoryDecrementForEachProductIDINSERT ON Orderlines 
	FOR INSERT, UPDATE
	AS
	BEGIN
          update Inventorys
		  set Quantity = Quantity - 1
		  Where ProductID = dbo.Orderlines.ProductID
	END