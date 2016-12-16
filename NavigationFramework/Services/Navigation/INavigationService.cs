using System;
using NavigationFramework.MasterDetail;
using NavigationFramework.ViewModels;
using Xamarin.Forms;

namespace NavigationFramework.Services.Navigation
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
        void NavigateTo<TViewModel>(Action<TViewModel> init) where TViewModel : BaseViewModel;
        void PushPage<TViewModel>(Page page) where TViewModel : BaseViewModel;
    }

    public interface INavigationService<out TMasterViewModel> : INavigationService
        where TMasterViewModel : MasterDetailControlViewModel
    {
        TMasterViewModel MasterViewModel { get; }
    }
}