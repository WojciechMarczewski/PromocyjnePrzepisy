using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisyTests.TestFactories;

namespace PromocyjnePrzepisyTests
{
    public class RecipeRepositoryTests
    {
        private IRecipeRepository _recipeRepository;
        public RecipeRepositoryTests()
        {
            _recipeRepository = new RepositoryTestFactory().RecipeRepoCreate().GetRecipeRepository();
        }
        [Fact]
        public void GetFooImageBytes_Return_NonEmpty_BytesArray()
        {
            //Assert
            //Act 
            var actual = _recipeRepository.GetRecipes();
            //Assert
            Assert.NotEmpty(actual[0].Image);
        }
    }
}
