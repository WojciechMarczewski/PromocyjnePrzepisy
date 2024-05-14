
using PromocyjnePrzepisy.HttpServices;
using PromocyjnePrzepisy.HttpServices.DTOs;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Diagnostics;

namespace PromocyjnePrzepisy.Services
{
    public class RecipeRepositoryService : IRecipeRepositoryService
    {
        private readonly HttpService _httpService;
        private readonly IIngredientsRepository _ingredientsRepository;
        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            List<RecipeDTO>? list = null;
            try
            {
                list = await _httpService.GetRecipesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            var recipes = new List<Recipe>();
            if (list != null)
            {
                foreach (var recipe in list)
                {
                    recipes.Add(new Recipe(recipe.Name, recipe.Description, _ingredientsRepository.GetIngredients(recipe.Ingredients),
                        Convert.FromBase64String(recipe.base64Image), recipe.EatingStyleTags));
                }
            }
            return recipes;

        }
        public RecipeRepositoryService(HttpService httpService, IIngredientsRepository ingredientsRepository)
        {
            _httpService = httpService;
            _ingredientsRepository = ingredientsRepository;
        }

    }
}
