using System.Windows.Input;
using Xamarin.Forms;

namespace MasterDetail
{
    public class MasterViewModel
    {
        private ICommand _goDetail1;

        public ICommand GoDetail1
        {
            get { return _goDetail1 ?? (_goDetail1 = new Command(() =>
            {
                
            })); }
        }
    }
}
