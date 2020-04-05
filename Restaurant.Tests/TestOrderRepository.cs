using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.DataAccess.Repositories;
using Restaurant.DataAccess.Model;
using Xunit;

namespace Restaurant.Tests
{
    public class TestOrderRepository
    {
        [Fact]
        public void QueryCustomersFindById()
        {
            var storeRepo = new StoreRepository();
            var storeID = 1;
            var list = storeRepo.GetProductsInStock(storeID);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
