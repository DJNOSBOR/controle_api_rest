using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Core
{
    public abstract class BaseDbContext<T> : DbContext where T : DbContext
    {
        private Assembly assembly;

        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions<T> options, Assembly assembly)
          : base(options)
        {
            this.assembly = assembly;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                if (assembly != null)
                    modelBuilder.ApplyConfigurationsFromAssembly(assembly);

                base.OnModelCreating(modelBuilder);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}