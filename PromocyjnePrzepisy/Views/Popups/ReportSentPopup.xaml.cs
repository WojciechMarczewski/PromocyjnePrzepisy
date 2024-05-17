using CommunityToolkit.Maui.Views;

namespace PromocyjnePrzepisy.Views.Popups;

public partial class ReportSentPopup : Popup
{
    public ReportSentPopup()
    {
        InitializeComponent();
        this.Dispatcher.StartTimer(TimeSpan.FromSeconds(1.2), () =>
        {
            CloseAsync();
            return false;
        });
    }
}