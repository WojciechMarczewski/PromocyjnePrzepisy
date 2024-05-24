using System.Text.Json.Serialization;

namespace PromocyjnePrzepisy.HttpServices.DTOs
{
    public class IngredientAmountDTO
    {
        public IngredientAmountDTO(string ingredient, string amount)
        {
            Ingredient = ingredient;
            Amount = amount;
        }
        [JsonPropertyName("ingredient")]
        public string? Ingredient { get; set; }
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }
    }
}
