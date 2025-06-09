using CodeBuddy.Domains.Models.Questions;

using Microsoft.EntityFrameworkCore;

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CodeBuddy.Business.Seed")]
namespace CodeBuddy.DataAccess.Context
{
    internal class CodeBuddyDbContext : DbContext
    {
        public CodeBuddyDbContext(DbContextOptions<CodeBuddyDbContext> options)
            : base(options)
        {
            Database.AutoTransactionBehavior = AutoTransactionBehavior.WhenNeeded;
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public int TenantId { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties(typeof(decimal)).HavePrecision(18, 2);
            configurationBuilder.Properties(typeof(string)).HaveMaxLength(4000);

            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodeBuddyDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
