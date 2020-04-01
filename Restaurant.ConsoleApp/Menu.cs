using Restaurant.DataAccess;
using Restaurant.DataAccess.Model;
using Restaurant.Domain.Model;
using System;

namespace Restaurant.ConsoleApp
{
    public static class Menu
    {
        public static void UserMenu(Stores store)
        {
            Console.WriteLine("======================================");
            Console.WriteLine($"Welcome to {store.StoreName}");
            Console.WriteLine($"Located in {store.StreetAddress}");
            Console.WriteLine($"{store.City}");
            Console.WriteLine($"{store.State}");
            Console.WriteLine($"{store.Zipcode}");
            Console.WriteLine("Type an option:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register as New Customer");
            Console.WriteLine($"3. List customers for store ID: {store.StoreId}. {store.StoreName}");
            Console.WriteLine("4. Search customer by name");
        }
        public static void CustMenu(Stores store, Customer customer)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Hi " + customer.FullName);
            Console.WriteLine($"Welcome to {store.StoreName}");
            Console.WriteLine($"Located in {store.StreetAddress}");
            Console.WriteLine($"{store.City}");
            Console.WriteLine($"{store.State}");
            Console.WriteLine($"{store.Zipcode}");
            Console.WriteLine("Type an option:");
            Console.WriteLine("1. Place an Order");
            Console.WriteLine("2. Check your order history");
            
        }

        public static Stores StoreMenu()
        {
            Console.WriteLine("Displaying all stores");

            // load all stores
            var sDAL = new StoreDAL();
            var listOfStores = sDAL.LoadAllStores();
            foreach (var store in listOfStores)
            {
                Console.WriteLine(store.StoreId + " " + store.StoreName);
                Console.WriteLine(store.StreetAddress);
                Console.WriteLine(store.City + ", " + store.State + ", " + store.Zipcode);

            }
            Console.WriteLine("Please select a store");
            var storeIDChosen = Convert.ToInt32(Console.ReadLine());

            // load store by id to pass to other methods
            var storeChosen = sDAL.LoadStoreByID(storeIDChosen);

            return storeChosen;

        }
        /*static void GuideInput(string input)
        {
            input = ConvertInput(input);    // make input standardized to shorten conditional statements
            Switch(input);
        }
*/
        static void Switch(string input)
        {
            switch (input)
            {
                case "1":
                //CarryOutOrDelivery();
                //Pizza.ShowOptions();

                break;

                case "2":

                break;

                case "3":

                break;

                case "4":

                break;

                default:
                System.Console.WriteLine("Error: Invalid input");
                break;
            }
        }

        static string ConvertInput(string input)
        {
            input = input.ToLower();    // so I do not need to think about
                                        // every different capitalization
                                        // NeW OrdER, NEW ORDER, New order...
            input = input.Trim();   // remove trailing whitespace

            if (input == "1." ||
                input == "1" ||
                input == "new order")
            {
                return "1"; // easier to remember if just use the number options
            }

            else if (input == "2." ||
                input == "2" ||
                input == "check order")
            {
                return "2";
            }

            else if (input == "3." ||
                input == "3" ||
                input == "see past orders" ||
                input == "past orders")
            {
                return "3";
            }
            else if (input == "4." ||
                input == "4" ||
                input == "nearest location")
            {
                return "4";
            }

            else
            {
                return "invalid input";
            }
        }




    }
}
