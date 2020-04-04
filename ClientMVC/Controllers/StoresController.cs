using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess;
using Restaurant.DataAccess.Model;
using Restaurant.DataAccess.Repositories;

namespace ClientMVC.Controllers
{
    public class StoresController : Controller
    {
        

        // GET: Stores
        public IActionResult Index()
        {
            var storeRepo = new StoreRepository();
            return View(storeRepo.GetAllDomainStores());
        }

        // GET: Stores/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storeRepo = new StoreRepository();
            var store = storeRepo.GetDomainStore(Convert.ToInt32(id));
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StoreId,StoreName,StreetAddress,City,State,Zipcode")] Restaurant.Domain.Model.Store store)
        {
            var storeRepo = new StoreRepository();

            if (ModelState.IsValid)
            {
                var data_store = Mapper.MapStoreWithInventory(store);
                storeRepo.Add((data_store));
                storeRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(store);
        }

        /*// GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stores = await _context.Stores.FindAsync(id);
            if (stores == null)
            {
                return NotFound();
            }
            return View(stores);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreId,StoreName,StreetAddress,City,State,Zipcode")] Stores stores)
        {
            if (id != stores.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoresExists(stores.StoreId))
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
            return View(stores);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stores = await _context.Stores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (stores == null)
            {
                return NotFound();
            }

            return View(stores);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stores = await _context.Stores.FindAsync(id);
            _context.Stores.Remove(stores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoresExists(int id)
        {
            return _context.Stores.Any(e => e.StoreId == id);
        }*/
    }
}
