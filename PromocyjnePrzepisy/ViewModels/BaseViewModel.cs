using System.ComponentModel;

namespace PromocyjnePrzepisy.ViewModels
{
    public abstract class BaseViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
