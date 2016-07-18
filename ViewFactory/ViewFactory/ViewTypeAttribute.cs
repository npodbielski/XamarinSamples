using System;

namespace ViewFactory
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