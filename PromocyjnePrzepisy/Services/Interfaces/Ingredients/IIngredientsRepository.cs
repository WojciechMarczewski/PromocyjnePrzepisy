using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IIngredientsRepository : IAsyncInitialization
    {
        public List<Ingredient> GetIngredients(List<string> ingredients);
        Task Init();
    }
}
