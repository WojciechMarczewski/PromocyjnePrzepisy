using PromocyjnePrzepisy.ViewModels;
namespace PromocyjnePrzepisy.Views;
public partial class HelpAboutPage : ContentPage
{
    public HelpAboutPage(HelpAboutPageViewModel viewModel)
    {
        InitializeComponent();
        this.TitleBarView.FindByName<ImageButton>("BackButton").IsVisible = false;
        this.BindingContext = viewModel;
    }
}