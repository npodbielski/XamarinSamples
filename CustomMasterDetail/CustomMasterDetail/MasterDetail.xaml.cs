using CustomMasterDetail.ViewModel;
using Xamarin.Forms;

namespace CustomMasterDetail
{
    public partial class MasterDetail
    {
        public readonly BindableProperty DetailProperty = BindableProperty.Create("Detail",
            typeof(ContentPage), typeof(MasterDetail),
            propertyChanged: (bindable, value, newValue) =>
            {
                var masterPage = (MasterDetail)bindable;
                masterPage.DetailContainer.Content = newValue != null ?
                    ((ContentPage)newValue).Content : null;
            });

        public MasterDetail()
        {
            InitializeComponent();
            SetBinding(DetailProperty, new Binding("Detail", BindingMode.OneWay));
        }

        public ContentPage Detail
        {
            get { return (ContentPage)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }

        protected override bool OnBackButtonPressed()
        {
            var viewModel = BindingContext as MasterDetailViewModel;
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