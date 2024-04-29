namespace PromocyjnePrzepisy.Views;

public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();
        this.TitleView.FindByName<ImageButton>("BackButton").IsVisible = false;
    }
}