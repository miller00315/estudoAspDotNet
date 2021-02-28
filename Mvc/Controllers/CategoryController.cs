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
        public async Task<IActionResult> Save(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }
    }
}