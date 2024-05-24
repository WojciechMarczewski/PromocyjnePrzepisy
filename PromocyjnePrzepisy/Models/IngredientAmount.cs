namespace PromocyjnePrzepisy.Models
{
    public class IngredientAmount
    {
        public IngredientAmount(Ingredient ingredient, string amount)
        {
            Ingredient = ingredient;
            Amount = amount;
        }

        public Ingredient Ingredient { get; set; }
        public string Amount { get; set; }
    }
}
