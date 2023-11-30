public class FunctionCache<TKey, TResult> where TKey : notnull
{
    private readonly Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

    public delegate TResult FuncDelegate(TKey key);

    public TResult Execute(FuncDelegate func, TKey key, TimeSpan cacheDuration)
    {
        if (cache.TryGetValue(key, out var cacheItem) && !cacheItem.IsExpired(cacheDuration))
        {
            return cacheItem.Result;
        }

        TResult result = func(key);
        cache[key] = new CacheItem(result);

        return result;
    }

    private class CacheItem
    {
        public TResult Result { get; }
        public DateTime Timestamp { get; }

        public CacheItem(TResult result)
        {
            Result = result;
            Timestamp = DateTime.Now;
        }

        public bool IsExpired(TimeSpan duration)
        {
            return DateTime.Now - Timestamp > duration;
        }
    }
}