namespace LendingPlatform.Data.Models{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LendingPlatform.Data.Entities;
    using LendingPlatform.Interfaces;

    /// <summary>
    /// A view model for an investor
    /// </summary>
    public class InvestorViewModel : IModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public ICollection<FundingViewModel> Fundings { get; init; } = default!;

        /// <summary>
        /// Conversion of an entity to an view model.
        /// </summary>
        /// <param name="entity">The investor entity.</param>
        /// <returns>The converted investor view model.</returns>
        public static InvestorViewModel GetFrom(Investor entity) =>
           new InvestorViewModel {
                Id = entity.Id,
                Name = entity.Name,
                Fundings = entity.Fundings
                    .Select(FundingViewModel.GetFrom)
                    .ToList()
           };
    }
}
