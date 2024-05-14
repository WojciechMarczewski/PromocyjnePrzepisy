using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IViewModelService<T>
    {
        public ObservableCollection<T> PopulateList();
        public Task<ObservableCollection<T>> PopulateListAsync();
    }
}
