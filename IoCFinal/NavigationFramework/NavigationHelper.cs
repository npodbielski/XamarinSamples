using System;
using NavigationFramework.Services.Navigation;
using NavigationFramework.ViewModels;
using TinyIoC;

namespace NavigationFramework
{
    public static class NavigationHelper
    {
        private static readonly INavigationService NavigationService;

        static NavigationHelper()
        {
            NavigationService = TinyIoCContainer.Current.Resolve<INavigationService>();
        }

        public static void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            NavigationService.NavigateTo<TViewModel>();
        }

        public static void NavigateTo<TViewModel>(Action<TViewModel> init) where TViewModel : BaseViewModel
        {
            NavigationService.NavigateTo(init);
        }
    }
}