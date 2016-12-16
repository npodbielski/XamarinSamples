using System.Reflection;
using NavigationFramework.Services;
using NavigationFramework.Services.Navigation;
using NavigationFramework.Services.View;
using NavigationFramework.ViewModels;
using TinyIoC;
using Xamarin.Forms;

namespace IoCFinal
{
    public partial class App
    {
        public IViewFactory ViewFactory { get; set; }

        public App()
        {
            var container = TinyIoCContainer.Current;
            container.BuildUp(this);
            ViewFactory.Init(Assembly.GetExecutingAssembly());
            InitializeComponent();
            var uiPage = ViewFactory.CreateView<MainPageViewModel>();
            var navigationPage = new NavigationPage(uiPage);
            container.Register(navigationPage.Navigation);
            MainPage = navigationPage;
        }

        public void RegisterServices(TinyIoCContainer container)
        {
            container.Register<INavigationService, NavigationService<MasterDetailViewModel>>();
            container.Register<IDataCacheService, DataCacheService>().AsSingleton();
        }
    }
}
