namespace LendingPlatform.Data.Models
{
    using System;
    using LendingPlatform.Data.Entities;
    using LendingPlatform.Interfaces;

    /// <summary>
    /// A view model for a funding of a project created by an investor.
    /// </summary>
    public class FundingViewModel : IModel
    {
        public Guid Id { get; init; }
        public Guid InvestorId { get; init; }
        public Guid ProjectId { get; init; }
        public int Amount { get; init; }
        public DateTime CreationDate { get; init; }

        /// <summary>
        /// Conversion of an entity to an view model.
        /// </summary>
        /// <param name="entity">The funding entity.</param>
        /// <returns>The converted funding view model.</returns>
        public static FundingViewModel GetFrom(Funding entity) =>
            new FundingViewModel
            {
                Id = entity.Id,
                CreationDate = entity.CreationDate,
                InvestorId = entity.Investor.Id,
                ProjectId = entity.Project.Id,
                Amount = entity.Amount,
            };
    }
}
