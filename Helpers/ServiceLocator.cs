static class ServiceLocator
{
    private static readonly Dictionary<Type, object> listServices = new Dictionary<Type, object>();

    public static void Register<T>(T service)
    {
        listServices[typeof(T)] = service!;
    }

    public static T Resolve<T>()
    {
        if (!listServices.ContainsKey(typeof(T)))
        {
            Console.WriteLine($"The service of type {typeof(T)} is not registered.");
            return default!;
        }
        return (T)listServices[typeof(T)];
    }
}