using System;
using System.Collections.Generic;

namespace harold_project0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //menu static call or object
        }

        static void PopulateProductList(string variationName, decimal price, Dictionary<string, decimal> productAndPrices)
        {
            productAndPrices.Add(variationName, price);

        }
    }
}
