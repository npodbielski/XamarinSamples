using System;
using Xamarin.Forms;

//namespace MasterDetail
//{
//    public partial class MasterPage
//    {
//        public MasterPage()
//        {
//            InitializeComponent();
//        }

//        private void Button1_OnClicked(object sender, EventArgs e)
//        {
//            Detail = new NavigationPage(new Detail1());
//        }

//        private void Button2_OnClicked(object sender, EventArgs e)
//        {
//            Detail = new NavigationPage(new Detail2());
//        }

//        private void Button3_OnClicked(object sender, EventArgs e)
//        {
//            Detail = new NavigationPage(new Detail3());
//        }
//    }
//}

namespace MasterDetail
{
    public partial class MasterPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private void Button1_OnClicked(object sender, EventArgs e)
        {
            ChangeDetail(new Detail1());
        }

        private void Button2_OnClicked(object sender, EventArgs e)
        {
            ChangeDetail(new Detail2());
        }

        private void Button3_OnClicked(object sender, EventArgs e)
        {
            ChangeDetail(new Detail3());
        }

private void Button4_OnClicked(object sender, EventArgs e)
{
    App.Current.MainPage = new Detail4();
}

        private void ChangeDetail(Page page)
        {
            var navigationPage = Detail as NavigationPage;
            if (navigationPage != null)
            {
                navigationPage.PushAsync(page);
                return;
            }
            Detail = new NavigationPage(page);
        }
    }
}