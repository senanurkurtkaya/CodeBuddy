using Microsoft.EntityFrameworkCore;

namespace CodeBuddy.DataAccess.Context
{
    internal class CodeBuddyDbContextFactory : IDbContextFactory<CodeBuddyDbContext>
    {
        private const int DefaultTenantId = -1;
        private readonly IDbContextFactory<CodeBuddyDbContext> _pooledFactory;

        public CodeBuddyDbContextFactory(
            IDbContextFactory<CodeBuddyDbContext> pooledFactory)
        {
            _pooledFactory = pooledFactory;
        }

        public CodeBuddyDbContext CreateDbContext()
        {
            var context = _pooledFactory.CreateDbContext();
            // TODO: Implement this if there is an upcoming identity server implementation with tenant/organization management
            context.TenantId = DefaultTenantId;
            return context;
        }
    }
}
