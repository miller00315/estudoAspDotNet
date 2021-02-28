using Data;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpPost]
        public IActionResult Save(Product product)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}