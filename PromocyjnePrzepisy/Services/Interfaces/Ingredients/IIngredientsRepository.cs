using PromocyjnePrzepisy.HttpServices.DTOs;
using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IIngredientsRepository : IAsyncInitialization
    {
        public Task<List<Ingredient>> GetIngredientsAsync(List<string> ingredients);
        public Task<List<IngredientAmount>> GetIngredientAmountsAsync(List<IngredientAmountDTO> ingredients);
        Task Init();
    }
}
