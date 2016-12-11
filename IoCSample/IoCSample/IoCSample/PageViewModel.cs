namespace IoCSample
{
    public class PageViewModel : NavigationBaseViewModel
    {
        public void SetLabelText(string value)
        {
            Label = value;
        }

        public string Label { get; set; }
    }
}
