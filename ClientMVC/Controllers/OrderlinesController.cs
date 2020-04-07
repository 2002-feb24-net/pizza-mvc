using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using Restaurant.DataAccess.Repositories;

namespace ClientMVC.Controllers
{
    public class OrderlinesController : Controller
    {
        private readonly OrderRepository orderRepo = new OrderRepository();
        readonly OrderlineRepository OrderlineRepo = new OrderlineRepository();
        CustomerRepository custRepo = new CustomerRepository();
        StoreRepository storeRepo = new StoreRepository();

        

        // GET: Orderlines
        public async Task<IActionResult> Index()
        {
            var listOrderlines = OrderlineRepo.GetAllOrderlinesIncludeAll();

            return View(listOrderlines);
        }

        // GET: Orderlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderline = OrderlineRepo.GetOrderlineIncludeAll(id);
            if (orderline == null)
            {
                return NotFound();
            }

            return View(orderline);
        }

        // GET: Orderlines/Create
        public IActionResult Create()
        {
            var lastOrderPlaced = orderRepo.GetLastOrderPlaced();   // empty order placed in orderController create
                                                                    // or get order in progress
            ViewData["ProductId"] = new SelectList(storeRepo.GetProductsInStock(lastOrderPlaced.StoreId), "ProductId", "ProductName");
            return View();
        }

        // POST: Orderlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Quantity, OrderId")] Orderlines orderlines)
        {
            var lastOrderPlaced = orderRepo.GetLastOrderPlaced();   // empty order placed in orderController create
                                                                    // or get order in progress
            orderlines.OrderId = lastOrderPlaced.OrderId;
            if (ModelState.IsValid)
            {
                OrderlineRepo.Add(orderlines);
                OrderlineRepo.Save();
                return RedirectToAction(nameof(Create)); // Continue adding to cart
            }
            ViewData["OrderId"] = new SelectList(OrderlineRepo.GetAllOrderlinesIncludeAll(), "Orderline.OrderId", "Orderline.OrderId", orderlines.OrderId);
            ViewData["ProductId"] = new SelectList(OrderlineRepo.GetAllOrderlinesIncludeAll(), "Orderline.ProductId", "Orderline.ProductName", orderlines.ProductId);
            return View(orderlines);
        }

        public async Task<IActionResult> RedirectToOrderDetails()
        {
            /*var lastOrderPlaced = orderRepo.GetLastOrderPlaced();   // empty order placed in orderController create
                                                                    // or get order in progress  */ 


            // Orders/Details/71
            string ordersController = "Orders";
            return RedirectToAction(nameof(Index), ordersController) ;
           
        }

        /*// GET: Orderlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderlines = await OrderlineRepo.Orderlines.FindAsync(id);
            if (orderlines == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(OrderlineRepo.Orders, "OrderId", "OrderId", orderlines.OrderId);
            ViewData["ProductId"] = new SelectList(OrderlineRepo.Products, "ProductId", "ProductName", orderlines.ProductId);
            return View(orderlines);
        }

        // POST: Orderlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderlineId,ProductId,OrderId,Quantity")] Orderlines orderlines)
        {
            if (id != orderlines.OrderlineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    OrderlineRepo.Update(orderlines);
                    await OrderlineRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderlinesExists(orderlines.OrderlineId))
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
            ViewData["OrderId"] = new SelectList(OrderlineRepo.Orders, "OrderId", "OrderId", orderlines.OrderId);
            ViewData["ProductId"] = new SelectList(OrderlineRepo.Products, "ProductId", "ProductName", orderlines.ProductId);
            return View(orderlines);
        }

        // GET: Orderlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderlines = await OrderlineRepo.Orderlines
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderlineId == id);
            if (orderlines == null)
            {
                return NotFound();
            }

            return View(orderlines);
        }

        // POST: Orderlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderlines = await OrderlineRepo.Orderlines.FindAsync(id);
            OrderlineRepo.Orderlines.Remove(orderlines);
            await OrderlineRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderlinesExists(int id)
        {
            return OrderlineRepo.Orderlines.Any(e => e.OrderlineId == id);
        }*/
    }
}
