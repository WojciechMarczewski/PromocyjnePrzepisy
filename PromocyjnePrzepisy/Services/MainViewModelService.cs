using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisy.ViewModels;
using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Services
{
    public class MainViewModelService(IRecipeRepository recipeRepository, IRecipeProcessingService recipeProcessingService) : IViewModelService<RecipeViewModel>
    {
        private readonly IRecipeRepository _recipeRepository = recipeRepository;
        private readonly IRecipeProcessingService _recipeProcessingService = recipeProcessingService;

        public ObservableCollection<RecipeViewModel> PopulateList()
        {
            ObservableCollection<RecipeViewModel> recipeViewModels = new ObservableCollection<RecipeViewModel>();
            _recipeRepository.GetRecipes().ForEach(recipe =>
            {
                recipeViewModels.Add(new RecipeViewModel(recipe, _recipeProcessingService));
            });
            return recipeViewModels;
        }
    }
}
