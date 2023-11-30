using System.Reflection;

namespace Tasks1_3;

public static class InstanceService
{
    public static IEnumerable<T> GetInstances<T>()
    {
        List<T> objects = Assembly.GetAssembly(typeof(T))?
            .GetTypes()
            .Where(myType => myType is { IsClass: true, IsAbstract: false } && myType.IsSubclassOf(typeof(T)))
            .Select(type => (T)Activator.CreateInstance(type))
            .ToList();
        
        return objects;
    }
}