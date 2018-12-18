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
        private readonly IFileAccessLayer _fileLayer;
        public HomeController(WebAppDbContext context, IDataAccessLayer dataAccess, IFileAccessLayer fileLayer)
        {
            _context = context;
            _dataAccess = dataAccess;
            _fileLayer = fileLayer;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeIndex()
        {
            var prodcuts = _context.Products.Include(x => x.Images).ToList();
            var model = new HomeIndexViewModel(prodcuts, _fileLayer);
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
        public async Task<IActionResult> AddProduct(Product product, string images)
        {
            if (!ModelState.IsValid)
                return View(product);

            //TempFix
            if (!string.IsNullOrWhiteSpace(images))
            {
                var imageList = images.Split(',');
                foreach (var image in imageList)
                {
                    product.Images.Add(new ProductImage()
                    {
                        ImageName = image
                    });
                }
            }

            await _dataAccess.CreateProduct(product);
            return View(product);
        }
    }
}
