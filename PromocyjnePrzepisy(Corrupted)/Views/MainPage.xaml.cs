namespace PromocyjnePrzepisy.Views
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;

        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var page = new RecipePage();
            await Shell.Current.Navigation.PushAsync(page);
        }
    }

}
