using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;

namespace PromocyjnePrzepisy.Services
{
    public class RecipeProcessingService : IRecipeProcessingService
    {
        public int CalculateDiscounts(Recipe recipe)
        {
            if (recipe.Ingredients.Count == 0) throw new ArgumentException("Recipe has no ingredients");
            int count = 0;
            foreach (IngredientAmount ingAmnt in recipe.Ingredients)
            {
                if (ingAmnt.Ingredient.HasDiscounts) count++;
            }
            return count;
        }
        public string GetProductCountEnding(int count)
        {
            if (count == 1) return "składnik";
            if (count > 1 && count < 5) return "składniki";
            return "składników";
        }
    }
}
