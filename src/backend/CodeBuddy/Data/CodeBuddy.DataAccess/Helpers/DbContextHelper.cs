﻿using CodeBuddy.DataAccess.Context;

using Microsoft.EntityFrameworkCore;

namespace CodeBuddy.DataAccess.Helpers
{
    public interface IDbContextHelper
    {
        public Task EnsureCreated(CancellationToken cancellationToken);

        public Task EnsureDeleted(CancellationToken cancellationToken);

        public Task Migrate(CancellationToken cancellationToken);
    }

    internal class DbContextHelper : IDbContextHelper
    {
        private readonly CodeBuddyDbContext _context;

        public DbContextHelper(CodeBuddyDbContext context)
        {
            _context = context;
        }

        public async Task EnsureCreated(CancellationToken cancellationToken)
        {
            await _context.Database.EnsureCreatedAsync(cancellationToken);
        }

        public async Task EnsureDeleted(CancellationToken cancellationToken)
        {
            await _context.Database.EnsureDeletedAsync(cancellationToken);
        }

        public async Task Migrate(CancellationToken cancellationToken)
        {
            await _context.Database.MigrateAsync(cancellationToken);
        }
    }
}
