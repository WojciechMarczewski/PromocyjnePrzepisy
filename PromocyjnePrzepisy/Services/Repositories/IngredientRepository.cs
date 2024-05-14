using PromocyjnePrzepisy.Helpers;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
namespace PromocyjnePrzepisy.Services.Repositories
{
    public class IngredientRepository : IIngredientsRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private IIngredientRepositoryService _ingredientRepositoryService;
        public Task Initialization { get; private set; }


        public List<Ingredient> GetIngredients(List<string> ingredientsList)
        {
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
        public IngredientRepository(IIngredientRepositoryService ingredientRepositoryService)
        {
            _ingredientRepositoryService = ingredientRepositoryService;
            Initialization = Init();
            AsyncInitialization.Tasks.Add(Initialization);
        }
    }
}
