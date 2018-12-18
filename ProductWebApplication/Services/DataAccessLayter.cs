using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductWebApplication.Data;
using ProductWebApplication.Models.Custom;

namespace ProductWebApplication.Services
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly WebAppDbContext _context;
        public DataAccessLayer(WebAppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
