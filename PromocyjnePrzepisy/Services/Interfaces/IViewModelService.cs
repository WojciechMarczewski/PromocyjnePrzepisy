using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IViewModelService<BaseViewModel>
    {
        public ObservableCollection<BaseViewModel> PopulateList();
    }
}
