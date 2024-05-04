using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;

namespace PromocyjnePrzepisy.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();
        public ProductRepository()
        {
            CreateFooData();
        }
        public List<Product> GetProducts(string ingredientName)
        {
            return _products.Where(p => p.IngredientName.ToLower().Equals(ingredientName.ToLower())).ToList();
        }
        private void CreateFooData()
        {
            DateOnly todayDate = DateOnly.FromDateTime(DateTime.Now);
            DateOnly subtractedDate = DateOnly.FromDateTime(DateTime.Today.Subtract(TimeSpan.FromDays(7)));
            Discount discount = new Discount(subtractedDate, todayDate);
            _products.Add(new Product("Mięso Mielone wieprzowe z Biedronki 500g", "Mięso Mielone Wieprzowe", discount, [], Market.Biedronka));
            _products.Add(new Product("Olej Kujawski 1l", "Olej Rzepakowy", discount, [], Market.Aldi));
        }
    }
}
