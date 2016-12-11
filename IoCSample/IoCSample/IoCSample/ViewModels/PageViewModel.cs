using System.Windows.Input;
using ViewFactorySample.ViewModels;
using Xamarin.Forms;

namespace IoCSample.ViewModels
{
    public class PageViewModel : NavigationBaseViewModel
    {
        private Command _toDetailPage;

        public void SetLabelText(string value)
        {
            Label = value;
        }

        public string Label { get; set; }

        public ICommand ToDetailPage
        {
            get
            {
                return _toDetailPage ?? (_toDetailPage = new Command(OnToDetailPage));
            }
        }

        private void OnToDetailPage()
        {
            NavigateTo<DetailViewModel>();
        }
    }
}
