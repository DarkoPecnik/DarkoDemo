using Microsoft.Extensions.Caching.Memory;

namespace DarkoDemo.Messaging.Extensions;

public static class MemoryCacheExtensions
{
    public static IEnumerable<object> GetKeys(this IMemoryCache cache)
    {
        if (cache is MemoryCache memCache)
        {
            var entries = memCache
                .GetType()
                .GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(memCache);

            if (entries is not null)
            {
                foreach (var entry in (dynamic)entries)
                {
                    yield return entry.GetType().GetProperty("Key")?.GetValue(entry, null)!;
                }
            }
        }
    }
}
