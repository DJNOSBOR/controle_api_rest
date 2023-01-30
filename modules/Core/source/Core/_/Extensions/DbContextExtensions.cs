using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Core
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Buscar os valores das chaves primárias de uma entidade
        /// </summary>
        /// <param name="context"></param>
        /// <param name="obj"></param>
        /// <returns>Array de objetos</returns>
        public static object[] GetPrimaryKeyValues(this DbContext context, object obj)
        {
            try
            {
                return context.Model.GetEntityTypes().First(w => w.Name == obj.GetType().FullName).FindPrimaryKey().Properties.Select(s => obj.GetType().GetProperty(s.Name).GetValue(obj)).ToArray();
            }
            catch (Exception exception)
            {
                throw;//TODO
                //throw  exception.Failin("Não foi possível obter os valores das chaves primárias");
            }
        }

        ///// <summary>
        ///// Adicionar um novo registro da entidade, ou atualizar caso já exista
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="context"></param>
        ///// <param name="obj"></param>
        public static void AddOrUpdate<T>(this DbSet<T> dbSet, T data) where T : class
        {
            try
            {
                var context = dbSet.GetContext();
                var keys = context.GetPrimaryKeyValues(data);

                //Obter se a entidade no DB (se existir)
                var check = dbSet.Find(keys.ToArray());

                //Se não existir, adiciona
                if (check == null)
                {
                    context.Add(data);
                }
                else //Se existir, desanexa o objeto consultado do contexto (q foi utilizado para consulta), e então atualiza com o objeto que veio neste método
                {
                    context.Entry(data).State = EntityState.Detached;
                    SetAttachedEntityValues(check, data, new[] { nameof(BaseEntity.DateInsert), nameof(BaseEntity.DateModified) });
                    context.Entry(check).State = EntityState.Modified;
                    context.Update(check);
                }
            }
            catch (Exception exception)
            {
                throw;//TODO
                //throw exception.Failin();
            }
        }

        ///// <summary>
        ///// Adicionar um novo registro da entidade, ou atualizar caso já exista
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="context"></param>
        ///// <param name="obj"></param>
        public static async Task AddOrUpdateAsync<T>(this DbSet<T> dbSet, T data) where T : class
        {
            try
            {
                var context = dbSet.GetContext();
                var keys = context.GetPrimaryKeyValues(data);

                //Obter se a entidade no DB (se existir)
                var check = await dbSet.FindAsync(keys.ToArray());

                //Se não existir, adiciona
                if (check == null)
                {
                    await context.AddAsync(data);
                }
                else //Se existir, desanexa o objeto consultado do contexto (q foi utilizado para consulta), e então atualiza com o objeto que veio neste método
                {
                    context.Entry(data).State = EntityState.Detached;
                    //context.Entry(check).CurrentValues.SetValues(data);
                    SetAttachedEntityValues(check, data, new[] { nameof(BaseEntity.DateInsert), nameof(BaseEntity.DateModified) });
                    context.Entry(check).State = EntityState.Modified;
                    context.Update(check);
                }
            }
            catch (Exception exception)
            {
                throw;//TODO
                //throw exception.Failin();
            }
        }

        private static void SetAttachedEntityValues<T>(T attachedEntity, T entity, string[] excludePropertyNames)
        {
            var properties = typeof(T).GetProperties().Where(x => !excludePropertyNames.Contains(x.Name)).ToList();

            foreach (var property in properties.Where(w => w.CanWrite))
            {
                var propertyValue = entity.GetType().GetProperty(property.Name).GetValue(entity);
                attachedEntity.GetType().GetProperty(property.Name).SetValue(attachedEntity, propertyValue);
            }
        }

        public static DbContext GetContext<TEntity>(this DbSet<TEntity> dbSet)
            where TEntity : class
        {
            return (DbContext)dbSet
                .GetType().GetTypeInfo()
                .GetField("_context", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(dbSet);
        }
    }
}