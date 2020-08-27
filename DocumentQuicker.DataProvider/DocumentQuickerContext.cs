using System;
using System.Collections.Generic;
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
        public DbSet<AuditEf> DatabaseAudits { get; set; }
        public DbSet<RequisiteEf> Requisites { get; set; }
        public DbSet<AddressEf> Addresses { get; set; }
        public DbSet<BankDetailsEf> BankDetails { get; set; }

        public DocumentQuickerContext (DbContextOptions<DocumentQuickerContext> options) : base(options) { }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var audits = MarkTrackedEntriesAndPrepareForAudits();
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            FinalizeAudit(audits);
            return result;
        }

        private void FinalizeAudit(IList<AuditEf> preparedAudits)
        {
            if(!preparedAudits.Any())
                return;

            var completedAudits = new List<AuditEf>();

            foreach (var audit in preparedAudits)
            {
                if (audit.ItemId == Guid.Empty)
                {
                    var id = audit.PrimaryKeyHolder?.CurrentValue is Guid guid ? guid : default;
                    if(id == Guid.Empty)
                        continue;
                    audit.Id = id;
                    completedAudits.Add(audit);
                }
                else
                {
                    completedAudits.Add(audit);
                }
            }

            if (completedAudits.Any())
            {
                foreach (var audit in completedAudits)
                {
                    DatabaseAudits.AddAsync(audit);
                }
                
                base.SaveChangesAsync();
            }
        }

        private IList<AuditEf> MarkTrackedEntriesAndPrepareForAudits()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Detached && x.State != EntityState.Unchanged).ToList();

            var temporary = new List<AuditEf>();
            foreach (var entry in entries)
            {
                var entity = entry.Entity as IBaseEntity;
                if(entity == null)
                    continue;
                
                var now = DateTime.Now;
                var audit = new AuditEf()
                {
                    AuditDate = now,
                    Type = entity.Type,
                    PrimaryKeyHolder = entry.Properties?.FirstOrDefault(x => x.Metadata?.IsPrimaryKey() ?? false)
                };
                
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreationDate = now;
                        entity.EditDate = now;
                        entity.IsActive = true;
                        
                        audit.Action = AuditActionType.Create;
                        break;
                    case EntityState.Modified:
                        entity.EditDate = now;
                        
                        audit.Action = AuditActionType.Modify;
                        audit.ItemId = entity.Id;
                        break;
                    //soft delete. we change only flag and edit date. and change EntityState from Deleted to Modified
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entity.IsActive = false;
                        entity.EditDate = now;
                        
                        audit.Action = AuditActionType.Delete;
                        audit.ItemId = entity.Id;
                        break;
                }

                temporary.Add(audit);
            }

            return temporary;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, 
                                                         CancellationToken cancellationToken = new CancellationToken())
        {
            var audits = await MarkTrackedEntriesAndPrepareForAuditAsync();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await FinalizeAuditAsync(audits);
            return result;
        }

        private Task<IList<AuditEf>> MarkTrackedEntriesAndPrepareForAuditAsync()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Detached && x.State != EntityState.Unchanged).ToList();

            var temporary = new List<AuditEf>();
            foreach (var entry in entries)
            {
                var entity = entry.Entity as IBaseEntity;
                if(entity == null)
                    continue;
                
                var now = DateTime.Now;
                var audit = new AuditEf()
                {
                    AuditDate = now,
                    Type = entity.Type,
                    PrimaryKeyHolder = entry.Properties?.FirstOrDefault(x => x.Metadata?.IsPrimaryKey() ?? false)
                };
                
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreationDate = now;
                        entity.EditDate = now;
                        entity.IsActive = true;
                        
                        audit.Action = AuditActionType.Create;
                        break;
                    case EntityState.Modified:
                        entity.EditDate = now;
                        
                        audit.Action = AuditActionType.Modify;
                        audit.ItemId = entity.Id;
                        break;
                    //soft delete. we change only flag and edit date. and change EntityState from Deleted to Modified
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entity.IsActive = false;
                        entity.EditDate = now;
                        
                        audit.Action = AuditActionType.Delete;
                        audit.ItemId = entity.Id;
                        break;
                }

                temporary.Add(audit);
            }

            return Task.FromResult((IList<AuditEf>) temporary);
        }

        private async Task FinalizeAuditAsync(IList<AuditEf> preparedAudits)
        {
            if(!preparedAudits.Any())
                return;

            var completedAudits = new List<AuditEf>();

            foreach (var audit in preparedAudits)
            {
                if (audit.ItemId == Guid.Empty)
                {
                    var id = audit.PrimaryKeyHolder?.CurrentValue is Guid guid ? guid : default;
                    if(id == Guid.Empty)
                        continue;
                    audit.Id = id;
                    completedAudits.Add(audit);
                }
                else
                {
                    completedAudits.Add(audit);
                }
            }

            if (completedAudits.Any())
            {
                foreach (var audit in completedAudits)
                {
                    await DatabaseAudits.AddAsync(audit);
                }
                
                await base.SaveChangesAsync();
            }
        }
    }
}