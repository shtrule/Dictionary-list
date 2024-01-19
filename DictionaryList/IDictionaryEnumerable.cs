namespace DictionaryList
{
    public interface IDictionaryEnumerable<Tkey, TValue>
    {
        void Add(Tkey key, TValue value);
    }
}