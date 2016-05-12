namespace FrameBug
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            BindingContext = new AppViewModel();
        }
    }
}
