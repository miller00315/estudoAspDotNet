using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Category category)
        {
            return View();
        }
    }
}