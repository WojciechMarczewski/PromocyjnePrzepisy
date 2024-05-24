using PromocyjnePrzepisy.Models;
using System.Text.Json.Serialization;
namespace PromocyjnePrzepisy.HttpServices.DTOs
{
    public class RecipeDTO
    {
        public RecipeDTO(string name, string description, List<IngredientAmountDTO> ingredients, string base64Image, EatingStyle[] eatingStyleTags)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            this.base64Image = base64Image;
            EatingStyleTags = eatingStyleTags;
        }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("ingredients")]
        public List<IngredientAmountDTO> Ingredients { get; set; }
        public string base64Image { get; set; }
        [JsonPropertyName("eatingStyleTags")]
        public EatingStyle[] EatingStyleTags { get; set; }
    }
}
