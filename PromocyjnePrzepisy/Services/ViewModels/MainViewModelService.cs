using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisy.ViewModels;
using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Services
{
    public class MainViewModelService(IRecipeRepository recipeRepository, IRecipeProcessingService recipeProcessingService) : IViewModelService<RecipeViewModel>
    {
        private readonly IRecipeRepository _recipeRepository = recipeRepository;
        private readonly IRecipeProcessingService _recipeProcessingService = recipeProcessingService;

        public async Task<ObservableCollection<RecipeViewModel>> GetNewObjectsAsync(EatingStyle filter)
        {

            var recipes = await _recipeRepository.GetNewRecipesAsync(filter);

            ObservableCollection<RecipeViewModel> recipeViewModels = new ObservableCollection<RecipeViewModel>();
            foreach (var recipe in recipes)
            {
                recipeViewModels.Add(new RecipeViewModel(recipe, _recipeProcessingService));
            }
            return recipeViewModels;
        }



        public ObservableCollection<RecipeViewModel> PopulateList()
        {
            throw new NotImplementedException();
        }

        public async Task<ObservableCollection<RecipeViewModel>> PopulateListAsync()
        {
            await _recipeRepository.Initialization.ConfigureAwait(false);
            ObservableCollection<RecipeViewModel> recipeViewModels = new ObservableCollection<RecipeViewModel>();
            _recipeRepository.GetRecipes().ForEach(recipe =>
            {
                recipeViewModels.Add(new RecipeViewModel(recipe, _recipeProcessingService));
            });
            return recipeViewModels;
        }


    }
}
