using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IRecipeRepository : IAsyncInitialization
    {
        public List<Recipe> GetRecipes();
        Task Init();
        public Task<List<Recipe>> GetNewRecipesAsync(EatingStyle filter);
    }
}
