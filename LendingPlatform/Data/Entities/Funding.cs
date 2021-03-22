namespace LendingPlatform.Data.Entities{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Interfaces;

    /// <summary>
    /// Simple POCO for a funding which can be created by an investor.
    /// </summary>
    public class Funding : IEntity {
        [Key]
        public Guid Id { get; init; }

        [Required]
        public Investor Investor { get; set; } = default!;

        [Required]
        public Project Project { get; set; } = default;

        [Required]
        public int Amount { get; init; }

        [Required]
        public DateTime CreationDate {get; init; }
    }
}