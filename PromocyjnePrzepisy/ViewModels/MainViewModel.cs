using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.Input;
using PromocyjnePrzepisy.Extensions;
using PromocyjnePrzepisy.Helpers;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace PromocyjnePrzepisy.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        private ObservableCollection<RecipeViewModel> _allRecipes { get; set; } = new ObservableCollection<RecipeViewModel>();
        private readonly IViewModelService<RecipeViewModel> _viewModelService;
        public ObservableCollection<RecipeViewModel> RecipeCollection { get; set; } = new ObservableCollection<RecipeViewModel>();
        private EatingStyle currentPagingFilter { get; set; } = EatingStyle.None;
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
            currentPagingFilter = EatingStyle.None;
        }
        [RelayCommand]
        public async Task OnCollectionRemainingItemsThresholdReached()
        {
            try
            {
                var list = await _viewModelService.GetNewObjectsAsync(currentPagingFilter);
                foreach (var element in list)
                {
                    _allRecipes.Add(element);
                    RecipeCollection.Add(element);
                }
                OnPropertyChanged(nameof(RecipeCollection));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private Task FillRecipesFilteredByMarket(Market market)
        {
            RecipeCollection.Clear();
            foreach (var recipe in _allRecipes)
            {
                var ingredientsList = recipe.GetRecipeIngredients();
                bool recipeAdded = false;
                foreach (IngredientAmount ingredientAmount in ingredientsList)
                {
                    if (ingredientAmount.Ingredient.Products.Count == 0) break;
                    var productsList = ingredientAmount.Ingredient.Products;
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
            currentPagingFilter = eatingStyle;
            return Task.CompletedTask;
        }
        public async Task FillRecipes()
        {
            try
            {
                await AsyncInitialization.EnsureInitializedAsync();
                _allRecipes = await _viewModelService.PopulateListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            _allRecipes = _allRecipes.OrderByDescending(x => x.DiscountsCount).ToObservableCollection();
            RecipeCollection = new ObservableCollection<RecipeViewModel>(_allRecipes);
            RefreshCollection();
        }
        private void RefreshCollection()
        {
            RecipeCollection.Add(_allRecipes[0]);
            RecipeCollection.RemoveAt(RecipeCollection.Count - 1);
        }
        //Fix for empty image on mainpage after page navigation
        public void RefreshImagesOnAppearing()
        {
            foreach (var recipe in RecipeCollection)
            {
                recipe.OnImageRefresh();
            }
        }
    }
}
