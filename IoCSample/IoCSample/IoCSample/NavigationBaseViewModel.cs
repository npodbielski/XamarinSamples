using System;
using CustomMasterDetailControl;

namespace IoCSample
{
    public class NavigationBaseViewModel : BaseViewModel
    {
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