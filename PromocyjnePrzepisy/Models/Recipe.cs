namespace PromocyjnePrzepisy.Models
{
    public class Recipe(string name, string description, List<IngredientAmount> ingredients, byte[] image, EatingStyle[]? eatingStyleTags = null)
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public List<IngredientAmount> Ingredients { get; set; } = ingredients;
        public byte[] Image { get; set; } = image;
        public EatingStyle[] EatingStyleTags { get; set; } = eatingStyleTags ?? new EatingStyle[] { EatingStyle.None };
    }
}
