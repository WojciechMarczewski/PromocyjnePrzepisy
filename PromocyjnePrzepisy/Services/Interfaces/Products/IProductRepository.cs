using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IProductRepository : IAsyncInitialization
    {
        public List<Product>? GetProducts(string ingredientName);
        public List<Product> GetAllProducts();
        Task Init();

    }
}
