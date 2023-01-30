
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServicesExtensions
    {
        public static void AddSelfBindableInterfacesBindings(this IServiceCollection services, params Type[] typesToLoadAssembly)
        {
            var types = TypeExtensions.GetAllTypesThatIsAssignableFromTypes<ISelfBindable>(false, true, typesToLoadAssembly);
            foreach (var type in types)
            {
                var serviceInterface = type.GetInterfaces().Where(w =>
                    w.Name != nameof(ISelfBindable) &&
                    w.Name != nameof(IDisposable)
                    );
                foreach (var i in serviceInterface)
                {
                    services.AddTransient(i, type);
                }
            }
        }
    
    }
}