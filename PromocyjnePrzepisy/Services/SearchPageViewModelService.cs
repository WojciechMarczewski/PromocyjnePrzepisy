using PromocyjnePrzepisy.Services.Interfaces;
using PromocyjnePrzepisy.ViewModels;
using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Services
{
    public class SearchPageViewModelService : IViewModelService<ProductViewModel>
    {
        private readonly IProductRepository _productRepository;
        public ObservableCollection<ProductViewModel> PopulateList()
        {
            ObservableCollection<ProductViewModel> productViewModels = new ObservableCollection<ProductViewModel>();
            _productRepository.GetAllProducts().ForEach(product =>
            {
                productViewModels.Add(new ProductViewModel(product));
            });
            return productViewModels;
        }
        public SearchPageViewModelService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

    }
}
