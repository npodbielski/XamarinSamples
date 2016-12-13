using CustomMasterDetailControl;
using System;
using System.Linq;
using TinyIoC;
using Xamarin.Forms;
using ViewFactory.ViewFactory;

namespace IoCSample.Services.Navigation
{
    public class NavigationService<TMasterViewModel> : INavigationService<TMasterViewModel>
        where TMasterViewModel : MasterDetailControlViewModel
    {
        private readonly TinyIoCContainer _container;

        private readonly INavigation _navigation;

        private readonly IViewFactory _viewFactory;

        public NavigationService()
        {
            var container = TinyIoCContainer.Current;
            _container = container;
            _viewFactory = container.Resolve<IViewFactory>();
            _navigation = container.Resolve<INavigation>();
        }

        public TMasterViewModel MasterViewModel
        {
            get
            {
                var firstOrDefault = _navigation.NavigationStack.LastOrDefault();
                return firstOrDefault?.BindingContext as TMasterViewModel;
            }
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
                    masterViewModel.SetNavigation(_navigation);
                }
                masterViewModel.Detail = page;
                if (MasterViewModel == null)
                {
                    _navigation.PushAsync(masterPage);
                }
            }
        }
    }
}