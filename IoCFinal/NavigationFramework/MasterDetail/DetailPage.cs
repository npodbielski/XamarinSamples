namespace NavigationFramework.MasterDetail
{
    public class DetailPage : UIPage
    {
        public DetailPage()
        {
            SideContentVisible = true;
        }

        public bool SideContentVisible { get; set; }
    }
}