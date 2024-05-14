using PromocyjnePrzepisy.Models;
namespace PromocyjnePrzepisy.ViewModels
{
    public class IngredientViewModel : BaseViewModel
    {
        private readonly Ingredient _ingredient;
        public string Name { get { return _ingredient.Name; } }
        public List<ProductViewModel> ProductViewModels { get; }
        public bool HasDiscounts { get { return _ingredient.HasDiscounts; } }
        private List<Product> products { get { return _ingredient.Products; } }
        public IngredientViewModel(Ingredient ingredient)
        {
            _ingredient = ingredient;
            ProductViewModels = CreateProductViewModels();
        }
        private List<ProductViewModel> CreateProductViewModels()
        {
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                viewModels.Add(new ProductViewModel(product));
            }
            return viewModels;
        }
    }
}
