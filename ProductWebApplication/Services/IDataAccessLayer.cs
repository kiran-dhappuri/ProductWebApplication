using System.Threading.Tasks;
using ProductWebApplication.Models.Custom;

namespace ProductWebApplication.Services
{
    public interface IDataAccessLayer
    {
        Task CreateProduct(Product product);
    }
}