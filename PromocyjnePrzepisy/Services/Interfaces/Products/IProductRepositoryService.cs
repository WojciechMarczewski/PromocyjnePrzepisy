using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IProductRepositoryService
    {
        Task<IEnumerable<Product>> GetProductAsync();
    }
}
