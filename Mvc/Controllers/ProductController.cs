using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Save()
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(Product model)
        {
            if (model.ID == 0)
                _context.Products.Add(model);
            else
            {
                var product = _context.Products.First(p => p.ID == model.ID);
                product.Name = model.Name;
                product.CategoryID = model.CategoryID;
                product.IsActive = model.IsActive;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {

            var query = _context.Products
            .Where(p => p.IsActive && p.Category.PermitStock)
            .OrderBy(p => p.Name);

            if (!query.Any())
                return View(new List<Product>());

            return View(query.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();

            var product = _context.Products.First(p => p.ID == id);

            return View("Save", product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _context.Products.First(p => p.ID == id);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}