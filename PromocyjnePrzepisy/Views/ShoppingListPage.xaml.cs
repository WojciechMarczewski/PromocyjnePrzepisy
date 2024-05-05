using PromocyjnePrzepisy.ViewModels;

namespace PromocyjnePrzepisy.Views;

public partial class ShoppingListPage : ContentPage
{
    public ShoppingListPage(ShoppingListPageViewModel shoppingListPageViewModel)
    {
        InitializeComponent();
        this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;
        this.BindingContext = shoppingListPageViewModel;
    }
}