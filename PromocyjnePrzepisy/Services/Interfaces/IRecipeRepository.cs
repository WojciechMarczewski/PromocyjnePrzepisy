using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IRecipeRepository
    {
        public List<Recipe> GetRecipes();
    }
}
