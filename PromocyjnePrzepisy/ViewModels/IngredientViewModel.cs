using PromocyjnePrzepisy.Models;
namespace PromocyjnePrzepisy.ViewModels
{
    public class IngredientViewModel : BaseViewModel
    {
        private readonly IngredientAmount _ingredientAmount;
        public string Name { get { return _ingredientAmount.Ingredient.Name; } }
        public string Amount { get { return _ingredientAmount.Amount; } }
        public List<ProductViewModel> ProductViewModels { get; }
        public bool HasDiscounts { get { return _ingredientAmount.Ingredient.HasDiscounts; } }
        private List<Product> products { get { return _ingredientAmount.Ingredient.Products; } }
        public IngredientViewModel(IngredientAmount ingredientAmount)
        {
            _ingredientAmount = ingredientAmount;
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
