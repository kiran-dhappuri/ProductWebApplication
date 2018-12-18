using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebApplication.Data;
using ProductWebApplication.Models;
using ProductWebApplication.Models.Custom;
using ProductWebApplication.Services;

namespace ProductWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebAppDbContext _context;
        private readonly IDataAccessLayer _dataAccess;
        public HomeController(WebAppDbContext context, IDataAccessLayer dataAccess)
        {
            _context = context;
            _dataAccess = dataAccess;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeIndex()
        {
            var prodcuts = _context.Products.Include(x => x.Images).ToList();
            var model = new HomeIndexViewModel(prodcuts);
            return View(model);
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Blah blah blah. Blaaah blah blah!";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            //ToDO: remove hard coded
            product.Images = new List<ProductImage>();
            product.Images.Add(new ProductImage()
            {
                ImageName = "14AFUK-Ot-bqL_CVgRjamn3Cp0NyWaTga"
            });
            product.Images.Add(new ProductImage()
            {
                ImageName = "1UZw1Ai38C2hQ_RDmIkCF3ogoN_FbLi3q"
            });
            // remove above

            await _dataAccess.CreateProduct(product);
            return View(product);
        }
    }
}
