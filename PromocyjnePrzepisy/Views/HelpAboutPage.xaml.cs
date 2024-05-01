namespace PromocyjnePrzepisy.Views;

public partial class HelpAboutPage : ContentPage
{
    public HelpAboutPage()
    {
        InitializeComponent();
        this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;
    }
}