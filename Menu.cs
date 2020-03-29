using System;

namespace harold_project0
{
    class Menu
    {
        static void DisplayMenu()
        {
            System.Console.WriteLine("Welcome to Backgammon pizza");
            System.Console.WriteLine("Type an option:");
            System.Console.WriteLine("1. New Order");
            System.Console.WriteLine("2. Check Order");
            // current pizza order, sign in
            System.Console.WriteLine("3. See Past Orders");
            System.Console.WriteLine("4. Nearest Location");
            // return one option or a list
            // Hardcoded for arlington?
            string input = Console.ReadLine();
            GuideInput(input);


        }

        static void GuideInput(string input)
        {
            input = ConvertInput(input);    // make input standardized to shorten conditional statements
            Switch(input);
        }

        static void Switch(string input)
        {
            switch (input)
            {
                case "1":
                CarryOutOrDelivery();
                Pizza.ShowOptions();

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
