using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StylesInheritance
{
    [ContentProperty("KeyOrType")]
    public class StaticResourceExtExtension : IMarkupExtension
    {
        private readonly StaticResourceExtension _xamarinStaticExtension;

        public StaticResourceExtExtension()
        {
            _xamarinStaticExtension = new StaticResourceExtension();
        }

        public object KeyOrType { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var type = KeyOrType as Type;
            if (type != null)
            {
                _xamarinStaticExtension.Key = type.FullName;
            }
            else
            {
                var s = KeyOrType as string;
                if (s != null)
                {
                    const string xType = "{x:Type ";
                    if (s.StartsWith(xType))
                    {
                        var typeName = s.Replace(xType, "");
                        var xamlTypeResolver = (IXamlTypeResolver)serviceProvider.GetService(typeof(IXamlTypeResolver));
                        _xamarinStaticExtension.Key = xamlTypeResolver.Resolve(typeName, serviceProvider).FullName;
                    }
                    else
                    {
                        _xamarinStaticExtension.Key = s;
                    }
                }
            }
            return _xamarinStaticExtension.ProvideValue(serviceProvider);
        }
    }
}