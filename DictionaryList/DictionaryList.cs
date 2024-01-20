using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryList
{
    public class DictionaryList<Tkey, TValue> : IDictionaryEnumerable<Tkey, TValue>
    {
        private Dictionary<Tkey, List<TValue>> _internalDictionary = new Dictionary<Tkey, List<TValue>>();

        public int Count => _internalDictionary.Count;

        public void Add(Tkey key, TValue value)
        {
            if (_internalDictionary.ContainsKey(key)) 
            {
                _internalDictionary[key].Add(value);
            }
            else 
            {
                _internalDictionary.Add(key, new List<TValue>() {value});
            }
        }

        public void AddMultiple(Tkey key, IEnumerable<TValue> value)
        {
            if (!_internalDictionary.ContainsKey(key)) 
            {
                _internalDictionary[key].AddRange(value);
            } 
            else 
            {
                _internalDictionary.Add(key, value.ToList());
            }
        }

        public int CountElementsByKey(Tkey key)
        {
            if (_internalDictionary.TryGetValue(key, out var values)) {
                return values.Count;
            }

            return 0;
        }

        public bool ContainsKey(Tkey key)
        {
            return _internalDictionary.ContainsKey(key);
        }

        public IEnumerable<TValue> Get(Tkey key)
        {
            if (_internalDictionary.TryGetValue(key, out var values)) 
            {
                return values;
            }

            return new List<TValue>();
        }

        public void Remove(Tkey key)
        {
            _internalDictionary.Remove(key);
        }
    }
}
