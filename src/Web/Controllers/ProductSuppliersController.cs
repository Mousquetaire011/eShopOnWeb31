using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.Infrastructure.Data;

namespace Microsoft.eShopWeb.Web.Controllers
{
    public class ProductSuppliersController : Controller
    {
        private readonly CatalogContext _context;

        public ProductSuppliersController(CatalogContext context)
        {
            _context = context;
        }

        // GET: ProductSuppliers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductSuppliers.ToListAsync());
        }

        // GET: ProductSuppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSupplier = await _context.ProductSuppliers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSupplier == null)
            {
                return NotFound();
            }

            return View(productSupplier);
        }

        // GET: ProductSuppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ProductSupplier productSupplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSupplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productSupplier);
        }

        // GET: ProductSuppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSupplier = await _context.ProductSuppliers.FindAsync(id);
            if (productSupplier == null)
            {
                return NotFound();
            }
            return View(productSupplier);
        }

        // POST: ProductSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ProductSupplier productSupplier)
        {
            if (id != productSupplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSupplierExists(productSupplier.Id))
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
            return View(productSupplier);
        }

        // GET: ProductSuppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSupplier = await _context.ProductSuppliers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSupplier == null)
            {
                return NotFound();
            }

            return View(productSupplier);
        }

        // POST: ProductSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSupplier = await _context.ProductSuppliers.FindAsync(id);
            _context.ProductSuppliers.Remove(productSupplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSupplierExists(int id)
        {
            return _context.ProductSuppliers.Any(e => e.Id == id);
        }
    }
}
