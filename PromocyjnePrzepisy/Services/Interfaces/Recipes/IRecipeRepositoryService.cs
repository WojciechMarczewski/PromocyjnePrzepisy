using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IRecipeRepositoryService
    {
        Task<IEnumerable<Recipe>> GetRecipesAsync();
    }
}
