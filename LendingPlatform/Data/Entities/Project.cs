namespace LendingPlatform.Data.Entities {
    using System;
    using System.ComponentModel.DataAnnotations;
    using LendingPlatform.Interfaces;


    /// <summary>
    /// Simple POCO for a project which can be funded.
    /// </summary>
    public class Project : IEntity {
        [Key]
        public Guid Id { get; init; }

        [Required]
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        [Required]
        public int TargetFunding { get; init; } = default!;

        public int CurrentFunding { get; set; }

        public bool IsFunded { get; set; } = false;

        [Required]
        public DateTime TargetDate { get; set; }
    }
}