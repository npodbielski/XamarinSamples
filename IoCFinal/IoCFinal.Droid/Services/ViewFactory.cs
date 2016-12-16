using System;
using System.Linq;
using System.Reflection;
using NavigationFramework.Services.View;
using TinyIoC;

namespace IoCFinal.Services
{
    public class ViewFactory : BaseViewFactory
    {
        protected override ConstructorInfo GetDefaultConstructor(Type page)
        {
            return page.GetConstructor(Type.EmptyTypes);
        }

        protected override Assembly[] GetViewAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.CustomAttributes.Any(ca => ca.AttributeType == typeof(ViewAssemblyAttribute))).ToArray();
        }

        public ViewFactory(TinyIoCContainer container) : base(container)
        {
        }
    }
}