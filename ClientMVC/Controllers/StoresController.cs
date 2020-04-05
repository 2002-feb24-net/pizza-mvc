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
        private readonly StoreRepository storeRepo = new StoreRepository();

        // GET: Stores
        public async Task<IActionResult> Index([FromQuery]string search = "")
        {
            IEnumerable<Stores> stores = storeRepo.GetContains(search);

            return View(stores);
        }

        // GET: Stores/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

/*            var storeRepo = new StoreRepository();
*/            var store = storeRepo.GetDomainStore(Convert.ToInt32(id));
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

        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stores = storeRepo.Get(Convert.ToInt32(id));
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
        public async Task<IActionResult> Edit(int id, [Bind("StoreId,StoreName,StreetAddress,City,State,Zipcode")] Restaurant.Domain.Model.Store stores)
        {
            if (id != stores.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    storeRepo.Add(Mapper.MapStoreWithInventory(stores));
                    /*await*/ storeRepo.Save();
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

            var stores = storeRepo.Find((m => m.StoreId == id)).FirstOrDefault();
            if (stores == null)
            {
                return NotFound();
            }

            return View(Mapper.MapStoreWithInventory(stores));
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stores = storeRepo.Get(id);
            storeRepo.Remove(stores);
            storeRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool StoresExists(int id)
        {

            var stores = storeRepo.Find((m => m.StoreId == id));
            if (stores == null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
