using System.Linq;
using Xamarin.Forms;

namespace Styles
{
    public class FrameExt : Frame
    {
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == StyleProperty.PropertyName)
            {
                if (Style.Setters.Any(s => s.Property == PaddingProperty))
                {
                    Padding = (Thickness)Style.Setters.First(s => s.Property == PaddingProperty).Value;
                }
            }
        }
    }
}