using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Controllers
{
    public class BankingOperationsController : Controller
    {
        private readonly CatalogContext _context;

        public BankingOperationsController(CatalogContext context)
        {
            _context = context;
        }

        // GET: BankingOperations
        public async Task<IActionResult> Index()
        {
            return View(await _context.BankingOperations.ToListAsync());
        }

        // GET: BankingOperations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankingOperations = await _context.BankingOperations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankingOperations == null)
            {
                return NotFound();
            }

            return View(bankingOperations);
        }

        // GET: BankingOperations/Create
        public IActionResult Create()
        {
            BankingOperationViewModel financialMove = GetListOrder();
            return View(financialMove);
        }

        // POST: BankingOperations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankingOperations bankingOperations)
        {
            if (ModelState.IsValid)
            {
                var order = _context.Find<Order>(bankingOperations.SelectedOrderId);
                bankingOperations.Order = order;
                _context.Add(bankingOperations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankingOperations);
        }

        // GET: BankingOperations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankingOperations = await _context.BankingOperations.FindAsync(id);
            if (bankingOperations == null)
            {
                return NotFound();
            }
            return View(bankingOperations);
        }

        // POST: BankingOperations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BankingOperations bankingOperations)
        {
            if (id != bankingOperations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankingOperations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankingOperationsExists(bankingOperations.Id))
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
            return View(bankingOperations);
        }

        // GET: BankingOperations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankingOperations = await _context.BankingOperations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bankingOperations == null)
            {
                return NotFound();
            }

            return View(bankingOperations);
        }

        // POST: BankingOperations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankingOperations = await _context.BankingOperations.FindAsync(id);
            _context.BankingOperations.Remove(bankingOperations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankingOperationsExists(int id)
        {
            return _context.BankingOperations.Any(e => e.Id == id);
        }

        public BankingOperationViewModel GetListOrder()
        {
            var model = new BankingOperationViewModel();
            model.bankingOperations = new BankingOperations();
            var items = _context.Orders.OrderBy(N => N.OrderDate);
            model.orders = new List<SelectListItem>();
            foreach (var item in items)
            {
                model.orders.Add(new SelectListItem
                {
                    Text = item.OrderDate.ToString(),
                    Value = item.Id.ToString()
                });
            }
            return model;
        }
    }
}
