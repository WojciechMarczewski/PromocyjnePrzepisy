using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
namespace PromocyjnePrzepisy.ViewModels
{
    public class RecipeViewModel(Recipe recipe, IRecipeProcessingService recipeProcessingService) : BindableObject
    {
        public string Name { get { return _recipe.Name; } }
        public byte[] Image { get { return _recipe.Image; } }
        public int DiscountsCount { get { return _recipeProcessingService.CalculateDiscounts(_recipe); } }
        public string DiscountCountEnding { get { return _recipeProcessingService.GetProductCountEnding(DiscountsCount); } }
        private IRecipeProcessingService _recipeProcessingService = recipeProcessingService;
        private Recipe _recipe = recipe;
        public List<Ingredient> GetRecipeIngredients()
        {
            return _recipe.Ingredients;
        }
        public string RecipeDescription { get { return _recipe.Description; } }
        public EatingStyle[] EatingStyles { get { return _recipe.EatingStyleTags; } }
        public void OnImageRefresh()
        {
            OnPropertyChanged(nameof(Image));
        }
    }
}
