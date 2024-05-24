using PromocyjnePrzepisy.Models;
using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IViewModelService<T>
    {
        public ObservableCollection<T> PopulateList();
        public Task<ObservableCollection<T>> PopulateListAsync();
        public Task<ObservableCollection<T>> GetNewObjectsAsync(EatingStyle eatingStyle);
    }
}
