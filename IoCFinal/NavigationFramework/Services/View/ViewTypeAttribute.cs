using System;

namespace NavigationFramework.Services.View
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewTypeAttribute : Attribute
    {
        public ViewTypeAttribute(Type viewType)
        {
            ViewType = viewType;
        }

        public Type ViewType { get; }
    }
}