using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisy.Services.Repositories;

namespace PromocyjnePrzepisyTests.TestFactories
{
    public class RepositoryTestFactory
    {
        private IProductRepository? _productRepository;
        private IIngredientsRepository? _ingredientsRepository;
        private IRecipeRepository? _recipeRepository;



        public RepositoryTestFactory ProductRepoCreate()
        {
            _productRepository = new ProductRepository();
            return this;
        }
        public IProductRepository GetProductRepository()
        {
            if (_productRepository == null) throw new InvalidOperationException("ProductRepository has not been created. " +
                "Call ProductRepoCreate() first.");

            return _productRepository;
        }
        public RepositoryTestFactory IngredientRepoCreate()
        {
            ProductRepoCreate();
            if (_productRepository == null) throw new InvalidOperationException("ProductRepository has not been created. " +
                "Call ProductRepoCreate() first.");

            _ingredientsRepository = new IngredientRepository(_productRepository);
            return this;
        }
        public IIngredientsRepository GetIngredientRepository()
        {
            if (_ingredientsRepository == null) throw new InvalidOperationException("IngredientRepository has not been created. " +
                "Call IngredientRepoCreate() first.");
            return _ingredientsRepository;
        }
        public RepositoryTestFactory RecipeRepoCreate()
        {
            IngredientRepoCreate();
            if (_ingredientsRepository == null) throw new InvalidOperationException("IngredientRepository has not been created. " +
                "Call IngredientRepoCreate() first.");
            _recipeRepository = new RecipeRepository(_ingredientsRepository);
            return this;
        }
        public IRecipeRepository GetRecipeRepository()
        {
            if (_recipeRepository == null) throw new InvalidOperationException("RecipeRepository has not been created. " +
                "Call RecipeRepoCreate() first.");
            return _recipeRepository;
        }
    }
}
