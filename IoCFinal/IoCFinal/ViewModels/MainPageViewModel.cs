using System.Windows.Input;
using Xamarin.Forms;

namespace NavigationFramework.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Command _toPage;

        public MainPageViewModel()
        {
            MainText = "Main Page Text";
        }

        public string MainText { get; set; }
        
        public ICommand ToPage
        {
            get
            {
                return _toPage ?? (_toPage = new Command(() =>
                {
                    NavigateTo<PageViewModel>(vm => vm.SetLabelText("Value from MainPageViewModel"));
                }));
            }
        }
    }
}