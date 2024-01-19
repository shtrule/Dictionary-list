using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DictionaryList
{
    public class DictionaryList<Tkey, TValue> : IDictionaryEnumerable<Tkey, TValue>
    {
        private Dictionary<Tkey, List<TValue>> _internalDictionary = new Dictionary<Tkey, List<TValue>>();
        
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
    }
}
