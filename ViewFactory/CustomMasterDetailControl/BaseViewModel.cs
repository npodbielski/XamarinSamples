using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace CustomMasterDetailControl
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public INavigation Navigation
        {
            get { return App.Navigation; }
        }
    }
}
