using Controle.Data.Models;
using Controle.Services.EntityConfig;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Controle.Data.Context
{
    public class ControleDbContext: BaseDbContext<ControleDbContext>
    {
        public ControleDbContext(DbContextOptions<ControleDbContext> options, IAssemblyResolver assembly) : base(options, assembly.Get<ProdutoEntityConfig>())
        {
            System.Console.WriteLine($"Iniciando DbContext");
        }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Contas> Contas { get; set; }
        public DbSet<ContasCategorias> ContasCategorias { get; set; }
        public DbSet<ContasParcelas> ContasParcelas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TarefasItem> TarefasItens { get; set; }
        
        

        public override int SaveChanges()
        {
            handleInsertAndModifiedDates();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            handleInsertAndModifiedDates();
            return (await base.SaveChangesAsync(true, cancellationToken));
        }

        private void handleInsertAndModifiedDates()
        {
            var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is BaseEntity && (
                                e.State == EntityState.Added
                                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).SetModificationDate();

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).SetInsertDate();
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

    public abstract class BaseEntity
    {
        public DateTime DateInsert { get; private set; }
        public DateTime DateModified { get; private set; }
        public bool IsDeleted { get; private set; }

        public void Delete() => this.IsDeleted = true;

        public void UndoDelete() => this.IsDeleted = false;

        public void SetModificationDate() => this.DateModified = DateTime.Now;

        public void SetInsertDate()
        {
            if (this.DateInsert == default)
                this.DateInsert = DateTime.Now;
            else
                throw new Exception("Insert Data cannot be modified");
        }
    }
}
