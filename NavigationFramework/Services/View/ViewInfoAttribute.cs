using System;

namespace NavigationFramework.Services.View
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewInfoAttribute : Attribute
    {
        public string ViewSelectMethodName { get; set; }

        public object ViewValue { get; set; }
    }
}