using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DictionaryList
{
    public class DictionaryList<Tkey, TValue> : IDictionaryEnumerable<Tkey, TValue>
    {
        private Dictionary<Tkey, List<TValue>> _internalDictionary = new Dictionary<Tkey, List<TValue>>();

        public int Count => throw new NotImplementedException();

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
            throw new NotImplementedException();
        }

        public int CountElementsByKey(Tkey key)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Tkey key)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
