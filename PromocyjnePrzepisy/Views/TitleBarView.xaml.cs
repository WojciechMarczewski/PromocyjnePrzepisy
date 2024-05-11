namespace PromocyjnePrzepisy.Views;
public partial class TitleBarView : ContentView
{
    public TitleBarView()
    {
        InitializeComponent();
    }
    private void FlyoutMenuButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        var width = DeviceDisplay.MainDisplayInfo.Width;
        Shell.Current.FlyoutWidth = width / 6;
    }
    private async void BackButton_Clicked(object sender, EventArgs e)
    {

        await Shell.Current.Navigation.PopAsync();
    }
}