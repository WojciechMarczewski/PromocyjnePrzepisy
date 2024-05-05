using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.ViewModels
{
    public partial class ProductViewModel(Product product) : BaseViewModel
    {
        private readonly Product _product = product;
        public string Name { get { return _product.Name; } }
        public string DiscountStartDate { get { return _product.Discount.StartDate.ToString(); } }
        public string DiscountEndDate { get { return _product.Discount.EndDate.ToString(); } }
        public string Market { get { return _product.Market.ToString(); } }
        public string IngredientTypeName { get { return _product.IngredientName; } }
        [RelayCommand]
        public void AddProductToShoppingList(ProductViewModel productViewModel)
        {
            WeakReferenceMessenger.Default.Send<ProductViewModel>(productViewModel);
            string messageToUser = "Pomyslnie dodano produkt listy zakupów";
            WeakReferenceMessenger.Default.Send<string>(messageToUser);
        }
    }
}