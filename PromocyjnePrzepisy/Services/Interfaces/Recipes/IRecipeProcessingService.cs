using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IRecipeProcessingService
    {
        int CalculateDiscounts(Recipe recipe);
        string GetProductCountEnding(int discountsCount);
    }
}
