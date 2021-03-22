using System.Threading.Tasks;
using LendingPlatform.Data.Entities;
using LendingPlatform.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LendingPlatform.Internal {

    /// <summary>
    /// Specfic implementation of the IContext.
    /// </summary>
    public class LendingPlatformContext : DbContext, IContext
    {
        public LendingPlatformContext(
            DbContextOptions<LendingPlatformContext> options) : base(options) {}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Investor> Investors { get; set; }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
    }
}