namespace PromocyjnePrzepisy.Views;

public partial class HelpAboutPage : ContentPage
{
    public HelpAboutPage()
    {
        InitializeComponent();
        this.TitleView.FindByName<ImageButton>("BackButton").IsVisible = false;
    }
}