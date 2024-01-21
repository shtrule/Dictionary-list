using System;
using System.Collections.Generic;

namespace DictionaryList
{
    public class DictionaryUniqueList<TKey, TValue>
    {
        private Dictionary<TKey, HashSet<TValue>> dict = new Dictionary<TKey, HashSet<TValue>>();

        public void Add(TKey key, TValue value)
        {
            if (!dict.ContainsKey(key))
            {
                dict[key] = new HashSet<TValue>();
            }

            dict[key].Add(value);
        }

        public bool ContainsKey(TKey key)
        {
            return dict.ContainsKey(key);
        }

        public bool ContainsValue(TKey key, TValue value)
        {
            return dict.ContainsKey(key) && dict[key].Contains(value);
        }

        public bool Remove(TKey key)
        {
            return dict.Remove(key);
        }

        public bool Remove(TKey key, TValue value)
        {
            return dict.ContainsKey(key) && dict[key].Remove(value);
        }

        public IEnumerable<TKey> Keys => dict.Keys;

        public IEnumerable<TValue> Values(TKey key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key];
            }
            else
            {
                return new HashSet<TValue>();
            }
        }
    }
}
