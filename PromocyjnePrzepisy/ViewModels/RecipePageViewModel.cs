using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.ViewModels
{
    public partial class RecipePageViewModel : BaseViewModel
    {
        private RecipeViewModel _recipeViewModel { get; }
        public RecipePageViewModel(RecipeViewModel recipeViewModel)
        {
            _recipeViewModel = recipeViewModel;
            Ingredients = CreateIngredientViewModels();
        }
        public string RecipeTitle { get { return _recipeViewModel.Name; } }
        public List<IngredientViewModel> Ingredients { get; }
        public byte[] Image { get { return _recipeViewModel.Image; } }
        public string RecipeDescription { get { return _recipeViewModel.RecipeDescription; } }
        private List<Ingredient> ingredients { get { return _recipeViewModel.GetRecipeIngredients(); } }
        private List<IngredientViewModel> CreateIngredientViewModels()
        {
            List<IngredientViewModel> viewModels = new List<IngredientViewModel>();
            foreach (var ingredient in ingredients)
            {
                viewModels.Add(new IngredientViewModel(ingredient));
            }
            return viewModels;
        }

    }
}
