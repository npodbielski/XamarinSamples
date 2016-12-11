using System.Reflection;
using TinyIoC;
using ViewFactory.ViewFactory;
using Xamarin.Forms;

namespace IoCSample
{
    public partial class App
    {
        public IViewFactory viewFactory { get; set; }

        public App()
        {
            var container = TinyIoCContainer.Current;
            container.BuildUp(this);
            viewFactory.Init(Assembly.GetExecutingAssembly());
            InitializeComponent();
            var navigationPage = new NavigationPage(viewFactory.CreateView<MainPageViewModel>());
            container.Register(navigationPage.Navigation);
            MainPage = navigationPage;
        }

        public void RegisterServices(TinyIoCContainer container)
        {

        }
    }
}
