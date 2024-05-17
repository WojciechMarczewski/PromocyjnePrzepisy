using PromocyjnePrzepisy.HttpServices.DTOs;
using PromocyjnePrzepisy.Models;
namespace PromocyjnePrzepisy.HttpServices
{
    public interface IHttpService
    {
        Task<List<IngredientDTO>> GetIngredientsAsync();
        Task<List<ProductDTO>> GetProductsAsync();
        Task<List<RecipeDTO>> GetRecipesAsync();
        Task SendReportAsync(Report report);
    }
}
