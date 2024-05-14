using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IIngredientRepositoryService
    {
        Task<IEnumerable<Ingredient>> GetIngredientsAsync();

    }
}
