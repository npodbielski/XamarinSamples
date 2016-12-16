using NavigationFramework.Services;

namespace NavigationFramework.ViewModels
{
    public class Detail1ViewModel : BaseViewModel
    {
        public Detail1ViewModel(IDataCacheService dataCacheService)
        {
            if (dataCacheService.DataCache.ContainsKey(DetailViewModel.CacheKey))
            {
                Text = (string)dataCacheService.DataCache[DetailViewModel.CacheKey];
            }
        }

        public string Text { get; private set; }
    }
}
