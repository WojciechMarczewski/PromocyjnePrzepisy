namespace PromocyjnePrzepisy.Views;

public partial class ShoppingListPage : ContentPage
{
    public ShoppingListPage()
    {
        InitializeComponent();
        this.TitleView.FindByName<ImageButton>("BackButton").IsVisible = false;
    }
}