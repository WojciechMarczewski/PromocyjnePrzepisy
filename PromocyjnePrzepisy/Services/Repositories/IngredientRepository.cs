using PromocyjnePrzepisy.Helpers;
using PromocyjnePrzepisy.HttpServices.DTOs;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Diagnostics;
namespace PromocyjnePrzepisy.Services.Repositories
{
    public class IngredientRepository : IIngredientsRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private IIngredientRepositoryService _ingredientRepositoryService;
        public Task Initialization { get; private set; }


        public async Task<List<Ingredient>> GetIngredientsAsync(List<string> ingredientsList)
        {
            await AsyncInitialization.EnsureInitializedAsync(_ingredientRepositoryService);
            List<Ingredient> result = new List<Ingredient>();
            foreach (string ingredientName in ingredientsList)
            {
                Ingredient? ingredient = _ingredients.FirstOrDefault(i => i.Name.ToLower().Equals(ingredientName.ToLower()));
                if (ingredient != null)
                {
                    result.Add(ingredient);
                }
            }
            return result;
        }

        public async Task Init()
        {
            var list = await _ingredientRepositoryService.GetIngredientsAsync();
            _ingredients.AddRange(list);
        }

        public async Task<List<IngredientAmount>> GetIngredientAmountsAsync(List<IngredientAmountDTO> ingredients)
        {
            await AsyncInitialization.EnsureInitializedAsync(_ingredientRepositoryService);
            List<IngredientAmount> result = new List<IngredientAmount>();
            foreach (var ingredientAmountDTO in ingredients)
            {
                Ingredient? ingredient = _ingredients.FirstOrDefault(i => i.Name.ToLower().Equals(ingredientAmountDTO.Ingredient.ToLower()));
                if (ingredient != null && ingredientAmountDTO.Amount != null)
                {
                    result.Add(new IngredientAmount(ingredient, ingredientAmountDTO.Amount));
                }
                else
                {
                    Debug.WriteLine("Couldn't create ingredient amount object as some value was null");
                }

            }
            return result;
        }

        public IngredientRepository(IIngredientRepositoryService ingredientRepositoryService)
        {
            _ingredientRepositoryService = ingredientRepositoryService;
            Initialization = Init();
            AsyncInitialization.Tasks.Add(Initialization);
        }
    }
}
