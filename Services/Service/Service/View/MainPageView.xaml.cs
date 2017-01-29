using Service.ViewModel;

namespace Service
{
    public partial class MainPageView
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        private MainPageViewModel ViewModel
        {
            get { return (MainPageViewModel)BindingContext; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.OnDisappering();
        }
    }
}
