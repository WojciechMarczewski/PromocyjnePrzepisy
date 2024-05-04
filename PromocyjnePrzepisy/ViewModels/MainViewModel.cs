using PromocyjnePrzepisy.Services.Interfaces;
using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<RecipeViewModel> RecipeCollection { get; set; }

        public MainViewModel(IViewModelService<RecipeViewModel> viewModelService)
        {
            RecipeCollection = viewModelService.PopulateList();
        }
    }
}
