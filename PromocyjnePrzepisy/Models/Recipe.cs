namespace PromocyjnePrzepisy.Models
{
    public class Recipe(string name, string description, List<Ingredient> ingredients, byte[] image) : EntityBase
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public List<Ingredient> Ingredients { get; set; } = ingredients;
        public byte[] Image { get; set; } = image;


    }
}
