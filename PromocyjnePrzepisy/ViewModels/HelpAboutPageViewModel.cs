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
        }
        private string _reportContent = "";
        public string ReportContent
        {
            get { return _reportContent; }
            set
            {
                _reportContent = value;
                OnPropertyChanged(nameof(ReportContent));
                this.SendReportCommand.NotifyCanExecuteChanged();
            }
        }
        public ReportType ReportType { get; set; } = ReportType.Bug;
        public bool IsSendEnabled
        {
            get { return ReportContent.Length >= 10; }
        }
        [RelayCommand(CanExecute = nameof(IsSendEnabled))]
        public async Task SendReport()
        {
            await supportService.SendReportAsync(ReportType, ReportContent);
        }
    }
}
