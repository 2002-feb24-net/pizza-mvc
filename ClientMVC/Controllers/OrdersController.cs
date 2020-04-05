using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using Restaurant.DataAccess.Repositories;
using ClientMVC.ViewModels;

namespace ClientMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderRepository orderRepo = new OrderRepository();

        

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var listOfOrders = orderRepo.GetAllOrdersIncludeCustomerAndStore();
            return View(listOfOrders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = orderRepo.GetOrderWithDetails(Convert.ToInt32(id));
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            var custRepo = new CustomerRepository();
            var storeRepo = new StoreRepository();
            var inventoryRepo = new InventoryRepository();
            var orderlineRepo = new OrderlineRepository();

/*            var inventorysAndProducts = storeRepo.GetProductsInStock();
*/
            ViewData["CustomerId"] = new SelectList(custRepo.GetAll(), "CustomerId", "FullName");
            ViewData["StoreId"] = new SelectList(storeRepo.GetAll(), "StoreId", "StoreName");
            ViewData["ProductID"] = new SelectList(inventoryRepo.GetAll(), "ProductId", "ProductName");
            ViewData["InventoryID"] = new SelectList(orderlineRepo.GetAll(), "InventoryId", "Quantity");
            return View();
        }

        /*// POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,Total,TimeOrdered,CustomerId,StoreId")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                orderRepo.Add(orders);
                await orderRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(orderRepo.Customers, "CustomerId", "FullName", orders.CustomerId);
            ViewData["StoreId"] = new SelectList(orderRepo.Stores, "StoreId", "StoreName", orders.StoreId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await orderRepo.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(orderRepo.Customers, "CustomerId", "FullName", orders.CustomerId);
            ViewData["StoreId"] = new SelectList(orderRepo.Stores, "StoreId", "StoreName", orders.StoreId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Total,TimeOrdered,CustomerId,StoreId")] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    orderRepo.Update(orders);
                    await orderRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(orderRepo.Customers, "CustomerId", "FullName", orders.CustomerId);
            ViewData["StoreId"] = new SelectList(orderRepo.Stores, "StoreId", "StoreName", orders.StoreId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await orderRepo.Orders
                .Include(o => o.Customer)
                .Include(o => o.Store)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await orderRepo.Orders.FindAsync(id);
            orderRepo.Orders.Remove(orders);
            await orderRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return orderRepo.Orders.Any(e => e.OrderId == id);
        }*/
    }
}
