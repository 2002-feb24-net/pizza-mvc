using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;

namespace ClientMVC.Controllers
{
    public class OrderlinesController : Controller
    {
        private readonly DbRestaurantContext _context;

        public OrderlinesController(DbRestaurantContext context)
        {
            _context = context;
        }

        // GET: Orderlines
        public async Task<IActionResult> Index()
        {
            var dbRestaurantContext = _context.Orderlines.Include(o => o.Order).Include(o => o.Product);
            return View(await dbRestaurantContext.ToListAsync());
        }

        // GET: Orderlines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderlines = await _context.Orderlines
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderlineId == id);
            if (orderlines == null)
            {
                return NotFound();
            }

            return View(orderlines);
        }

        // GET: Orderlines/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: Orderlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderlineId,ProductId,Quantity")] Orderlines orderlines, int orderId)
        {
            orderlines.OrderId = orderId;   // pass the order id that you want this item added to
            if (ModelState.IsValid)
            {
                _context.Add(orderlines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderlines.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", orderlines.ProductId);
            return View(orderlines);
        }

        // GET: Orderlines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderlines = await _context.Orderlines.FindAsync(id);
            if (orderlines == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderlines.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", orderlines.ProductId);
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
                    _context.Update(orderlines);
                    await _context.SaveChangesAsync();
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", orderlines.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", orderlines.ProductId);
            return View(orderlines);
        }

        // GET: Orderlines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderlines = await _context.Orderlines
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
            var orderlines = await _context.Orderlines.FindAsync(id);
            _context.Orderlines.Remove(orderlines);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderlinesExists(int id)
        {
            return _context.Orderlines.Any(e => e.OrderlineId == id);
        }
    }
}
