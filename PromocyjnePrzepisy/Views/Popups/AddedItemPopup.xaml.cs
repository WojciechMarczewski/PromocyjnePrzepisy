using CommunityToolkit.Maui.Views;

namespace PromocyjnePrzepisy.Views.Popups;

public partial class AddedItemPopup : Popup
{
    public AddedItemPopup()
    {
        InitializeComponent();
        this.Dispatcher.StartTimer(TimeSpan.FromSeconds(2), () =>
        {
            CloseAsync();
            return false; // Zwr�� false, aby zatrzyma� timer
        });
    }


}