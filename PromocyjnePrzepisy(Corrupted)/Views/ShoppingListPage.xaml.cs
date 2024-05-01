namespace PromocyjnePrzepisy.Views;

public partial class ShoppingListPage : ContentPage
{
    public ShoppingListPage()
    {
        InitializeComponent();
        this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;
    }
}