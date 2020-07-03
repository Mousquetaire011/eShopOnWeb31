using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Controllers
{
    public class StocksController : Controller
    {
        private readonly CatalogContext _context;
  
       public StocksController(CatalogContext context)
        {
            _context = context;
        }
       

        // GET: Stocks
        public async Task<IActionResult> Index()
        {

            List<Stock> listStock = _context.Stock.Include(c=>c.CatalogItem).Include(s=>s.Supplier).ToList();

            return View(listStock);
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.Include(c => c.CatalogItem).Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
           StockViewModel stocks = GetListItem();
           StockViewModel model = GetSuppliers(stocks);
           return View(model);
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Stock stock)
        {
            if (ModelState.IsValid)
            {
                var catalogItem = _context.Find<CatalogItem>(stock.SelectedCatalogItemId);
                var supplier = _context.Find<Supplier>(stock.SelectedSupplierId);
                stock.CatalogItem = catalogItem;
                stock.Supplier = supplier;
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Stock stock)
        {
            if (id != stock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.Id))
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
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.Include(c => c.CatalogItem).Include(s => s.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.Id == id);
        }
        
        public StockViewModel GetListItem()
        {
            var model = new StockViewModel();
            model.stock = new Stock();
            var items = _context.CatalogItems.OrderBy(N=>N.Name);
            model.selectListItems = new List<SelectListItem>();
            foreach (var item in items)
            {
                model.selectListItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return model;
        }

        public StockViewModel GetSuppliers(StockViewModel model)
        {
            model = GetListItem();
            model.selectListSuppliers = new List<SelectListItem>();
            var suppliers = _context.Supplier.OrderBy(N => N.Name);
            foreach (var item in suppliers)
            {
                model.selectListSuppliers.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                }) ;

            }
            return model;
        }

    }
}
