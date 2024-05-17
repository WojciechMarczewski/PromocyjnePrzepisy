using PromocyjnePrzepisy.Helpers;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;

namespace PromocyjnePrzepisy.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();
        private readonly IProductRepositoryService _productRepositoryService;

        public Task Initialization { get; private set; }

        public ProductRepository(IProductRepositoryService productRepositoryService)
        {
            _productRepositoryService = productRepositoryService;
            Initialization = Init();
            AsyncInitialization.Tasks.Add(Initialization);
        }

        public List<Product> GetAllProducts()
        {

            return _products;
        }

        public List<Product> GetProducts(string ingredientName)
        {
            return _products.Where(p => p.IngredientName.ToLower().Contains(ingredientName.ToLower())).ToList();
        }


        public async Task Init()
        {
            var list = await _productRepositoryService.GetProductAsync();
            _products.AddRange(list);

        }
    }
}
