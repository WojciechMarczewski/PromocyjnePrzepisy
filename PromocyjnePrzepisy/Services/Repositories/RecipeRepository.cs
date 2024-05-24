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
            PagingHelper.SetPagingCountersOnStart(list.ToList());
        }

        public async Task<List<Recipe>> GetNewRecipesAsync(EatingStyle filter)
        {
            List<Recipe> recipeList = new List<Recipe>();
            bool recipesAdded = false;
            if (filter == EatingStyle.MeatEater)
            {
                var awaitedList = await _recipeRepositoryService.GetNewRecipesAsync(filter.ToString(), PagingHelper.GetNextMeatPageValue());
                recipeList.AddRange(awaitedList);
                recipesAdded = true;
            }
            if (filter == EatingStyle.Vegan && !recipesAdded)
            {
                var awaitedList = await _recipeRepositoryService.GetNewRecipesAsync(filter.ToString(), PagingHelper.GetNextVeganPageValue());
                recipeList.AddRange(awaitedList);
                recipesAdded = true;
            }
            if (filter == EatingStyle.Vegetarian && !recipesAdded)
            {
                var awaitedList = await _recipeRepositoryService.GetNewRecipesAsync(filter.ToString(), PagingHelper.GetNextVegetarianPageValue());
                recipeList.AddRange(awaitedList);
                recipesAdded = true;
            }
            if (filter == EatingStyle.None && !recipesAdded)
            {
                var awaitedList = await _recipeRepositoryService.GetNewRecipesAsync(filter.ToString(), PagingHelper.GetNextGeneralPageValue());
                recipeList.AddRange(awaitedList);

            }


            _recipes.AddRange(recipeList);
            return recipeList;
        }
    }
}
