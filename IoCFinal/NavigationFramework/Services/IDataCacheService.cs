using System.Collections.Generic;

namespace NavigationFramework.Services
{
    public interface IDataCacheService
    {
        Dictionary<string, object> DataCache { get; }
    }
}