using CustomMasterDetailControl;
using System;
using TinyIoC;
using ViewFactory.ViewFactory;
using Xamarin.Forms;

namespace IoCSample
{
    public static class NavigationHelper
    {
        private static readonly INavigation _navigation;
        private static readonly IViewFactory _viewFactory;
        private static TinyIoCContainer _container;

        static NavigationHelper()
        {
            var container = TinyIoCContainer.Current;
            _container = container;
            _viewFactory = container.Resolve<IViewFactory>();
            _navigation = container.Resolve<INavigation>();
        }

        public static void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            PushPage<TViewModel>(_viewFactory.CreateView<TViewModel>());
        }

        private static void PushPage<TViewModel>(Page page) where TViewModel : BaseViewModel
        {
            if (!_viewFactory.IsDetailView<TViewModel>())
            {
                _navigation.PushAsync(page);
            }
            else
            {

            }
        }

        //public MasterDetailControlViewModel MasterViewModel
        //{
        //    get
        //    {

        //    }
        //    private set
        //}

        public static void NavigateTo<TViewModel>(Action<TViewModel> init) where TViewModel : BaseViewModel
        {
            var viewModel = _container.Resolve<TViewModel>();
            init(viewModel);
            PushPage<TViewModel>(_viewFactory.CreateView(viewModel));
        }
    }
}