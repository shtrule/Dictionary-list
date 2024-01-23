using System;
using System.Collections.Generic;

namespace DictionaryList
{
    public class DictionaryUniqueList<TKey, TValue> : IDictionaryEnumerable<TKey, TValue>
    {
        private Dictionary<TKey, HashSet<TValue>> _dictionary;
        private IEqualityComparer<TValue> _valueComparer;

        public DictionaryUniqueList(IEqualityComparer<TKey> keyComparer = null, IEqualityComparer<TValue> valueComparer = null)
        {
            _dictionary = new Dictionary<TKey, HashSet<TValue>>(keyComparer ?? EqualityComparer<TKey>.Default);
            _valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;
        }

        public DictionaryUniqueList(IEqualityComparer<TValue> valueComparer) : this(EqualityComparer<TKey>.Default)
        {
            _valueComparer = valueComparer;
        }

        public void Add(TKey key, TValue value)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary[key] = new HashSet<TValue>(_valueComparer);
            }

            _dictionary[key].Add(value);
        }

        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public bool ContainsValue(TKey key, TValue value)
        {
            return _dictionary.ContainsKey(key) && _dictionary[key].Contains(value);
        }

        public void Remove(TKey key)
        {
            _dictionary.Remove(key);
        }

        public bool Remove(TKey key, TValue value)
        {
            return _dictionary.ContainsKey(key) && _dictionary[key].Remove(value);
        }

        public IEnumerable<TKey> Keys => _dictionary.Keys;

        public int Count => _dictionary.Count;

        public IEnumerable<TValue> Values(TKey key)
        {
            if (_dictionary.ContainsKey(key))
            {
                return _dictionary[key];
            }
            else
            {
                return new HashSet<TValue>();
            }
        }

        public void AddMultiple(TKey key, IEnumerable<TValue> values)
        {
            if (!_dictionary.ContainsKey(key)) 
            {
                _dictionary[key] = new HashSet<TValue>(_valueComparer);
            } 
            
            foreach (var value in values) {
                _dictionary[key].Add(value);
            }
        }

        public IEnumerable<TValue> Get(TKey key)
        {
            if (_dictionary.TryGetValue(key, out var values)) 
            {
                return values;
            }

            return new List<TValue>();
        }

        public int CountElementsByKey(TKey key)
        {
            if (_dictionary.TryGetValue(key, out var values)) {
                return values.Count;
            }

            return 0;
        }
    }
}
