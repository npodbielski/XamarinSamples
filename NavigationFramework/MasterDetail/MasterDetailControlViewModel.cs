using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NavigationFramework.ViewModels;
using Xamarin.Forms;

namespace NavigationFramework.MasterDetail
{
    public class MasterDetailControlViewModel : BaseViewModel, INavigation
    {
        private Page _detail;
        private INavigation _navigation;

        private Stack<Page> _pages = new Stack<Page>();

        public Page Detail
        {
            get { return _detail; }
            set
            {
                if (_detail != value)
                {
                    _pages.Push(Detail);
                    _detail = value;
                    OnPropertyChanged();
                }
            }
        }

        public IReadOnlyList<Page> ModalStack { get { return _navigation.ModalStack; } }

        public IReadOnlyList<Page> NavigationStack
        {
            get
            {
                if (_pages.Count == 0)
                {
                    return _navigation.NavigationStack;
                }
                var implPages = _navigation.NavigationStack;
                NavigationFramework.MasterDetail.MasterDetailControl master = null;
                var beforeMaster = implPages.TakeWhile(d =>
                {
                    master = d as NavigationFramework.MasterDetail.MasterDetailControl;
                    return master != null || d.GetType() == typeof(NavigationFramework.MasterDetail.MasterDetailControl);
                }).ToList();
                beforeMaster.AddRange(_pages);
                beforeMaster.AddRange(implPages.Where(d => !beforeMaster.Contains(d)
                    && d != master));
                return new ReadOnlyCollection<Page>(_navigation.NavigationStack.ToList());
            }
        }

        public void InsertPageBefore(Page page, Page before)
        {
            if (_pages.Contains(before))
            {
                var list = _pages.ToList();
                var indexOfBefore = list.IndexOf(before);
                list.Insert(indexOfBefore, page);
                _pages = new Stack<Page>(list);
            }
            else
            {
                _navigation.InsertPageBefore(page, before);
            }
        }

        public Task<Page> PopAsync()
        {
            Page page = null;
            if (_pages.Count > 0)
            {
                page = _pages.Pop();
                _detail = page;
                OnPropertyChanged("Detail");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync();
        }

        public Task<Page> PopAsync(bool animated)
        {
            Page page = null;
            if (_pages.Count > 0)
            {
                page = _pages.Pop();
                _detail = page;
                OnPropertyChanged("Detail");
            }
            return page != null ? Task.FromResult(page) : _navigation.PopAsync(animated);
        }

        public Task<Page> PopModalAsync()
        {
            return _navigation.PopModalAsync();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            return _navigation.PopModalAsync(animated);
        }

        public Task PopToRootAsync()
        {
            var firstPage = _navigation.NavigationStack[0];
            if (firstPage is NavigationFramework.MasterDetail.MasterDetailControl
                || firstPage.GetType() == typeof(NavigationFramework.MasterDetail.MasterDetailControl))
            {
                _pages = new Stack<Page>(new[] { _pages.FirstOrDefault() });
                return Task.FromResult(firstPage);
            }
            return _navigation.PopToRootAsync();
        }

        public Task PopToRootAsync(bool animated)
        {
            var firstPage = _navigation.NavigationStack[0];
            if (firstPage is NavigationFramework.MasterDetail.MasterDetailControl
                || firstPage.GetType() == typeof(NavigationFramework.MasterDetail.MasterDetailControl))
            {
                _pages = new Stack<Page>(new[] { _pages.FirstOrDefault() });
                return Task.FromResult(firstPage);
            }
            return _navigation.PopToRootAsync(animated);
        }

        public Task PushAsync(Page page)
        {
            Detail = page;
            return Task.FromResult(page);
        }

        public Task PushAsync(Page page, bool animated)
        {
            Detail = page;
            return Task.FromResult(page);
        }

        public Task PushModalAsync(Page page)
        {
            return _navigation.PushModalAsync(page);
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            return _navigation.PushModalAsync(page, animated);
        }

        public void RemovePage(Page page)
        {
            if (_pages.Contains(page))
            {
                var list = _pages.ToList();
                list.Remove(page);
                _pages = new Stack<Page>(list);
            }
            _navigation.RemovePage(page);
        }

        public void SetNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}