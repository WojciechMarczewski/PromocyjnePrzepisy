using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisyTests.TestFactories;
namespace PromocyjnePrzepisyTests
{
    public class ProductRespositoryTests
    {
        private IProductRepository repository;
        public ProductRespositoryTests()
        {
            repository = new RepositoryTestFactory().ProductRepoCreate().GetProductRepository();
        }
        [Fact]
        public void GetProducts_Returns_Correct_Products_For_Given_IngredientName()
        {
            //Arrange
            string ingredientName = "Miêso mielone wieprzowe";
            //Act 
            var actual = repository.GetProducts(ingredientName);
            //Assert 
            Assert.NotNull(actual);
        }
        [Fact]
        public void GetProducts_Returns_Empty_List_For_NonExisting_IngredientName()
        {
            //Arrange
            string ingredientName = "test";
            //Act
            var actual = repository.GetProducts(ingredientName);
            //Assert
            Assert.Empty(actual);
        }
    }
}