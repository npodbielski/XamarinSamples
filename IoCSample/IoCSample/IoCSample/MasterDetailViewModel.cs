using CustomMasterDetailControl;
using System.Windows.Input;
using ViewFactory.ViewFactory;
using ViewFactorySample.ViewModels;
using Xamarin.Forms;

namespace ViewFactorySample
{
    public class MasterDetailViewModel : MasterDetailControlViewModel
    {
        private readonly IViewFactory _viewFactory;
        private ICommand _toDetai;

        public MasterDetailViewModel(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }
        
        public ICommand ToDetail
        {
            get { return _toDetai ?? (_toDetai = new Command(OnToDetail)); }
        }
        
        private void OnToDetail()
        {
            Detail = _viewFactory.CreateView<DetailViewModel>();
        }
    }
}