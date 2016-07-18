using Xamarin.Forms;

namespace CustomMasterDetailControl
{
    public partial class MasterDetailControl
    {
        public static readonly BindableProperty SideContentProperty = BindableProperty.Create("SideContent",
            typeof(View), typeof(MasterDetailControl), null, propertyChanged: (bindable, value, newValue) =>
            {
                var control = (MasterDetailControl)bindable;
                control.SideContentContainer.Children.Clear();
                control.SideContentContainer.Children.Add(control.SideContent);
            });

        public readonly BindableProperty DetailProperty = BindableProperty.Create("Detail",
            typeof(ContentPage), typeof(MasterDetailControl),
            propertyChanged: (bindable, value, newValue) =>
            {
                var masterPage = (MasterDetailControl)bindable;
                View content;
                var contentPage = (ContentPage)newValue;
                if (contentPage != null)
                {
                    content = contentPage.Content;
                    content.BindingContext = contentPage.BindingContext;
                }
                else content = null;
                masterPage.DetailContainer.Content = content;
                masterPage.OnPropertyChanged("SideContentVisible");
            });

        public MasterDetailControl()
        {
            InitializeComponent();
            SetBinding(DetailProperty, new Binding("Detail", BindingMode.OneWay));
        }

        public ContentPage Detail
        {
            get { return (ContentPage)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }

        public View SideContent
        {
            get { return (View)GetValue(SideContentProperty); }
            set { SetValue(SideContentProperty, value); }
        }

        public bool SideContentVisible
        {
            get
            {
                var detailPage = Detail as DetailPage;
                if (detailPage != null)
                {
                    return detailPage.SideContentVisible;
                }
                return true;
            }
        }

        public static Page CreateMainPage<TView, TViewModel>() where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel, new()
        {
            return CreateMainPage<TView, TViewModel>(new TViewModel());
        }

        public static Page CreateMainPage<TView, TViewModel>(TViewModel viewModel) where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel
        {
            var masterDetail = CreateControl<TView, TViewModel>(viewModel);
            var navigationPage = new NavigationPage(masterDetail);
            viewModel.SetNavigation(navigationPage.Navigation);
            return navigationPage;
        }

        public static TView CreateControl<TView, TViewModel>(TViewModel viewModel)
            where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel
        {
            var masterDetail = new TView { BindingContext = viewModel };
            return masterDetail;
        }

        protected override bool OnBackButtonPressed()
        {
            var viewModel = BindingContext as MasterDetailControlViewModel;
            if (viewModel != null)
            {
                var navigation = (INavigation)viewModel;
                navigation.PopAsync();
                return true;
            }
            return base.OnBackButtonPressed();
        }
    }
}