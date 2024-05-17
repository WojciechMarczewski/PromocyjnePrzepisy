using PromocyjnePrzepisy.ViewModels;
namespace PromocyjnePrzepisy.Views
{
    public partial class MainPage : ContentPage
    {
        private bool hasAppearedBefore = false;

        public MainPage(MainViewModel mainViewModel, ShoppingListPageViewModel shoppingListPageViewModel)
        {
            //(Lazy Loading issue fix) ShoppingListPageViewModel injection for initialization of messagecenter
            InitializeComponent();
            this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;
            this.BindingContext = mainViewModel;

        }
        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var tappedElement = sender as View;
            var clickedItem = tappedElement?.BindingContext as RecipeViewModel;
            if (clickedItem != null)
            {
                var page = this.Handler?.MauiContext?.Services.GetService<RecipePage>();
                if (page != null)
                {
                    page.BindingContext = new RecipePageViewModel(clickedItem);
                    await Shell.Current.Navigation.PushAsync(page);
                }
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (!hasAppearedBefore)
            {
                LoadingIndicator.IsVisible = true;
                var viewModel = BindingContext as MainViewModel;
                if (viewModel != null)
                {
                    await viewModel.FillRecipes();
                    RecipeCollection.ItemsSource = viewModel.RecipeCollection;
                }
                LoadingIndicator.IsVisible = false;
                RecipeCollection.IsVisible = true;
                hasAppearedBefore = true;
            }
            if (hasAppearedBefore)
            {
                var viewModel = BindingContext as MainViewModel;
                if (viewModel != null)
                {
                    viewModel.RefreshImagesOnAppearing();
                }
            }


        }
    }
}
