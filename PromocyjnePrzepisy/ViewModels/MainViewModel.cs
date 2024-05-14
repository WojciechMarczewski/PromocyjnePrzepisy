using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Input;
using PromocyjnePrzepisy.Extensions;
using PromocyjnePrzepisy.Helpers;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Collections.ObjectModel;
namespace PromocyjnePrzepisy.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private ObservableCollection<RecipeViewModel> _allRecipes { get; set; } = new ObservableCollection<RecipeViewModel>();
        private readonly IViewModelService<RecipeViewModel> _viewModelService;
        public ObservableCollection<RecipeViewModel> RecipeCollection { get; set; } = new ObservableCollection<RecipeViewModel>();
        public MainViewModel(IViewModelService<RecipeViewModel> viewModelService)
        {
            _viewModelService = viewModelService;
        }
        [RelayCommand]
        private async Task ShowRecipesByMarket(Market parameter)
        {
            await FillRecipesFilteredByMarket(parameter);
        }
        [RelayCommand]
        private async Task ShowRecipesByStyle(EatingStyle parameter)
        {
            await FillRecipesFilteredByStyle(parameter);
        }
        [RelayCommand]
        private void ShowAllRecipes()
        {
            RecipeCollection.Clear();
            RecipeCollection.ReplaceWith<RecipeViewModel>(_allRecipes);
        }
        private Task FillRecipesFilteredByMarket(Market market)
        {
            RecipeCollection.Clear();
            foreach (var recipe in _allRecipes)
            {
                var ingredientsList = recipe.GetRecipeIngredients();
                bool recipeAdded = false;
                foreach (Ingredient ingredient in ingredientsList)
                {
                    if (ingredient.Products.Count == 0) break;
                    var productsList = ingredient.Products;
                    foreach (Product product in productsList)
                    {
                        if (product.Market == market) RecipeCollection.Add(recipe);
                        recipeAdded = true;
                        break;
                    }
                    if (recipeAdded) break;
                }
            }
            return Task.CompletedTask;
        }
        private Task FillRecipesFilteredByStyle(EatingStyle eatingStyle)
        {
            RecipeCollection.Clear();
            foreach (var recipe in _allRecipes)
            {
                if (recipe.EatingStyles.Contains<EatingStyle>(eatingStyle))
                {
                    RecipeCollection.Add(recipe);
                }
            }
            return Task.CompletedTask;
        }
        public async Task FillRecipes()
        {
            await AsyncInitialization.EnsureInitializedAsync();
            _allRecipes = await _viewModelService.PopulateListAsync();
            _allRecipes = _allRecipes.OrderByDescending(x => x.DiscountsCount).ToObservableCollection();
            RecipeCollection = new ObservableCollection<RecipeViewModel>(_allRecipes);
            RecipeCollection.Add(_allRecipes[0]);
            RecipeCollection.RemoveAt(RecipeCollection.Count - 1);
        }
    }
}
