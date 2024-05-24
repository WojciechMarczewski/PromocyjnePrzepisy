using PromocyjnePrzepisy.DB;
using PromocyjnePrzepisy.Models;
using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisy.ViewModels;
using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Services
{
    public class ShoppingListViewModelService : IViewModelDBService<ProductViewModel>
    {
        private ShoppingListDatabase database;
        public ObservableCollection<ProductViewModel> PopulateList()
        {
            List<ProductEntity> entities = Task.Run(database.GetItemsAsync).Result;
            ObservableCollection<ProductViewModel> viewModels = new ObservableCollection<ProductViewModel>();
            foreach (ProductEntity entity in entities)
            {
                ProductViewModel productViewModel = new ProductViewModel(entity.ToProduct());
                viewModels.Add(productViewModel);
            }
            return viewModels;
        }
        public ShoppingListViewModelService(ShoppingListDatabase shoppingListDatabase)
        {
            database = shoppingListDatabase;
        }
        public void RemoveItem(ProductViewModel productViewModel)
        {
            ProductEntity productEntity = new ProductEntity(productViewModel.GetProduct());
            Task.Run(() => database.DeleteItemAsync(productEntity));
        }
        public void AddItem(ProductViewModel productViewModel)
        {
            ProductEntity productEntity = new ProductEntity(productViewModel.GetProduct());
            Task.Run(() => database.SaveItemAsync(productEntity));
        }
        public void RemoveAllItems()
        {
            Task.Run(() => database.DeleteAllItemsAsync());
        }

        public Task<ObservableCollection<ProductViewModel>> PopulateListAsync()
        {
            throw new NotImplementedException();
        }


        public Task<ObservableCollection<ProductViewModel>> GetNewObjectsAsync(EatingStyle eatingStyle)
        {
            throw new NotImplementedException();
        }
    }
}
