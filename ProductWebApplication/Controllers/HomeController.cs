using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductWebApplication.Data;
using ProductWebApplication.Models;

namespace ProductWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebAppDbContext _context;
        public HomeController(WebAppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Blah blah blah. Blaaah blah blah!";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            var prodcuts = _context.Products.ToList();

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
