using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.Helpers
{
    public static class PagingHelper
    {
        private static int PageGeneral { get; set; } = 1;
        private static int PageMeatVal { get; set; } = 1;
        private static int PageVeganVal { get; set; } = 1;
        private static int PageVegetarianVal { get; set; } = 1;
        private static int PageGeneralRecipesCounter { get; set; } = 0;
        private static int PageMeatRecipesCounter { get; set; } = 0;
        private static int PageVeganRecipesCounter { get; set; } = 0;
        private static int PageVegetarianRecipesCounter { get; set; } = 0;
        public static int[] GetNextGeneralPageValue()
        {
            PageGeneral++;
            PageGeneralRecipesCounter += 20;
            return [PageGeneral, PageGeneralRecipesCounter];
        }
        public static int[] GetNextMeatPageValue()
        {
            PageMeatVal++;
            PageMeatRecipesCounter += 20;
            return [PageMeatVal, PageMeatRecipesCounter];
        }
        public static int[] GetNextVeganPageValue()
        {
            PageVeganVal++;
            PageVeganRecipesCounter += 20;
            return [PageVeganVal, PageVeganRecipesCounter];
        }
        public static int[] GetNextVegetarianPageValue()
        {
            PageVegetarianVal++;
            return [PageVegetarianVal, PageVegetarianRecipesCounter + 20];
        }
        public static void SetPagingCountersOnStart(List<Recipe> recipesList)
        {
            PageGeneralRecipesCounter = recipesList.Count;
            PageMeatRecipesCounter = recipesList.Where(x => x.EatingStyleTags.Contains(EatingStyle.MeatEater)).Count();
            PageVeganRecipesCounter = recipesList.Where(x => x.EatingStyleTags.Contains(EatingStyle.Vegan)).Count();
            PageVegetarianRecipesCounter = recipesList.Where(x => x.EatingStyleTags.Contains(EatingStyle.Vegetarian)).Count();
        }
        public static void ResetPages()
        {
            PageGeneral = 1;
            PageMeatVal = 1;
            PageVegetarianVal = 1;
            PageVeganVal = 1;
        }
    }
}
