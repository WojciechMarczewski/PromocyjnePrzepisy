using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisyTests.TestFactories;
namespace PromocyjnePrzepisyTests
{
    public class IngredientRepositoryTests
    {
        private IIngredientsRepository repository;

        public IngredientRepositoryTests()
        {
            var testFactory = new RepositoryTestFactory();
            repository = testFactory.IngredientRepoCreate().GetIngredientRepository();

        }
        [Fact]
        public void GetIngredients_Returns_Correct_List_For_Given_Ingredient_Names()
        {
            //Assert 
            List<string> ingredientsNames = CreateIngredientsNameList();
            //Act 
            var actual = repository.GetIngredients(ingredientsNames);
            //Assert
            Assert.True(actual.All(i => ingredientsNames.Contains(i.Name)));
        }
        private List<string> CreateIngredientsNameList()
        {
            List<string> fooData = new List<string> { "Cebula", "Czosnek", "Jajko" };
            return fooData;
        }
        [Fact]
        public void GetIngredients_Returns_Empty_List_For_Empty_Ingredient_Names_List()
        {
            //Assert 
            List<string> ingredientsNames = new List<string>();
            //Act
            var actual = repository.GetIngredients(ingredientsNames);
            //Assert
            Assert.Empty(actual);

        }
        [Fact]
        public void GetIngredients_Returns_Correct_List_For_NonExisting_Ingredient_Names()
        {
            //Assert 
            List<string> ingredientsNames = CreateIngredientsNameList();
            ingredientsNames.Add("test");
            //Act
            var actual = repository.GetIngredients(ingredientsNames);
            //Assert
            Assert.True(actual.All(i => ingredientsNames.Contains(i.Name)));
        }
    }
}
