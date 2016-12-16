using NavigationFramework.Services;

namespace NavigationFramework.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private readonly IDataCacheService _dataCacheService;
        private string _text;

        public DetailViewModel(IDataCacheService dataCacheService)
        {
            _dataCacheService = dataCacheService;
            if (_dataCacheService.DataCache.ContainsKey(CacheKey))
            {
                _text = (string)_dataCacheService.DataCache[CacheKey];
            }
        }

        public const string CacheKey = "CacheKey";

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                _dataCacheService.DataCache[CacheKey] = value;
            }
        }
    }
}