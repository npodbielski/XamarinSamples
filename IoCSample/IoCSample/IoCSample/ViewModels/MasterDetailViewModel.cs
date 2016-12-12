using CustomMasterDetailControl;
using System.Windows.Input;
using ViewFactorySample.ViewModels;
using Xamarin.Forms;

namespace IoCSample.ViewModels
{
    public class MasterDetailViewModel : MasterDetailControlViewModel
    {
        private ICommand _toDetail;
        private ICommand _toDetail1;

        public ICommand ToDetail
        {
            get { return _toDetail ?? (_toDetail = new Command(OnToDetail)); }
        }

        public ICommand ToDetail1
        {
            get { return _toDetail1 ?? (_toDetail1 = new Command(OnToDetail1)); }
        }

        private void OnToDetail1()
        {
            NavigationHelper.NavigateTo<Detail1ViewModel>();
        }

        private void OnToDetail()
        {
            NavigationHelper.NavigateTo<DetailViewModel>();
        }
    }
}