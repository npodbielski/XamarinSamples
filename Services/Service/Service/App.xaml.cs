using Service.ViewModel;
using TinyIoC;

namespace Service
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            var mainPageViewModel = TinyIoCContainer.Current.Resolve<MainPageViewModel>();
            MainPage = new MainPageView
            {
                BindingContext = mainPageViewModel
            };
        }
    }
}
