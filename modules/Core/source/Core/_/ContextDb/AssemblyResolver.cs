using System.Reflection;

namespace Core
{
    public interface IAssemblyResolver
    {
        Assembly Get<T>();
    }

    public class AssemblyResolver : IAssemblyResolver
    {
        public Assembly Get<T>()
        {
            return Assembly.GetAssembly(typeof(T));
        }
    }
}