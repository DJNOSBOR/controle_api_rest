using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Core
{
    public static class TypeExtensions
    {

       public static Type[] GetAllTypesThatIsAssignableFromTypes<T>(bool ignoreClasses, bool ignoreInterfaces, params Type[] typesToLoadAssembly) where T : class
        {
            try
            {
                System.Collections.Generic.IEnumerable<Type> types;
                var assemblies = new System.Collections.Generic.List<Assembly>();
                assemblies.Add(Assembly.GetExecutingAssembly());
                assemblies.Add(Assembly.GetEntryAssembly());
                assemblies.Add(Assembly.GetCallingAssembly());
                assemblies.Add(Assembly.GetAssembly(typeof(T)));
                typesToLoadAssembly.ToList().ForEach(t =>
                {
                    assemblies.Add(Assembly.GetAssembly(t));
                });

                types = from ass in assemblies.Distinct()
                        from t in ass.GetTypes()
                        where typeof(T).IsAssignableFrom(t) && t.FullName != typeof(T).FullName
                        select t;
                if (ignoreClasses)
                    types = types.Where(w => !w.IsClass);
                if (ignoreInterfaces)
                    types = types.Where(w => !w.IsInterface);

                return types.ToArray();
            }
            catch (Exception exception)
            {
                throw exception.Failin();
            }
        }

    }
}