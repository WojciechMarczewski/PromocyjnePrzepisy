using Json.More;
using PromocyjnePrzepisy.HttpServices.DTOs;
using PromocyjnePrzepisy.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
namespace PromocyjnePrzepisy.HttpServices
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string baseAddress = "http://10.0.2.2:5163/";
        private readonly string recipesApiURL = "api/Recipes/";
        private readonly string ingredientsApiURL = "api/ingredients/";
        private readonly string productsApiURL = "api/products/";
        private readonly string reportsApiURL = "api/reports/";
        private readonly string leafletsApiURL = "api/leaflets/";

        public HttpService()
        {
        }
        public async Task<List<ProductDTO>?> GetProductsAsync()
        {

            List<ProductDTO>? productDTOs = new List<ProductDTO>();
            string responseBody = "";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(baseAddress + productsApiURL).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            if (responseBody is null) return null;
            productDTOs = JsonSerializer.Deserialize<List<ProductDTO>?>(responseBody);
            return productDTOs;
        }
        public async Task<List<IngredientDTO>?> GetIngredientsAsync()
        {
            List<IngredientDTO>? ingredientDTOs = new List<IngredientDTO>();
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
        public async Task<List<RecipeDTO>?> GetRecipesAsync()
        {
            var option = new JsonSerializerOptions() { IncludeFields = true, Converters = { new JsonArrayTupleConverter() } };
            List<RecipeDTO>? recipeDTOs = new List<RecipeDTO>();
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(baseAddress + recipesApiURL).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseBody);
                recipeDTOs = JsonSerializer.Deserialize<List<RecipeDTO>>(responseBody, option);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return recipeDTOs;
        }
        public async Task<List<RecipeDTO>?> GetMoreRecipesAsync(string filter, int[] paging)
        {
            var option = new JsonSerializerOptions()
            {
                IncludeFields = true
            };
            List<RecipeDTO>? recipeDTOs = new List<RecipeDTO>();
            try
            {
                string address = $"{baseAddress}{recipesApiURL}{filter}?&page={paging[0]}&pageCount={paging[1]}";
                HttpResponseMessage response = await _httpClient.GetAsync(address);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                recipeDTOs = JsonSerializer.Deserialize<List<RecipeDTO>>(responseBody, option);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return recipeDTOs;
        }
        public async Task SendReportAsync(Report? report)
        {
            try
            {
                var json = JsonSerializer.Serialize(report);

                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(baseAddress + reportsApiURL, stringContent).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public async Task<byte[]?> GetLeafletImageAsync(int id)
        {
            byte[] responseBody = null;
            try
            {


                HttpResponseMessage response = await _httpClient.GetAsync(baseAddress + leafletsApiURL + id).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                //ImageSource imageSource = "";
                //var stream = new MemoryStream();
                //using (stream)
                //{

                //    imageSource = ImageSource.FromStream(() => stream);
                //}
                //imageResult = new Image() { Source = imageSource };

            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            if (responseBody == null) return null;
            return responseBody;
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
