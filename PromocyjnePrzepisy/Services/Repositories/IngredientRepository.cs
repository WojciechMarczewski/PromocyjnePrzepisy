using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;

namespace PromocyjnePrzepisy.Services.Repositories
{
    public class IngredientRepository : IIngredientsRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private IProductRepository _productRepository;

        public List<Ingredient> GetIngredients(List<string> ingredientsList)
        {
            List<Ingredient> result = new List<Ingredient>();

            foreach (string ingredientName in ingredientsList)
            {
                Ingredient? ingredient = _ingredients.FirstOrDefault(i => i.Name.ToLower().Equals(ingredientName.ToLower()));
                if (ingredient != null)
                {
                    result.Add(ingredient);
                }
            }

            return result;
        }

        public IngredientRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            CreateFooData();
        }
        private void CreateFooData()
        {
            string[] ingredients = ["Mięso mielone wieprzowe", "Cebula", "Czosnek", "Jajko", "Bułka Tarta", "Sól", "Pieprz", "Olej Rzepakowy"];
            foreach (string ingredientString in ingredients)
            {
                _ingredients.Add(new Ingredient(ingredientString, _productRepository.GetProducts(ingredientString)));
            }

        }
    }
}
