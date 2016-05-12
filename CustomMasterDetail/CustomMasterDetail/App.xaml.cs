using CustomMasterDetail.ViewModel;
using Xamarin.Forms;

namespace CustomMasterDetail
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            var masterDetail = new MasterDetail();
            var navigationPage = new NavigationPage(masterDetail);
            MainPage = navigationPage;
            masterDetail.BindingContext = new MasterDetailViewModel(navigationPage.Navigation);
        }
    }
}
