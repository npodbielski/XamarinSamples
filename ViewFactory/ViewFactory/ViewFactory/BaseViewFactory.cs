using CustomMasterDetailControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ViewFactory.Extensions;
using Xamarin.Forms;

namespace ViewFactory.ViewFactory
{
    public abstract class BaseViewFactory : IViewFactory
    {
        public static Dictionary<Type, ViewData> Views = new Dictionary<Type, ViewData>();

        private const string ViewModelPrefix = "Model";
        private readonly Dictionary<Type, Func<UIPage>> _unconnectedViews = new Dictionary<Type, Func<UIPage>>();

        public UIPage CreateView<TViewModel>() where TViewModel : BaseViewModel
        {
            return CreateView(typeof(TViewModel));
        }

        public bool IsDetailView(Type viewModelType)
        {
            return Views[viewModelType].IsDetail;
        }

        public bool IsDetailView<TViewModel>() where TViewModel : BaseViewModel
        {
            return IsDetailView(typeof(TViewModel));
        }

        public UIPage CreateView<TViewModel, TView>() where TViewModel : BaseViewModel
            where TView : UIPage
        {
            var type = typeof(TView);
            if (!_unconnectedViews.ContainsKey(type))
            {
                _unconnectedViews[type] = GetViewCreator(type);
            }
            return CreateView(typeof(TViewModel), _unconnectedViews[type]);
        }

        public UIPage CreateView<TViewModel, TView>(TViewModel viewModel) where TViewModel : BaseViewModel
            where TView : UIPage
        {
            var type = typeof(TView);
            if (!_unconnectedViews.ContainsKey(type))
            {
                _unconnectedViews[type] = GetViewCreator(type);
            }
            return CreateView(viewModel, _unconnectedViews[type]);
        }

        public UIPage CreateView<TViewModel>(TViewModel viewModel)
        {
            var viewModelType = viewModel.GetType();
            if (Views.ContainsKey(viewModelType))
            {
                var viewData = Views[viewModelType];
                return CreateView(viewModel, viewData.Creator);
            }
            return null;
        }

        public UIPage CreateView(Type viewModelType)
        {
            if (Views.ContainsKey(viewModelType))
            {
                var viewData = Views[viewModelType];
                return CreateView(viewModelType, viewData.Creator);
            }
            return null;
        }

        public void Init(Assembly appAssembly)
        {
            var assemblies = GetViewAssemblies();
            foreach (var assembly in assemblies)
            {
                if (!assembly.Equals(appAssembly))
                {
                    ScanAssembly(assembly);
                }
            }
            //override libraries views with app assembly
            ScanAssembly(appAssembly, true);
        }

        protected abstract ConstructorInfo GetDefaultConstructor(Type page);

        protected abstract Assembly[] GetViewAssemblies();

        private static UIPage CreateView(Type viewModelType, Func<UIPage> creator)
        {
            var viewModel = Activator.CreateInstance(viewModelType);
            return CreateView(viewModel, creator);
        }

        private static UIPage CreateView(object viewModel, Func<UIPage> creator)
        {
            var page = creator();
            page.BindingContext = viewModel;
            return page;
        }

        private Func<UIPage> GetViewCreator(Type page)
        {
            return (Func<UIPage>)Expression.Lambda(Expression.New(GetDefaultConstructor(page))).Compile();
        }

        private ViewData GetViewData(Type viewModel, Type page)
        {
            return new ViewData
            {
                ViewModelType = viewModel,
                IsDetail = page.IfHaveBaseClassOf<DetailPage>(),
                ViewType = page,
                Creator = GetViewCreator(page),
            };
        }

        private void ScanAssembly(Assembly appAssebly, bool @override = false)
        {
            var pages = appAssebly.DefinedTypes.Where(t => t.IfHaveBaseClassOf<UIPage>()).ToArray();
            var viewModels = appAssebly.DefinedTypes.Where(t => t.IfHaveBaseClassOf<BaseViewModel>());

            foreach (var viewModel in viewModels)
            {
                var viewTypeAttribute = viewModel.GetCustomAttribute<ViewTypeAttribute>();
                var page = viewTypeAttribute != null
                    ? viewTypeAttribute.ViewType
                    : pages.FirstOrDefault(p => p.Name == viewModel.Name.Replace(ViewModelPrefix, ""))?.AsType();
                if (page != null)
                {
                    var asType = viewModel.AsType();
                    if (!Views.ContainsKey(asType))
                    {
                        Views.Add(asType, GetViewData(asType, page));
                    }
                }
            }
            //no view model in assembly and if app assembly -> override
            if (@override)
            {
                foreach (var page in pages)
                {
                    var viewToOverride = Views.FirstOrDefault(kv => kv.Key.Name == page.Name + ViewModelPrefix);
                    if (viewToOverride.Key != null)
                    {
                        Views[viewToOverride.Key] = GetViewData(viewToOverride.Value.ViewModelType, page.AsType());
                    }
                }
            }
        }
    }
}