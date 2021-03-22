namespace LendingPlatform.Interfaces {
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using LendingPlatform.Data.Entities;

    /// <summary>
    /// Interface for an AppContext.
    /// </summary>
    public interface IContext {
        DbSet<Project> Projects { get; set; }

        DbSet<Investor> Investors { get; set; }

        Task<int> SaveChangesAsync();

        Task AddRangeAsync(params object[] entities);
    }
}
