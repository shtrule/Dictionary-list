using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DictionaryList
{
    public class DictionarySortedList<TKey, TValue> : IDictionaryEnumerable<TKey, TValue>
    {
        private Dictionary<TKey, SortedList<int, TValue>> dict = new Dictionary<TKey, SortedList<int, TValue>>();

        public int Count => dict.Count;

        public void Add(TKey key, TValue value)
        {
            if (!ContainsKey(key))
            {
                dict.Add(key, new SortedList<int, TValue>());
                
            }
            
            dict[key].Add(dict[key].Count, value);
        }

        public void AddMultiple(TKey key, IEnumerable<TValue> value)
        {
            if (!ContainsKey(key))
            {
                dict.Add(key, new SortedList<int, TValue>());   
            }

            foreach (var elem in value) 
            {
                dict[key].Add(dict[key].Count, elem);
            }
        }

        public bool ContainsKey(TKey key)
        {
            return dict.ContainsKey(key);
        }

        public int CountElementsByKey(TKey key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key].Count;
            }
            
            return 0;
        }

        public IEnumerable<TValue> Get(TKey key)
        {
            if (dict.ContainsKey(key))
            {
                return dict[key].Values;
            }
            else
            {
                return new HashSet<TValue>();
            }
        }

        public void Remove(TKey key)
        {
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }
        }
    }
}