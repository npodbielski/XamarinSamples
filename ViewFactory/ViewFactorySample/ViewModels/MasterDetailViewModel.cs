using CustomMasterDetailControl;
using ExternalAssembly;
using System.Windows.Input;
using ViewFactorySample.View;
using ViewFactorySample.ViewModels;
using Xamarin.Forms;
using VF = ViewFactory.ViewFactory.ViewFactory;

namespace ViewFactorySample
{
    public class MasterDetailViewModel : MasterDetailControlViewModel
    {
        private readonly VF _viewFactory;

        private ICommand _toCustomConnection;
        private ICommand _toDetai;

        private ICommand _toExternalPage;
        private ICommand _toOrdinaryPage;

        private ICommand _toOverridenPage;

        private ICommand _toWizard;

        public MasterDetailViewModel()
        {
            _viewFactory = App.ViewFactory;
        }

        public ICommand ToCustomConnection
        {
            get { return _toCustomConnection ?? (_toCustomConnection = new Command(OnToCustomConnection)); }
        }

        public ICommand ToDetail
        {
            get { return _toDetai ?? (_toDetai = new Command(OnToDetail)); }
        }

        public ICommand ToExternalPage
        {
            get { return _toExternalPage ?? (_toExternalPage = new Command(OnToExternal)); }
        }

        public ICommand ToOrdinaryPage
        {
            get { return _toOrdinaryPage ?? (_toOrdinaryPage = new Command(OnToOrdinaryPage)); }
        }

        public ICommand ToOverridenPage
        {
            get { return _toOverridenPage ?? (_toOverridenPage = new Command(OnToOverriden)); }
        }

        public ICommand ToWizard
        {
            get { return _toWizard ?? (_toWizard = new Command(OnToWizard)); }
        }

        public VF ViewFactory
        {
            get { return _viewFactory; }
        }

        private void OnToCustomConnection()
        {
            Detail = _viewFactory.CreateView<NoViewViewModel>();
        }

        private void OnToDetail()
        {
            Detail = _viewFactory.CreateView<DetailViewModel>();
        }

        private void OnToExternal()
        {
            Detail = _viewFactory.CreateView<ExternalViewModel>();
        }

        private void OnToOrdinaryPage()
        {
            Navigation.PushAsync(_viewFactory.CreateView<OrdinaryPageViewModel>());
        }

        private void OnToOverriden()
        {
            Detail = _viewFactory.CreateView<ToOverrideViewModel>();
        }

        private void OnToWizard()
        {
            Detail = _viewFactory.CreateView<WizardViewModel, Step1View>();
        }
    }
}