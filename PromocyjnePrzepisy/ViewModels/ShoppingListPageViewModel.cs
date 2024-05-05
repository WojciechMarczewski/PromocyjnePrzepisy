using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.ViewModels
{
    public partial class ShoppingListPageViewModel : BaseViewModel
    {
        public ObservableCollection<ProductViewModel> ShoppingList { get; set; } = new ObservableCollection<ProductViewModel>();
        public ShoppingListPageViewModel()
        {
            //try
            //{
            //    ShoppingList = viewModelService.PopulateList().ToObservableCollection<ProductViewModel>();
            //}
            //catch (Exception ex) { }
            RegisterMessengerRecipient();


        }
        [RelayCommand]
        public void ClearShoppingList()
        {
            ShoppingList.Clear();
        }
        private void RegisterMessengerRecipient()
        {
            WeakReferenceMessenger.Default.Register<ProductViewModel>(this, (r, msg) =>
            {
                ShoppingList.Add(msg);
            });
        }
    }
}
