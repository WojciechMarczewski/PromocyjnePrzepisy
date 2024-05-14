using PromocyjnePrzepisy.HttpServices;
using PromocyjnePrzepisy.HttpServices.DTOs;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Diagnostics;

namespace PromocyjnePrzepisy.Services
{
    public class ProductRepositoryService : IProductRepositoryService
    {
        private readonly HttpService _httpService;
        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            List<ProductDTO>? list = null;
            try
            {
                list = await _httpService.GetProductsAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            var products = new List<Product>();
            if (list != null)
            {
                foreach (var productDTO in list)
                {
                    products.Add(productDTO.ToProduct());
                }
            }
            return products;
        }
        public ProductRepositoryService(HttpService httpService)
        {
            _httpService = httpService;
        }

    }
}
