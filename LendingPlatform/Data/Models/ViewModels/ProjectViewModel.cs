namespace LendingPlatform.Data.Models {
    using System;
    using LendingPlatform.Data.Entities;
    using LendingPlatform.Interfaces;

    public class ProjectViewModel : IModel {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int TargetFunding { get; init; }
        public int CurrentFunding { get; init; }
        public bool IsFunded { get; init; }
        public DateTime TargetDate { get; init; }

        public static ProjectViewModel GetFrom(Project entity) =>
            new ProjectViewModel {
                Id = entity.Id,
                Name = entity.Name,
                IsFunded = entity.IsFunded,
                CurrentFunding = entity.CurrentFunding,
                TargetFunding = entity.TargetFunding,
                TargetDate = entity.TargetDate,
            };
    }
}
