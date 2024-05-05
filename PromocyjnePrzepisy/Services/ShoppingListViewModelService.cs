using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisy.ViewModels;
using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Services
{
    class ShoppingListViewModelService : IViewModelService<ProductViewModel>
    {
        public ObservableCollection<ProductViewModel> PopulateList()
        {
            throw new NotImplementedException();
        }
    }
}
