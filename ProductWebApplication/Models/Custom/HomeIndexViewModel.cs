using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApplication.Models.Custom
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel(List<Product> products)
        {
            Products = products;
        }
        public List<Product> Products { get; private set; }
    }
}
