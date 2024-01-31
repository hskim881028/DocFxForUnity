namespace V8.UI.Runtime.Provider
{
    public interface IFactoryProvider<out T>
    {
        public T GetFactory(string type);
    }
}