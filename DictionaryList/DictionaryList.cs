using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryList
{
    public class DictionaryList<Tkey, TValue> : IDictionaryEnumerable<Tkey, TValue>
    {
        private Dictionary<Tkey, List<TValue>> _dictionary;

        public DictionaryList() : this(EqualityComparer<Tkey>.Default) { }

        public DictionaryList(IEqualityComparer<Tkey> comparer)
        {
            _dictionary = new Dictionary<Tkey, List<TValue>>(comparer);
        }

        public int Count => _dictionary.Count;

        public void Add(Tkey key, TValue value)
        {
            if (_dictionary.ContainsKey(key)) 
            {
                _dictionary[key].Add(value);
            }
            else 
            {
                _dictionary.Add(key, new List<TValue>() {value});
            }
        }

        public void AddMultiple(Tkey key, IEnumerable<TValue> value)
        {
            if (_dictionary.ContainsKey(key)) 
            {
                _dictionary[key].AddRange(value);
            } 
            else 
            {
                _dictionary.Add(key, value.ToList());
            }
        }

        public int CountElementsByKey(Tkey key)
        {
            if (_dictionary.TryGetValue(key, out var values)) {
                return values.Count;
            }

            return 0;
        }

        public bool ContainsKey(Tkey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public IEnumerable<TValue> Get(Tkey key)
        {
            if (_dictionary.TryGetValue(key, out var values)) 
            {
                return values;
            }

            return new List<TValue>();
        }

        public void Remove(Tkey key)
        {
            _dictionary.Remove(key);
        }
    }
}
