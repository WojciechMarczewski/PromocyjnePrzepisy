using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Reflection;

namespace PromocyjnePrzepisy.Services.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private List<Recipe> _recipes = new List<Recipe>();
        private IIngredientsRepository _ingredientsRepository;
        public List<Recipe> GetRecipes()
        {
            return _recipes;
        }
        public RecipeRepository(IIngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
            CreateFooData();
        }
        private void CreateFooData()
        {
            string description = "\r\n    W dużej misce wymieszaj mięso mielone, posiekaną cebulę, czosnek, jajka i bułkę tartą. " +
                "Dopraw solą i pieprzem do smaku.\r\n    Uformuj z masy mięsnej kotlety o średnicy około 5 cm.\r\n   " +
                " Rozgrzej olej na patelni na średnim ogniu.\r\n  " +
                "  Smaż kotlety po obu stronach na złoty kolor, około 4-5 minut na każdą stronę.\r\n   " +
                " Podawaj gorące, np. z ziemniakami i surówką.\r\n";
            List<string> ingredientsStrings = new List<string>() { "Mięso Mielone Wieprzowe", "Cebula", "Czosnek", "Jajko", "Bułka Tarta", "Sól", "Pieprz", "Olej Rzepakowy" };
            var recipe1 = new Recipe("Tradycyjne Polskie Kotlety Mielone", description, _ingredientsRepository.GetIngredients(ingredientsStrings), GetFooImageBytes());
            _recipes.Add(recipe1);
        }

        //private byte[] GetFooImageBytes()
        //{
        //    string filePath = "E:\\c#\\Praktyki\\PromocyjnePrzepisy\\PromocyjnePrzepisy\\ImageFolder\\image_1.jpg";
        //    using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //    var buffer = new byte[stream.Length];
        //    stream.Read(buffer, 0, (int)stream.Length);
        //    return buffer;
        //}
        private byte[] GetFooImageBytes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "PromocyjnePrzepisy.ImageFolder.image_1.jpg";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new ArgumentException($"No resource with name {resourceName}");
            }

            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            return buffer;
        }
    }
}
