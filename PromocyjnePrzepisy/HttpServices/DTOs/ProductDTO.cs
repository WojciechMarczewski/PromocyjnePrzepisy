using PromocyjnePrzepisy.Models;
using System.Globalization;
using System.Text.Json.Serialization;
namespace PromocyjnePrzepisy.HttpServices.DTOs
{
    public class ProductDTO
    {
        public ProductDTO(string name, string ingredientName, string discountStartDate, string discountEndDate, string market, string pdfFilePath)
        {
            Name = name;
            IngredientName = ingredientName;
            DiscountStartDate = discountStartDate;
            DiscountEndDate = discountEndDate;
            Market = market;
            PdfFilePath = pdfFilePath;
        }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("ingredientName")]
        public string IngredientName { get; set; }
        [JsonPropertyName("discountStartDate")]
        public string DiscountStartDate { get; set; }
        [JsonPropertyName("discountEndDate")]
        public string DiscountEndDate { get; set; }
        [JsonPropertyName("market")]
        public string Market { get; set; }
        [JsonPropertyName("pdfFilePath")]
        public string PdfFilePath { get; set; }
        public Product ToProduct()
        {
            Discount discount = new Discount(DateOnly.Parse(DiscountStartDate, new CultureInfo("pl-PL")), DateOnly.Parse(DiscountEndDate, new CultureInfo("pl-PL")));
            Market market;
            bool parseResult = Enum.TryParse(Market, out market);
            if (parseResult is true)
            {
                return new Product(Name, IngredientName, discount, PdfFilePath, market);
            }
            else
            {
                return new Product(Name, IngredientName, discount, PdfFilePath, Models.Market.Nieznany);
            }
        }
    }
}
