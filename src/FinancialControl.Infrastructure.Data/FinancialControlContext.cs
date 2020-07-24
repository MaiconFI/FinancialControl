using FinancialControl.Domain.Base;
using FinancialControl.Domain.Events;
using FinancialControl.Domain.Models.Expensies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialControl.Infrastructure.Data
{
    public class FinancialControlContext : DbContext, IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public FinancialControlContext(DbContextOptions options, IConfiguration configuration, IMediator mediator)
            : base(options)
        {
            _configuration = configuration;
            _mediator = mediator;
            Database.SetCommandTimeout(TimeSpan.FromSeconds(180));
        }

        public DbSet<Expense> Expensies { get; set; }

        public bool AllMigrationsApplied()
        {
            var idsDasMigrationJaExecutadas = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var idsDeTodasAsMigrations = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !idsDeTodasAsMigrations.Except(idsDasMigrationJaExecutadas).Any();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEvents = GetDomainEvents().ToList();

            var result = await base.SaveChangesAsync(cancellationToken);
            if (result == default) return result;

            await DispatchDomainEventsAsync(domainEvents);

            return result;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString(GetType().Name));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DomainEvent>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancialControlContext).Assembly);
            base.OnModelCreating(modelBuilder);

            ChangeDecimalDecimalWithPrecision(modelBuilder);
        }

        private static void ChangeDecimalDecimalWithPrecision(ModelBuilder modelBuilder)
        {
            var dateProps = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.PropertyInfo?.PropertyType == typeof(decimal) || x.PropertyInfo?.PropertyType == typeof(decimal?))
                .ToList();

            foreach (var prop in dateProps) prop.SetColumnType("decimal(18, 6)");
        }

        private void ClearDomainEvents()
        {
            GetDomainEntities().ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }

        private async Task DispatchDomainEventsAsync(IEnumerable<DomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
                await _mediator.Publish(domainEvent);

            ClearDomainEvents();
        }

        private IEnumerable<EntityEntry<Entity>> GetDomainEntities()
        {
            return ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
        }

        private IEnumerable<DomainEvent> GetDomainEvents()
        {
            var domainEntities = GetDomainEntities();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents);
        }
    }
}