using PromocyjnePrzepisy.HttpServices.DTOs;
namespace PromocyjnePrzepisy.HttpServices
{
    public interface IHttpService
    {
        Task<List<IngredientDTO>> GetIngredientsAsync();
        Task<List<ProductDTO>> GetProductsAsync();
        Task<List<RecipeDTO>> GetRecipesAsync();
    }
}
