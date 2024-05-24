using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PromocyjnePrzepisy.DB;
using PromocyjnePrzepisy.Helpers;
using PromocyjnePrzepisy.HttpServices;
using PromocyjnePrzepisy.Services;
using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisy.Services.Repositories;
using PromocyjnePrzepisy.ViewModels;
using PromocyjnePrzepisy.Views;
namespace PromocyjnePrzepisy
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .AddServices()
                .AddViewModels()
                .AddViews();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();
            ServiceHelper.Initialize(app.Services);
            return app;
        }
        public static MauiAppBuilder AddServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<HttpService>()
                .AddSingleton<ShoppingListDatabase>()
                .AddSingleton<IProductRepositoryService, ProductRepositoryService>()
                .AddSingleton<IProductRepository, ProductRepository>()
                .AddSingleton<IIngredientRepositoryService, IngredientRepositoryService>()
                .AddSingleton<IIngredientsRepository, IngredientRepository>()
                .AddSingleton<IRecipeRepositoryService, RecipeRepositoryService>()
                .AddSingleton<IRecipeRepository, RecipeRepository>()
                .AddSingleton<IViewModelService<ProductViewModel>, SearchPageViewModelService>()
                .AddSingleton<ISupportService, AppSupportService>()
                .AddSingleton<IViewModelDBService<ProductViewModel>, ShoppingListViewModelService>()
                    .AddSingleton<IRecipeProcessingService, RecipeProcessingService>()
                 .AddSingleton<IViewModelService<RecipeViewModel>, MainViewModelService>();
            return builder;
        }
        public static MauiAppBuilder AddViews(this MauiAppBuilder builder)
        {
            builder.Services
                .AddTransient<RecipePage>()
                .AddSingleton<HelpAboutPage>()
                .AddSingleton<ShoppingListPage>()
                .AddSingleton<SearchPage>()
                .AddSingleton<MainPage>();
            return builder;
        }
        public static MauiAppBuilder AddViewModels(this MauiAppBuilder builder)
        {
            builder.Services
                .AddSingleton<MainViewModel>()
                .AddSingleton<ShoppingListPageViewModel>()
                .AddSingleton<SearchPageViewModel>()
                .AddSingleton<HelpAboutPageViewModel>();
            return builder;
        }
    }
}
