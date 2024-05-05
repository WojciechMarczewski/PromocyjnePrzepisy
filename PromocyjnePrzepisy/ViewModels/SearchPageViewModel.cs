using CommunityToolkit.Mvvm.Input;
using PromocyjnePrzepisy.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
namespace PromocyjnePrzepisy.ViewModels
{
    public partial class SearchPageViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ProductViewModel> _allProducts;
        public ObservableCollection<ProductViewModel> ProductsCollection { get; set; }
        public SearchPageViewModel(IViewModelService<ProductViewModel> viewModelService)
        {
            _allProducts = viewModelService.PopulateList();
            ProductsCollection = new ObservableCollection<ProductViewModel>(_allProducts);
        }

        [RelayCommand]
        public void PerformSearch(string query)
        {
            ProductsCollection.Clear();
            if (string.IsNullOrEmpty(query))
            {
                ProductsCollection = new ObservableCollection<ProductViewModel>(_allProducts);
            }
            else
            {
                query = RemoveDiacritics(query).ToLower();
                foreach (ProductViewModel product in _allProducts)
                {
                    string name = RemoveDiacritics(product.Name).ToLower();
                    string ingredientTypeName = RemoveDiacritics(product.IngredientTypeName).ToLower();

                    if (name.Contains(query) || ingredientTypeName.Contains(query))
                    {
                        ProductsCollection.Add(product);
                    }

                }
            }
        }
        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
