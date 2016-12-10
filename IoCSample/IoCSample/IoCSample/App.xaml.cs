using System.Reflection;
using TinyIoC;
using ViewFactory.ViewFactory;

namespace IoCSample
{
    public partial class App
    {
        public App (IViewFactory factory)
        {
            factory.Init(Assembly.GetExecutingAssembly());
            InitializeComponent();
            var uiPage = factory.CreateView<MainPageViewModel>();
            MainPage = uiPage;
        }

        public void RegisterServices(TinyIoCContainer container)
        {
            
        }
    }
}
