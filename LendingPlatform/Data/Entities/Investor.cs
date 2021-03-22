namespace LendingPlatform.Data.Entities{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using LendingPlatform.Interfaces;

    /// <summary>
    /// Simple POCO for an investor.
    /// </summary>
    public class Investor : IEntity {
        [Key]
        public Guid Id { get; init; }

        public string Name { get; set; } = default!;

        public ICollection<Funding> Fundings { get; set; }
    }
}