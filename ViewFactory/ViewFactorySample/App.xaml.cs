using System.Reflection;
using CustomMasterDetailControl;
using VF = ViewFactory.ViewFactory.ViewFactory;

namespace ViewFactorySample
{
    public partial class App
    {
        public static readonly VF ViewFactory = new VF();
        public App()
        {
            InitializeComponent();
            ViewFactory.Init(Assembly.GetExecutingAssembly());
            MainPage = MasterDetailControl.CreateMainPage<MasterDetail, MasterDetailViewModel>();
            Navigation = MainPage.Navigation;
        }
    }
}
