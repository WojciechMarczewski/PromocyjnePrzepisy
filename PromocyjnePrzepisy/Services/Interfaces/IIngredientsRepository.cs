using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IIngredientsRepository
    {
        public List<Ingredient> GetIngredients(List<string> ingredients);
    }
}
