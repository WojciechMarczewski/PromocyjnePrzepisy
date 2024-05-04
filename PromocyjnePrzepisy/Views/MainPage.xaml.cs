using PromocyjnePrzepisy.ViewModels;

namespace PromocyjnePrzepisy.Views
{
    public partial class MainPage : ContentPage
    {


        public MainPage(MainViewModel mainViewModel)
        {
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
    }

}
