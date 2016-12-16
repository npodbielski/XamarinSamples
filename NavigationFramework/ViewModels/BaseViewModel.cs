using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NavigationFramework.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            NavigationHelper.NavigateTo<TViewModel>();
        }

        public static void NavigateTo<TViewModel>(Action<TViewModel> init) where TViewModel : BaseViewModel
        {
            NavigationHelper.NavigateTo(init);
        }
    }
}
