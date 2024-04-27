namespace PromocyjnePrzepisy
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            this.TitleView.FindByName<ImageButton>("BackButton").IsVisible = false;
        }


    }

}
