using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess;
using Restaurant.DataAccess.Models;
using Restaurant.Library;
// Author: Haroldo Altamirano
// TO BE IMPLEMENTED:
// Exception handling, unit tests, order history, search of customers, (search) order details table, secretconfiguration, inventory decrement on order placement, pick product quantity on order, 

// dbcontext.Customers.Where(condition)



// IMPLEMENTED FOR FRIDAY: SQL handles inventory decrement on order placement, pick product quantity on order, shopping cart (order multiple products in one order),  order details table, order history,  search of customers

// FOCUS:
// SOLID
//      ex: Small methods, versatility from returning whole row objects instead of just their data, interfaces rather than direct connections b/w data access project and library classes
//separation of concerns (keep data access implementation in another project)
// OOP
//      No hardcoded static values, variables displayed and options (product options) are loaded from DB data
//       Extendable: Library and DataAccess classes and Database structure support many different types of stores
//                      Can add a store description and products and inventory in under 10 minutes
//                          changing between stores in the program can be done in the first 30 seconds of execution
// GIT
//      Incremental development with frequent backups, commits only once code had no compile errors, task completed and WIP functionality noted in commits
//      37 commits, separate from other repositories/unrelated files, deprecated projects deleted
// Disposable connections
//      connections to database are closed through using statements. Connections do not remain open for longer than a method call
// minor still to be implemented:
// Exception handling, unit tests,




namespace Restaurant.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var s_Stores = Menu.StoreMenu(); // pick store
            var sDAL = new StoreDAL(); // access db about stores
            Stores store = s_Stores;

            var custRepo = new CustomerRepository(new DbRestaurantContext());
            var customer1 = custRepo.Get(1);
            

            Console.WriteLine(customer1.FullName);
            Customer customer = new Customer("default", "default", "default1231!");

            
        }
    }
}
            /*bool loggedIn;
            do
            {
                loggedIn = false;

                Menu.UserMenu(s_Stores);
                var loginOrRegisterOrSearch = Convert.ToInt32(Console.ReadLine());
                switch (loginOrRegisterOrSearch)
                {
                    case 1:
                        //login
                        customer = Login();
                        loggedIn = true;

                        break;
                    case 2:
                        //register
                        AddCustomerToDB(); // has prompts to get user details (name, username, password)
                        customer = Login();
                        loggedIn = true;
                        break;
                    case 3:
                        // search for customers in one store
                        var listOfCustomers = GetCustomers(store);
                        Console.WriteLine($"Listing all customers for store {store.StoreId} {store.StoreName}");
                        foreach (var cust in listOfCustomers)
                        {
                            Console.WriteLine($"ID. {cust.CustomerId} {cust.FullName}");
                        }
                        Console.WriteLine(); //new line

                        break;
                    case 4:
                        // search customer by name
                        Console.WriteLine("Enter a full name to search for");
                        var fullName = Console.ReadLine();
                        var cDAL = new CustomerDAL();
                        var listOfMatchingCustomers = cDAL.LoadCustomersByName(fullName);
                        if (listOfMatchingCustomers == null)
                        {
                            Console.WriteLine("No such customer(s) found");
                            break;
                        }
                        Console.WriteLine($"All customers matching {fullName}");
                        foreach (var cust in listOfMatchingCustomers)
                        {
                            Console.WriteLine($"ID= {cust.CustomerId}. {cust.FullName}/tusername = {cust.Username}");
                        }
                        break;
                    default:
                        Console.WriteLine("Error: you must choose 1 or 2 or 3 or 4");
                        break;
                }
            } while (loggedIn == false);
            // now logged in with customer object
            // place an order
            Menu.CustMenu(s_Stores, customer);
            bool quitFlag = false;
            while (quitFlag == false)
                {
                Menu.CustMenu(s_Stores, customer);
                var loggedInOptions = Convert.ToInt32(Console.ReadLine());

                switch (loggedInOptions)
                {
                    case 1:
                        //login
                        Console.WriteLine("Place an order");
                        AddOrder(customer, store);

                        break;
                    case 2:
                        //register
                        Console.WriteLine("Showing your order history");
                        ShowOrderHistory(customer);
                        break;
                   
                    default:
                        Console.WriteLine("Error: you must choose 1 or 2");
                        break;


                }
                Console.WriteLine("Do you wish to quit? (y/n)?");
                var input = Console.ReadLine();
                if (input.ToLower() == "y")
                    quitFlag = true;
*/

/*  }*/


// 





/*var customer = new Customer("Jonny water");*/
/*AddOrder(customer, chosenStore);*/



/*  Console.WriteLine("Hello World!");

  Console.WriteLine("Place a new order");
  AddCustomerToDB();
  Console.WriteLine("All Customers in Database");
  DisplayAllCustomersFromDB();
  // display all customers from database*/
/*  }*/

/* static HashSet<Customers> GetCustomers(Stores store)
 {
     using var context2 = new DbRestaurantContext();
     var listOfCustomers = from order in context2.Orders join customer in context2.Customers
                           on order.CustomerId equals customer.CustomerId 
                           where order.StoreId == store.StoreId 
                           select customer;
     HashSet<Customers> setOfCustomers = new HashSet<Customers> (listOfCustomers);
     return setOfCustomers;
 }
 static void AddCustomerToDB()
 {
     Console.WriteLine("Add a customer");
     Console.WriteLine("Write full name");
     var inputName = Console.ReadLine();
     Console.WriteLine("Write a unique username");
     var username = Console.ReadLine();
     Console.WriteLine("Write a password...");
     Console.WriteLine("Must have at least 8 characters and 1 special character ex: !@#$%^&*");
     var password = Console.ReadLine();
     var newCustomer = new Customer(inputName, username, password);
     var CDAL = new CustomerDAL();
     CDAL.SaveCustomer(newCustomer);
 }

 static void DisplayAllCustomersFromDB()
 {
     var CDAL = new CustomerDAL();
     var CustomersList = CDAL.LoadAllCustomers();
     foreach (var OneCustomers in CustomersList)
     {
         Console.WriteLine(OneCustomers.FullName);
     }
 }



 static void ShowOrderHistory(Customer customer)
 {
     using var context = new DbRestaurantContext();

     var listOfOrders = context.Orders.Where(x => x.CustomerId == customer.CustomerId).Include("Orderlines"); // grab an type x where ==)

     var listOfProducts = from orderl in context.Orderlines 
                          join prd in context.Products on orderl.ProductId equals prd.ProductId 
                          where orderl.ProductId == prd.ProductId 
                          select prd;
     listOfOrders.ToList();
     listOfProducts.ToList();

     Console.WriteLine($"{customer.FullName} ordered");
     foreach (var order in listOfOrders)
     {
         Console.Write($"Order ID: {order.OrderId}\t");

         *//*foreach (var product in listOfProducts)
         {
             Console.WriteLine($"{product.ProductName}/tcost per item: {product.Cost}");
         }*//*
         foreach (var orderline in order.Orderlines)
         {


             Console.WriteLine($"Product code/id: {orderline.ProductId}\tQuantity purchased: {orderline.Quantity}");
         }
         Console.WriteLine($"Order Total = {order.Total}");

     }
 }

 *//*static void ShowOrderHistory(Store store)
 {

 }*//*

 static void AddOrder(Customer customer, Stores store)
 {
     // NOTE: REJECT ORDERLINE IF QUANTITY ORDERED IS MORE THAN QUANTITY IN INVENTORY
     // do a while loop to keep asking for customer to buy product
     Console.WriteLine("Add an order");
     Console.WriteLine("Your store has the following to choose from");



     var PDAL = new ProductDAL();
     var productIDsInStock = PDAL.LoadProductIDsFromStoreInStock(store); // need to load product ids for the specific store here

     // select products where productid matches one of the items(ids) in the list
     foreach (var productID in productIDsInStock)
     {
         var Product_products = PDAL.LoadProductByID(productID);

         //output list of products
         Console.WriteLine(Product_products.ProductId + " " + Product_products.ProductName + " " + Product_products.Cost);
     }
     var newOrder = new Orders();
     newOrder.Total = 0; // need a value to do =+
     newOrder.StoreId = store.StoreId; // order has to be at a specific store. Store was selected above
     newOrder.CustomerId = customer.CustomerId;  // order has to be placed by a customer. customer passed above

     using var ctx = new DbRestaurantContext();
     var ListOfallOrderIDs = from order in ctx.Orders select order.OrderId;
     var newOrderID = ListOfallOrderIDs.Max() + 1;

     bool doneOrdering = false;
     using var context = new DbRestaurantContext();

     context.Orders.Add(newOrder);
     newOrder.TimeOrdered = DateTime.Now;
     context.SaveChanges();

     while (doneOrdering == false) // buy several products
     {
         Console.Write("Select from the above...");
         Console.WriteLine("For example: 7");
         var productIDChosen = Convert.ToInt32(Console.ReadLine());

         Console.WriteLine("How many would you like to buy?");
         int pQuantity = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Stop ordering? (y/n)");
         var yN = Console.ReadLine();
         if (yN == "y")
             doneOrdering = true;
         // if input matches a product id TO BE IMPLEMENTED

         // get product details and add/pass that to the order
         var productToBeOrdered = PDAL.LoadProductByID(productIDChosen);




         var newOrderline = new Orderlines()
         {
             ProductId = productIDChosen,
             Quantity = pQuantity,
             OrderId = newOrderID

         };

         newOrder.Total += productToBeOrdered.Cost * pQuantity;
         context.Orderlines.Add(newOrderline);

     }




     // Display total cost
     Console.WriteLine("Your order total is " + newOrder.Total);
     Console.WriteLine("Do you confirm the purchase? (y/n)");
     var input = Console.ReadLine();

     if (input == "y" || input == "Y")
     {
         //save order in db
         *//*var oDAL = new OrderDAL();
         oDAL.SaveOrder(newOrder, customer, store);*//*
         // put the order time

         context.SaveChanges();

     }
     else
     {
         Console.WriteLine("Order cancelled.");
         Console.WriteLine("You will not be charged");
         return;
     }

 }*/

/* static void AddOrder(Customer customer, Stores store)
 {
     // do a while loop to keep asking for customer to buy product
     Console.WriteLine("Add an order");
     Console.WriteLine("Your store has the following to choose from");



     var PDAL = new ProductDAL();
     var productIDsInStock = PDAL.LoadProductIDsFromStoreInStock(store); // need to load product ids for the specific store here

     // select products where productid matches one of the items(ids) in the list
     foreach (var productID in productIDsInStock)
     {
         var Product_products = PDAL.LoadProductByID(productID);

         //output list of products
         Console.WriteLine(Product_products.ProductId + " " + Product_products.ProductName + " " + Product_products.Cost);
     }
     var newOrder = new Orders();
     newOrder.Total = 0; // need a value to do =+
     newOrder.Store = store; // order has to be at a specific store. Store was selected above

     bool doneOrdering = false;
     using var context = new DbRestaurantContext();
     while (doneOrdering == false) // buy several products
     {
         Console.Write("Select from the above...");
         Console.WriteLine("For example: 7");
         var productIDChosen = Convert.ToInt32(Console.ReadLine());

         Console.WriteLine("How many would you like to buy?");
         int pQuantity = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Stop ordering? (y/n)");
         var yN = Console.ReadLine();
         if (yN == "y")
             doneOrdering = true;
         // if input matches a product id TO BE IMPLEMENTED

         // get product details and add/pass that to the order
         var productToBeOrdered = PDAL.LoadProductByID(productIDChosen);




         var newOrderline = new Orderlines()
         {
             ProductId = productIDChosen,
             Quantity = pQuantity,
             OrderId = newOrder.OrderId

         };
         newOrder.Orderlines.Add(newOrderline);
         newOrder.Total += productToBeOrdered.Cost * pQuantity;
         context.Add(newOrder);
     }




     // Display total cost
     Console.WriteLine("Your order total is " + newOrder.Total);
     Console.WriteLine("Do you confirm the purchase? (y/n)");
     var input = Console.ReadLine();

     if (input == "y" || input == "Y")
     {
         //save order in db
         *//*var oDAL = new OrderDAL();
         oDAL.SaveOrder(newOrder, customer, store);*//*
         // put the order time
         newOrder.TimeOrdered = DateTime.Now;
         context.SaveChanges();

     }
     else
     {
         Console.WriteLine("Order cancelled.");
         Console.WriteLine("You will not be charged");
         return;
     }

 }*/

/*static Customer Login()
{
    *//*try
    {*//*
        Console.WriteLine("Enter your username");
        var username = Console.ReadLine();
        Console.WriteLine("Enter your password");
        var password = Console.ReadLine();

        //check if matches unique registered user,password combo
        var cDAL = new CustomerDAL();
        *//*try
        {*//*
        var customerID = cDAL.GetCustomerID(username, password);
        *//*}*//*

        var c_Customers = cDAL.LoadCustomerByID(customerID);

        // load all data from db into c# customer object
        var loggedInCustomer = new Customer(c_Customers.FullName, c_Customers.Username, c_Customers.Password);
        loggedInCustomer.CustomerId = customerID;
 *//*   }*/
/*catch
{
    var ex = new System.InvalidOperationException();
}*//*
return loggedInCustomer;

}



}
}*/
