using PromocyjnePrzepisy.Helpers;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
namespace PromocyjnePrzepisy.Services.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private List<Recipe> _recipes = new List<Recipe>();
        private readonly IRecipeRepositoryService _recipeRepositoryService;
        public Task Initialization { get; private set; }
        public List<Recipe> GetRecipes()
        {
            return _recipes;
        }
        public RecipeRepository(IRecipeRepositoryService recipeRepositoryService)
        {
            _recipeRepositoryService = recipeRepositoryService;
            Initialization = Init();
            AsyncInitialization.Tasks.Add(Initialization);
        }
        public async Task Init()
        {
            var list = await _recipeRepositoryService.GetRecipesAsync();
            _recipes.AddRange(list);
        }
    }
}
