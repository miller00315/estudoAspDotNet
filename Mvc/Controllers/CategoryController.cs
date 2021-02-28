using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(Category model)
        {
            if (model.ID == 0)
                _context.Categories.Add(model);
            else
            {
                var category = _context.Categories.First(c => c.ID == model.ID);

                category.Name = model.Name;
                category.PermitStock = model.PermitStock;
            }


            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.First(c => c.ID == id);

            return View("Save", category);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = _context.Categories.First(c => c.ID == id);

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}