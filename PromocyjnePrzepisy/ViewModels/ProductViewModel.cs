using PromocyjnePrzepisy.Models;

namespace PromocyjnePrzepisy.ViewModels
{
    public class ProductViewModel(Product product) : BaseViewModel
    {
        private readonly Product _product = product;
        public string Name { get { return _product.Name; } }
        public string DiscountStartDate { get { return _product.Discount.StartDate.ToString(); } }
        public string DiscountEndDate { get { return _product.Discount.EndDate.ToString(); } }
        public string Market { get { return _product.Market.ToString(); } }

    }
}