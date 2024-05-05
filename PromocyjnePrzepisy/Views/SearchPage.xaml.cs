using PromocyjnePrzepisy.ViewModels;

namespace PromocyjnePrzepisy.Views;

public partial class SearchPage : ContentPage
{
    public SearchPage(SearchPageViewModel searchPageViewModel)
    {
        InitializeComponent();
        this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;
        this.BindingContext = searchPageViewModel;
    }
}