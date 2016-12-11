using CustomMasterDetailControl;
using System;
using System.Collections.Generic;
using System.Linq;
using TinyIoC;
using ViewFactory.ViewFactory;
using Xamarin.Forms;

namespace IoCSample
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

    public class NavigationService<TMasterViewModel> : INavigationService<TMasterViewModel>
        where TMasterViewModel : MasterDetailControlViewModel
    {
        public NavigationService()
        {
            var container = TinyIoCContainer.Current;
            _container = container;
            _viewFactory = container.Resolve<IViewFactory>();
            _navigation = container.Resolve<INavigation>();
        }

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            PushPage<TViewModel>(_viewFactory.CreateView<TViewModel>());
        }

        public void NavigateTo<TViewModel>(Action<TViewModel> init) where TViewModel : BaseViewModel
        {
            var viewModel = _container.Resolve<TViewModel>();
            init(viewModel);
            PushPage<TViewModel>(_viewFactory.CreateView(viewModel));
        }

        public void PushPage<TViewModel>(Page page) where TViewModel : BaseViewModel
        {
            if (!_viewFactory.IsDetailView<TViewModel>())
            {
                _navigation.PushAsync(page);
            }
            else
            {
                var masterViewModel = MasterViewModel;
                UIPage masterPage = null;
                if (masterViewModel == null)
                {
                    masterPage = _viewFactory.CreateView<TMasterViewModel>();
                    masterViewModel = (TMasterViewModel)masterPage.BindingContext;
                }
                masterViewModel.Detail = page;
                if (MasterViewModel == null)
                {
                    _navigation.PushAsync(masterPage);
                }
            }
        }

        private readonly INavigation _navigation;
        private readonly IViewFactory _viewFactory;
        private readonly TinyIoCContainer _container;

        public TMasterViewModel MasterViewModel
        {
            get
            {
                var firstOrDefault = ViewStack.FirstOrDefault();
                return firstOrDefault?.BindingContext as TMasterViewModel;
            }
        }

        public IEnumerable<Page> ViewStack
        {
            get { return _navigation.NavigationStack; }
        }
    }

    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
        void NavigateTo<TViewModel>(Action<TViewModel> init) where TViewModel : BaseViewModel;
        IEnumerable<Page> ViewStack { get; }
        void PushPage<TViewModel>(Page page) where TViewModel : BaseViewModel;
    }

    public interface INavigationService<out TMasterViewModel> : INavigationService
        where TMasterViewModel : MasterDetailControlViewModel
    {
        TMasterViewModel MasterViewModel { get; }
    }
}