using System.Reflection;
using IoCSample.Services;
using IoCSample.Services.Navigation;
using IoCSample.ViewModels;
using TinyIoC;
using ViewFactory.ViewFactory;
using Xamarin.Forms;

namespace IoCSample
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
            var navigationPage = new NavigationPage(ViewFactory.CreateView<MainPageViewModel>());
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
