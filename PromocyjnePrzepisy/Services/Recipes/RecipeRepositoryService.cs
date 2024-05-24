
using PromocyjnePrzepisy.Helpers;
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
        private int page { get; set; } = 0;
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


            if (list != null)
            {
                return await ConvertToRecipesList(list);
            }
            else
            {
                Debug.WriteLine("Couldn't load recipeDTO list");
                return new List<Recipe>();
            }


        }
        private async Task<List<Recipe>> ConvertToRecipesList(List<RecipeDTO> recipeDTOs)
        {
            var recipes = new List<Recipe>();
            if (recipeDTOs != null)
            {
                try
                {
                    await AsyncInitialization.EnsureInitializedAsync(_ingredientsRepository).ConfigureAwait(false);
                    foreach (var recipeDTO in recipeDTOs)
                    {
                        var ingredientsDTOs = recipeDTO.Ingredients;
                        var ingredientsList = await _ingredientsRepository.GetIngredientAmountsAsync(ingredientsDTOs);
                        recipes.Add(new Recipe(recipeDTO.Name, recipeDTO.Description, ingredientsList,
                            Convert.FromBase64String(recipeDTO.base64Image), recipeDTO.EatingStyleTags));
                    }
                    page++;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }

            return recipes;
        }

        public async Task<IEnumerable<Recipe>> GetNewRecipesAsync(string filter, int[] paging)
        {
            var list = new List<RecipeDTO>();
            try
            {
                list = await _httpService.GetMoreRecipesAsync(filter, paging).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            if (list != null)
            {
                return await ConvertToRecipesList(list);
            }
            else
            {
                Debug.WriteLine("Couldn't load recipeDTO list");
                return new List<Recipe>();
            }

        }

        public RecipeRepositoryService(HttpService httpService, IIngredientsRepository ingredientsRepository)
        {
            _httpService = httpService;
            _ingredientsRepository = ingredientsRepository;
        }

    }
}
