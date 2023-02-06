using System.Reflection;

namespace ClientApplication.Services.ObjectService;
public static class ObjectService
{
    public static T ToObject<T>(IDictionary<string, object> source)
        where T : class, new()
    {
            var someObject = new T();
            var someObjectType = someObject.GetType();
            
            foreach (var item in source)
            {
                someObjectType?
                         .GetProperty(item.Key)?
                         .SetValue(someObject, item.Value, null);
            }

            return someObject;
    }
}