using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Messaging;
using PromocyjnePrzepisy.ViewModels;
using PromocyjnePrzepisy.Views.Popups;

namespace PromocyjnePrzepisy.Views;

public partial class SearchPage : ContentPage
{
    private bool hasAppearedBefore = false;
    public SearchPage(SearchPageViewModel searchPageViewModel)
    {
        InitializeComponent();
        this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;
        this.BindingContext = searchPageViewModel;
        RegisterMessageRecipient();
    }
    private void RegisterMessageRecipient()
    {
        WeakReferenceMessenger.Default.Register<string>(this, (sender, message) =>
        {
            this.ShowPopup(new AddedItemPopup());
        });
        WeakReferenceMessenger.Default.Register<Image, string>(this, "SearchPage", (sender, message) =>
        {
            this.ShowPopup(new ProductLeafletImagePopup(message));
        });
    }





}