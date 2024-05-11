using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using PromocyjnePrzepisy.ViewModels;
using PromocyjnePrzepisy.Views.Popups;

namespace PromocyjnePrzepisy.Views;

public partial class ShoppingListPage : ContentPage
{
    public ShoppingListPage(ShoppingListPageViewModel shoppingListPageViewModel)
    {
        InitializeComponent();
        this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;
        this.BindingContext = shoppingListPageViewModel;
        RegisterMessageRecipient();
    }
    public void RegisterMessageRecipient()
    {
        WeakReferenceMessenger.Default.Register<Image>(this, (sender, message) =>
        {
            this.ShowPopup(new ProductLeafletImagePopup(message));
        });
    }
}