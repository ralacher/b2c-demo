using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    [Authorize(Policy = "Editor")]
    public class ProductsController : Controller
    {
        // GET: MVCProducts
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = new List<Product>();
            products.Add(new Product
            {
                CreatedUserID = "1",
                Name = "Juice",
                ProductId = 1,
            });
            products.Add(new Product
            {
                CreatedUserID = "1",
                Name = "Coffee",
                ProductId = 2,
            });
            return View(products);
        }

        // GET: MVCProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = new Product
            {
                CreatedUserID = "1",
                Name = "Rob",
                ProductId = 1,
            };

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: MVCProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MVCProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,CreatedUserID")] Product product)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: MVCProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = new Product
            {
                CreatedUserID = "1",
                Name = "Rob",
                ProductId = 1,
            };

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: MVCProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,CreatedUserID")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            return View(product);
        }

        // GET: MVCProducts/Delete/5
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = new Product
            {
                CreatedUserID = "1",
                Name = "Rob",
                ProductId = 1,
            };
            
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: MVCProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = new Product
            {
                CreatedUserID = "1",
                Name = "Rob",
                ProductId = 1,
            };

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return true;
        }
    }
}
