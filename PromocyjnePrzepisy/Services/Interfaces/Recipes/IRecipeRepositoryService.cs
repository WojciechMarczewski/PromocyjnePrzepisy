using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IRecipeRepositoryService
    {
        Task<IEnumerable<Recipe>> GetRecipesAsync();
        Task<IEnumerable<Recipe>> GetNewRecipesAsync(string filter, int[] paging);
    }
}
