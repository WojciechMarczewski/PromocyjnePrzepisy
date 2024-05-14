using System.Text.Json.Serialization;
namespace PromocyjnePrzepisy.HttpServices.DTOs
{
    public class IngredientDTO
    {
        public IngredientDTO(string name)
        {
            Name = name;
        }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
