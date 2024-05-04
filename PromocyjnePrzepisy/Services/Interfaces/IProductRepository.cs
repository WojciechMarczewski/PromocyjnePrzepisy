using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IProductRepository
    {
        public List<Product>? GetProducts(string ingredientName);
    }
}
