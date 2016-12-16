using System.Windows.Input;
using Xamarin.Forms;

namespace NavigationFramework.ViewModels
{
    public class PageViewModel : BaseViewModel
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
