using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using PromocyjnePrzepisy.Views.Popups;

namespace PromocyjnePrzepisy.Views;

public partial class RecipePage : ContentPage
{
    public RecipePage()
    {
        InitializeComponent();
        RegisterMessageRecipient();

    }
    private void RegisterMessageRecipient()
    {
        WeakReferenceMessenger.Default.Register<string>(this, (sender, message) =>
        {
            this.ShowPopup(new AddedItemPopup());
        });
    }
}