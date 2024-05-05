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
            var recipe1 = new Recipe("Tradycyjne Polskie Kotlety Mielone", description, _ingredientsRepository.GetIngredients(ingredientsStrings), GetFooImageBytes(), new EatingStyle[] { EatingStyle.MeatEater });
            _recipes.Add(recipe1);
            string description2 = "\r\n    W dużej misce wymieszaj makaron spaghetti, sos pomidorowy, czosnek i cebulę. " +
    "Dopraw solą i pieprzem do smaku.\r\n    Gotuj makaron zgodnie z instrukcjami na opakowaniu.\r\n   " +
    " Podgrzewaj sos na średnim ogniu.\r\n  " +
    "  Podawaj gorące, np. z parmezanem.\r\n";
            List<string> ingredientsStrings2 = new List<string>() { "Makaron Spaghetti", "Sos Pomidorowy", "Czosnek", "Cebula", "Sól", "Pieprz", "Parmezan" };
            var recipe2 = new Recipe("Spaghetti Bolognese", description2, _ingredientsRepository.GetIngredients(ingredientsStrings2), GetFooImageBytes());
            _recipes.Add(recipe2);

            string description3 = "\r\n    W dużej misce wymieszaj mąkę, jajka, mleko i cukier. " +
                "Dopraw solą.\r\n    Uformuj z masy ciasto naleśnikowe.\r\n   " +
                " Rozgrzej olej na patelni na średnim ogniu.\r\n  " +
                "  Smaż naleśniki po obu stronach na złoty kolor, około 2-3 minuty na każdą stronę.\r\n   " +
                " Podawaj gorące, np. z dżemem lub bitą śmietaną.\r\n";
            List<string> ingredientsStrings3 = new List<string>() { "Mąka", "Jajka", "Mleko", "Cukier", "Sól", "Olej Rzepakowy" };
            var recipe3 = new Recipe("Naleśniki", description3, _ingredientsRepository.GetIngredients(ingredientsStrings3), GetFooImageBytes());
            _recipes.Add(recipe3);

            string description4 = "\r\n    W dużej misce wymieszaj mąkę, drożdże, wodę i sól. " +
                "Dopraw solą.\r\n    Uformuj z masy ciasto na pizzę.\r\n   " +
                " Rozgrzej piekarnik do 200 stopni C.\r\n  " +
                "  Piecz pizzę przez około 15-20 minut.\r\n   " +
                " Podawaj gorące, np. z ulubionymi dodatkami.\r\n";
            List<string> ingredientsStrings4 = new List<string>() { "Mąka", "Drożdże", "Woda", "Sól" };
            var recipe4 = new Recipe("Pizza", description4, _ingredientsRepository.GetIngredients(ingredientsStrings4), GetFooImageBytes());
            _recipes.Add(recipe4);

            string description5 = "\r\n    W dużej misce wymieszaj mąkę, jajka, mleko, cukier i kakao. " +
                "Dopraw solą.\r\n    Uformuj z masy ciasto na brownie.\r\n   " +
                " Rozgrzej piekarnik do 180 stopni C.\r\n  " +
                "  Piecz brownie przez około 25-30 minut.\r\n   " +
                " Podawaj gorące, np. z lodami waniliowymi.\r\n";
            List<string> ingredientsStrings5 = new List<string>() { "Mąka", "Jajka", "Mleko", "Cukier", "Kakao", "Sól" };
            var recipe5 = new Recipe("Brownie", description5, _ingredientsRepository.GetIngredients(ingredientsStrings5), GetFooImageBytes());
            _recipes.Add(recipe5);
            string description6 = "W dużej misce wymieszaj posiekane warzywa, jajka i bułkę tartą. Dopraw solą i pieprzem do smaku. Uformuj z masy warzywne kotlety o średnicy około 5 cm. Rozgrzej olej na patelni na średnim ogniu. Smaż kotlety po obu stronach na złoty kolor, około 4-5 minut na każdą stronę. Podawaj gorące, np. z ziemniakami i surówką.";
            List<string> ingredientsStrings6 = new List<string>() { "Warzywa", "Jajko", "Bułka Tarta", "Sól", "Pieprz", "Olej Rzepakowy" };
            var recipe6 = new Recipe("Wegetariańskie Kotlety Warzywne", description6, _ingredientsRepository.GetIngredients(ingredientsStrings6), GetFooImageBytes(), new EatingStyle[] { EatingStyle.Vegetarian });
            _recipes.Add(recipe6);
            string description7 = "W dużej misce wymieszaj posiekane warzywa, mąkę i wodę. Dopraw solą i pieprzem do smaku. Uformuj z masy warzywne kotlety o średnicy około 5 cm. Rozgrzej olej na patelni na średnim ogniu. Smaż kotlety po obu stronach na złoty kolor, około 4-5 minut na każdą stronę. Podawaj gorące, np. z ziemniakami i surówką.";
            List<string> ingredientsStrings7 = new List<string>() { "Warzywa", "Mąka", "Woda", "Sól", "Pieprz", "Olej Rzepakowy" };
            var recipe7 = new Recipe("Wegańskie Kotlety Warzywne", description7, _ingredientsRepository.GetIngredients(ingredientsStrings7), GetFooImageBytes(), new EatingStyle[] { EatingStyle.Vegan });
            _recipes.Add(recipe7);
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
