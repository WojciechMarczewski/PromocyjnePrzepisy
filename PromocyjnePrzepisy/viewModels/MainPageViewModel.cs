using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<CollectionViewItem> collectionViewItems = new ObservableCollection<CollectionViewItem>();
        public MainPageViewModel()
        {

        }

    }
}
