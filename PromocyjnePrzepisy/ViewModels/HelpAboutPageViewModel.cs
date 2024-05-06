using CommunityToolkit.Mvvm.Input;
using PromocyjnePrzepisy.Services.Interfaces;

namespace PromocyjnePrzepisy.ViewModels
{
    public partial class HelpAboutPageViewModel : BaseViewModel
    {
        private ISupportService supportService;
        public HelpAboutPageViewModel(ISupportService supportServiceObject)
        {
            supportService = supportServiceObject;
            TicketContent = "";
        }
        private string _ticketContent;
        public string TicketContent
        {
            get { return _ticketContent; }
            set
            {
                _ticketContent = value;
                OnPropertyChanged(nameof(TicketContent));
                this.SendTicketCommand.NotifyCanExecuteChanged();
            }
        }
        public TicketType TicketType { get; set; } = TicketType.Bug;
        public bool IsSendEnabled
        {
            get { return TicketContent.Length >= 10; }
        }

        [RelayCommand(CanExecute = nameof(IsSendEnabled))]
        public void SendTicket()
        {
            supportService.SendTicket(TicketType, TicketContent);
        }

    }

}
