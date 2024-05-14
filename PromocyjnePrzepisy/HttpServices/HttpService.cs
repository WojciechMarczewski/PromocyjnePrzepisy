using PromocyjnePrzepisy.HttpServices.DTOs;
using System.Diagnostics;
using System.Text.Json;
namespace PromocyjnePrzepisy.HttpServices
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseAddress = "http://10.0.2.2:5163/";
        private readonly string recipesApiURL = "api/recipes/";
        private readonly string ingredientsApiURL = "api/ingredients/";
        private readonly string productsApiURL = "api/products/";
        public HttpService()
        {
        }
        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            string responseBody = "";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(baseAddress + productsApiURL).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            productDTOs = JsonSerializer.Deserialize<List<ProductDTO>>(responseBody);
            return productDTOs;
        }
        public async Task<List<IngredientDTO>> GetIngredientsAsync()
        {
            List<IngredientDTO> ingredientDTOs = new List<IngredientDTO>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(baseAddress + ingredientsApiURL).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                ingredientDTOs = JsonSerializer.Deserialize<List<IngredientDTO>>(responseBody);
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            return ingredientDTOs;
        }
        public async Task<List<RecipeDTO>> GetRecipesAsync()
        {
            List<RecipeDTO> recipeDTOs = new List<RecipeDTO>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(baseAddress + recipesApiURL).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                recipeDTOs = JsonSerializer.Deserialize<List<RecipeDTO>>(responseBody);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return recipeDTOs;
        }
        private HttpMessageHandler GetHttpMessageHandler()
        {
#if ANDROID
            var handler = new Xamarin.Android.Net.AndroidMessageHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert != null && cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
            return handler;
#endif
            throw new PlatformNotSupportedException("Only Android supported");
        }
    }
}
