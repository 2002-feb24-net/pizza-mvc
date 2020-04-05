using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using Restaurant.DataAccess.Repositories;

namespace ClientMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerRepository custRepo = new CustomerRepository();

        

        // GET: Customers
        public async Task<IActionResult> Index([FromQuery]string search = "")
        {
            IEnumerable<Customers> customers = custRepo.GetContains(search);
            
            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers =  custRepo.Find
                (m => m.CustomerId == id).FirstOrDefault();
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,FullName,Username,Password")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                custRepo.Add(customers);
                custRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(customers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = custRepo.Get(Convert.ToInt32(id));
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FullName,Username,Password")] Customers customers)
        {
            if (id != customers.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    custRepo.Add(customers);
                    custRepo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.CustomerId))
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
            return View(customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = custRepo.Find
                (m => m.CustomerId == id).FirstOrDefault();
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customers = custRepo.Get(id);
            custRepo.Remove(customers);
            custRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(int id)
        {
            return custRepo.Any(e => e.CustomerId == id);
        }
    }
}
