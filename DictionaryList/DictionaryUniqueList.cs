using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace DictionaryList
{
    public class DictionaryUniqueList<Tkey, TValue> : IDictionaryEnumerable<Tkey, TValue>
    {
        public int Count => throw new NotImplementedException();

        public void Add(Tkey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public void AddMultiple(Tkey key, IEnumerable<TValue> value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Tkey key)
        {
            throw new NotImplementedException();
        }

        public int CountElementsByKey(Tkey key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TValue> Get(Tkey key)
        {
            throw new NotImplementedException();
        }

        public void Remove(Tkey key)
        {
            throw new NotImplementedException();
        }
    }
}
