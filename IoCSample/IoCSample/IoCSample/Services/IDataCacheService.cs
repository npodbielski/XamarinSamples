using System.Collections.Generic;

namespace IoCSample.Services
{
    public interface IDataCacheService
    {
        Dictionary<string, object> DataCache { get; }
    }
}