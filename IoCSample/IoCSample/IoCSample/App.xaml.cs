using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using TinyIoC;

namespace IoCSample
{
    public partial class App
    {
        public static TinyIoCContainer IoC = new TinyIoCContainer();
        public App ()
        {
            IoC.AutoRegister();
            InitializeComponent ();
            //IoC.Register<MainPage>();
            //IoC.Register<MainPageViewModel>();
            MainPage = IoC.Resolve<MainPage>();
            //AppDomain
            MainPage.BindingContext = IoC.Resolve<MainPageViewModel>();
        }
    }
}
