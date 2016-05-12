using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace FrameBug
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private ICommand _changeColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ChangeColor => _changeColor ?? (_changeColor = new Command(OnChangeColor));

        public Color LineColor { get; set; } = Color.Green;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnChangeColor()
        {
            LineColor = Color.Red;
            OnPropertyChanged("LineColor");
        }
    }
}