using PromocyjnePrzepisy.Helpers;
using PromocyjnePrzepisy.HttpServices;
using PromocyjnePrzepisy.HttpServices.DTOs;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Diagnostics;

namespace PromocyjnePrzepisy.Services
{
    public class IngredientRepositoryService : IIngredientRepositoryService
    {
        private IProductRepository _productRepository;
        private readonly HttpService _httpService;

        public IngredientRepositoryService(IProductRepository productRepository, HttpService httpService)
        {
            _productRepository = productRepository;
            _httpService = httpService;
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
        {
            await AsyncInitialization.EnsureInitializedAsync([_productRepository]).ConfigureAwait(false);
            List<IngredientDTO>? list = null;
            try
            {
                list = await _httpService.GetIngredientsAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            var ingredients = new List<Ingredient>();
            if (list != null)
            {

                foreach (var ingredient in list)
                {
                    ingredients.Add(new Ingredient(ingredient.Name, _productRepository.GetProducts(ingredient.Name)));
                }
            }
            return ingredients;
        }


    }
}
