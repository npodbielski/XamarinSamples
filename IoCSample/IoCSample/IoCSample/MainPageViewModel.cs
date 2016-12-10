using CustomMasterDetailControl;

namespace IoCSample
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            MainText = "Main Page Text";
        }
        public string MainText { get; set; }
    }
}
