using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductWebApplication.Services;

namespace ProductWebApplication.Models.Custom
{
    public class HomeIndexViewModel
    {
        private readonly IFileAccessLayer _fileLayer;
        public HomeIndexViewModel(List<Product> products, IFileAccessLayer fileLayer)
        {
            Products = products;
            _fileLayer = fileLayer;
            UpdateProductImageUrls();
        }
        public List<Product> Products { get; private set; }

        private void UpdateProductImageUrls()
        {
            foreach (var product in Products)
            {
                foreach (var image in product.Images)
                {
                    image.ImageName = _fileLayer.GetFileUrl(image.ImageName);
                }
            }
        }
    }
}
