using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoCompleteTextBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoCompleteTextBox.Controllers
{
    [Route("api/Product")]
    public class ProductRestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductRestController(ApplicationDbContext context)
        {
            _context = context;
        }
       
       
        [Produces("application/json")]
        [HttpGet("search")]
        public IActionResult Search ()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = _context.Products.Where(p => p.Name.Contains(term, StringComparison.InvariantCultureIgnoreCase))
                                .Select(p => p.Name)
                                .ToList();

                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}