using System.Windows.Input;
using CustomMasterDetailControl;
using ViewFactorySample.View;
using Xamarin.Forms;

namespace ViewFactorySample.ViewModels
{
    public class WizardViewModel : BaseViewModel
    {
        private ICommand _toNextStep;

        public ICommand ToNextStep
        {
            get { return _toNextStep ?? (_toNextStep = new Command(OnToNextStep)); }
        }

        private void OnToNextStep()
        {
            var mainPage = ((NavigationPage)App.Current.MainPage).CurrentPage;
            var masterPageViewModel = (MasterDetailViewModel)mainPage.BindingContext;
            masterPageViewModel.Detail = masterPageViewModel.ViewFactory.CreateView<WizardViewModel, Step2View>(this);
        }
    }
}
