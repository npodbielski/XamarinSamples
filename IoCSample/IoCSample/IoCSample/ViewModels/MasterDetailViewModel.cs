using CustomMasterDetailControl;
using System.Windows.Input;
using ViewFactorySample.ViewModels;
using Xamarin.Forms;

namespace IoCSample.ViewModels
{
    public class MasterDetailViewModel : MasterDetailControlViewModel
    {
        private ICommand _toDetai;
        
        public ICommand ToDetail
        {
            get { return _toDetai ?? (_toDetai = new Command(OnToDetail)); }
        }
        
        private void OnToDetail()
        {
            NavigationHelper.NavigateTo<Detail1ViewModel>();
        }
    }
}