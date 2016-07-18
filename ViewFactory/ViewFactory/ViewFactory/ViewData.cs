using System;
using CustomMasterDetailControl;

namespace ViewFactory.ViewFactory
{
    public class ViewData
    {
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public bool IsDetail { get; set; }
        public Func<UIPage> Creator { get; set; }
    }
}