using PromocyjnePrzepisy.Views;

namespace PromocyjnePrzepisy
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            this.TitleView.FindByName<ImageButton>("BackButton").IsVisible = false;
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var page = new RecipePage();
            await Shell.Current.Navigation.PushAsync(page);
        }
    }

}
