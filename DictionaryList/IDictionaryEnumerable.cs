using System.Collections.Generic;
using System.Threading;

namespace DictionaryList
{
    public interface IDictionaryEnumerable<Tkey, TValue>
    {
        void Add(Tkey key, TValue value);
        void AddMultiple(Tkey key, IEnumerable<TValue> value);
        void Remove(Tkey key);
        bool ContainsKey(Tkey key);
        IEnumerable<TValue> Get(Tkey key);
        int Count { get; }
        int CountElementsByKey(Tkey key);
    }
}