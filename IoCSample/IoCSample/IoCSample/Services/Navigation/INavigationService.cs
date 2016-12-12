using System;
using System.Collections.Generic;
using CustomMasterDetailControl;
using Xamarin.Forms;

namespace IoCSample.Services.Navigation
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