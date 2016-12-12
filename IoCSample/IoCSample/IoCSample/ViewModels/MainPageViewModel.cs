using System.Windows.Input;
using Xamarin.Forms;

namespace IoCSample.ViewModels
{
    public class MainPageViewModel : NavigationBaseViewModel
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