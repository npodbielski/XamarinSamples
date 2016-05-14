using Xamarin.Forms;

namespace CustomMasterDetailControl
{
    public class DetailPage : ContentPage
    {
        public DetailPage()
        {
            SideContentVisible = true;
        }

        public bool SideContentVisible { get; set; }
    }
}