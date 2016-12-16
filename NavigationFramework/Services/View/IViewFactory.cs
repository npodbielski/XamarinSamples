﻿using System;
using System.Reflection;
using NavigationFramework.MasterDetail;
using NavigationFramework.ViewModels;

namespace NavigationFramework.Services.View
{
    public interface IViewFactory
    {
        UIPage CreateView<TViewModel>() where TViewModel : BaseViewModel;

        UIPage CreateView<TViewModel, TView>() where TViewModel : BaseViewModel
            where TView : UIPage;

        UIPage CreateView<TViewModel, TView>(TViewModel viewModel) where TViewModel : BaseViewModel
            where TView : UIPage;

        UIPage CreateView(Type viewModelType);

        UIPage CreateView<TViewModel>(TViewModel viewModel);

        void Init(Assembly appAssembly);
        bool IsDetailView(Type page);
        bool IsDetailView<TViewModel>() where TViewModel : BaseViewModel;
    }
}