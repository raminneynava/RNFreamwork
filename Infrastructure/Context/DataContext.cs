using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Entities;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq.Expressions;
using Infrastructure.Entities.Eshop;

namespace Infrastructure.Context
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {

        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
       // public DbSet<DiscountProduct> DiscountProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            var entitiesAssembly = typeof(IEntity).Assembly;
            modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            modelBuilder.GlobalIsDeleteFilter<IEntity>();
            modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.AddPluralizingTableNameConvention();
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                 p.State == EntityState.Added ||
                 p.State == EntityState.Deleted
            );
            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());

                var IsDeleted = entityType.FindProperty("IsDeleted");

                if (item.State == EntityState.Deleted && IsDeleted != null)
                {
                    item.Property("IsRemoved").CurrentValue = true;
                    item.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                 p.State == EntityState.Added ||
                 p.State == EntityState.Deleted
            );

            foreach (var item in modifiedEntries)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entityType != null)
                {
                    var IsDeleted = entityType.FindProperty("IsDeleted");

                    if (item.State == EntityState.Deleted && IsDeleted != null)
                    {
                        item.Property("IsDeleted").CurrentValue = true;
                        item.State = EntityState.Modified;
                    }
                }
            }
            return (await base.SaveChangesAsync());
        }

    }
}
