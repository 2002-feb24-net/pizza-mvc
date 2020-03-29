-- adding a store and its products and inventory guide
select * from stores

Insert into Stores (StoreName, StreetAddress, city, State, zipcode)
values ('Little Caesars', '147 Via Romana', 'Downey', 'CA', 90723)

select * from inventorys

select * from products
-- pid 4 is pepperoni pizza but it is 15.32

insert into Products (ProductName, Cost)
values ('Hot N Ready Pepperoni pizza', 5.99)

select * from stores
-- get store id

select * from inventorys
Insert into Inventorys(Quantity, StoreID, ProductID)
Values(15, 2, 11)

-- now hot n ready in stock at little caesars
select * from inventorys
