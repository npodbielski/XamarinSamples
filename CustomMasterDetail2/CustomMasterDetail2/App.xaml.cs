using CustomMasterDetailControl;

namespace CustomMasterDetail2
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            MainPage = MasterDetailControl.Create<MasterDetail, MasterDetailViewModel>();
        }
    }
}
