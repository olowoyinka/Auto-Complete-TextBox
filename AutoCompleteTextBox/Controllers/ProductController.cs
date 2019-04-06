using AutoCompleteTextBox.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoCompleteTextBox.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}