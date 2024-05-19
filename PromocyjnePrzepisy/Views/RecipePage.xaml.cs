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
            this.ShowPopupAsync(new AddedItemPopup());
        });
        WeakReferenceMessenger.Default.Register<byte[], string>(this, "RecipePage", (sender, message) =>
        {
            this.ShowPopupAsync(new ProductLeafletImagePopup(message));

        });
    }
}