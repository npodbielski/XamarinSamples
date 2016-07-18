using System;
using System.Linq;
using System.Reflection;

namespace ViewFactory.ViewFactory
{
    public class ViewFactory : BaseViewFactory
    {
        protected override Assembly[] GetViewAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a=>a.CustomAttributes.Any(ca=>ca.AttributeType==typeof(ViewAssemblyAttribute))).ToArray();
        }

        protected override ConstructorInfo GetDefaultConstructor(Type page)
        {
            return page.GetConstructor(Type.EmptyTypes);
        }
    }
}
