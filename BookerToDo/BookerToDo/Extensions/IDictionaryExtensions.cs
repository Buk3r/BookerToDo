using System.Collections.Generic;

namespace BookerToDo.Extensions
{
    public static class IDictionaryExtensions
    {
        public static bool TryGetValue<T>(this IDictionary<string, object> dictionary, string key, out T value)
        {
            bool result = false;
            value = default;

            if (dictionary.TryGetValue(key, out object vaslueAsObject)
                && vaslueAsObject is T valueAsT)
            {
                value = valueAsT;
                result = true;
            }

            return result;
        }
    }
}
