namespace PromocyjnePrzepisy.Services.Interfaces
{
    public interface IViewModelDBService<T> : IViewModelService<T>
    {
        public void AddItem(T obj);
        public void RemoveItem(T obj);
        public void RemoveAllItems();
    }
}
