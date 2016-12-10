using System;
using System.Reflection;
using CustomMasterDetailControl;

namespace ViewFactory.ViewFactory
{
    public interface IViewFactory
    {
        UIPage CreateView<TViewModel>() where TViewModel : BaseViewModel;

        UIPage CreateView<TViewModel, TView>() where TViewModel : BaseViewModel
            where TView : UIPage;

        UIPage CreateView<TViewModel, TView>(TViewModel viewModel) where TViewModel : BaseViewModel
            where TView : UIPage;

        UIPage CreateView(Type viewModelType);
        void Init(Assembly appAssembly);
    }
}