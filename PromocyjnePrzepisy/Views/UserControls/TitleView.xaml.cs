namespace PromocyjnePrzepisy.Views.UserControls;

public partial class TitleView : ContentView
{
    public TitleView()
    {
        InitializeComponent();
    }

    private void FlyoutMenuButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = !Shell.Current.FlyoutIsPresented;
        var width = DeviceDisplay.MainDisplayInfo.Width;
        Shell.Current.FlyoutWidth = width / 6;
    }
}