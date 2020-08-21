using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DocumentQuicker.DataProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace DocumentQuicker.DataProvider
{
    public class DocumentQuickerContext : DbContext
    {
        public DbSet<BankInfoEf> BankInfos { get; set; }

        public DocumentQuickerContext (DbContextOptions<DocumentQuickerContext> options) : base(options) { }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is IBaseEntity);

            foreach (var entry in entries)
            {
                var now = DateTime.Now;
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((IBaseEntity)entry.Entity).CreationDate = now;
                        ((IBaseEntity)entry.Entity).EditDate = now;
                        ((IBaseEntity)entry.Entity).IsActive = true;
                        break;
                    case EntityState.Modified:
                        ((IBaseEntity)entry.Entity).EditDate = now;
                        break;
                    //soft delete. we change only flag and edit date. and change EntityState from Deleted to Modified
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        ((IBaseEntity)entry.Entity).IsActive = false;
                        ((IBaseEntity)entry.Entity).EditDate = now;
                        break;
                }
            }
            
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, 
                                                   CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is IBaseEntity);

            foreach (var entry in entries)
            {
                var now = DateTime.Now;
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((IBaseEntity)entry.Entity).CreationDate = now;
                        ((IBaseEntity)entry.Entity).EditDate = now;
                        ((IBaseEntity)entry.Entity).IsActive = true;
                        break;
                    case EntityState.Modified:
                        ((IBaseEntity)entry.Entity).EditDate = now;
                        break;
                    //soft delete. we change only flag and edit date. and change EntityState from Deleted to Modified
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        ((IBaseEntity)entry.Entity).IsActive = false;
                        ((IBaseEntity)entry.Entity).EditDate = now;
                        break;
                }
            }
            
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}