using System.Collections.ObjectModel;

namespace PromocyjnePrzepisy.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void ReplaceWith<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            collection.Clear();
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

    }
}
