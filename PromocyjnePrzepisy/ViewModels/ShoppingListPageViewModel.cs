using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Collections.ObjectModel;
namespace PromocyjnePrzepisy.ViewModels
{
    public partial class ShoppingListPageViewModel : BaseViewModel
    {
        public ObservableCollection<ProductViewModel> ShoppingList { get; set; } = new ObservableCollection<ProductViewModel>();
        private IViewModelDBService<ProductViewModel> _viewModelService;
        public ShoppingListPageViewModel(IViewModelDBService<ProductViewModel> viewModelService)
        {
            RegisterMessengerRecipient();
            _viewModelService = viewModelService;
            ShoppingList = _viewModelService.PopulateList();
        }
        [RelayCommand]
        public void ClearShoppingList()
        {
            ShoppingList.Clear();
            _viewModelService.RemoveAllItems();
        }
        public void RegisterMessengerRecipient()
        {
            WeakReferenceMessenger.Default.Register<ProductViewModel>(this, (r, msg) =>
            {
                ShoppingList.Add(msg);
                _viewModelService.AddItem(msg);
            });
            WeakReferenceMessenger.Default.Register<ProductViewModel, string>(this, "Remove", (r, msg) =>
            {
                _viewModelService.RemoveItem(msg);
                ShoppingList.Remove(msg);
            });
        }
    }
}
