namespace LendingPlatform.Helper
{
    using System;
    using System.Collections.Generic;
    using LendingPlatform.Data.Entities;

    /// <summary>
    /// This abstract class is providing functions for creating projects
    /// and investors. 
    /// </summary>
    public abstract class TestHelper
    {
        /// <summary>
        /// Creates three projects with predefined ids.
        /// </summary>
        /// <remarks>This is intented for testing purposes.</remarks> 
        /// <returns>List of projects.</returns>
        public static IEnumerable<Project> CreateTestProjects() =>
            new List<Project>() {
                new Project {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000101"),
                    Name = "Project ",
                    TargetFunding = 5555,
                    CurrentFunding = 500,
                    TargetDate = new DateTime(2022, 12, 22),
                    Description = "It is project A."
                },
                new Project {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000102"),
                    Name = "Project B",
                    TargetFunding = 1000000,
                    CurrentFunding = 6000,
                    TargetDate = new DateTime(2020, 9, 9),
                    Description = "It is project B."
                },
                new Project {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000103"),
                    Name = "Project C",
                    TargetFunding = 6000000,
                    CurrentFunding = 6000000,
                    TargetDate = new DateTime(2023, 10, 1),
                    Description = "It is project C.",
                    IsFunded = true,
                },
            };

        /// <summary>
        /// Creates two investors with predefined ids.
        /// </summary>
        /// <remarks>This is intented for testing purposes.</remarks> 
        /// <returns>A list of investors.</returns>
        public static IEnumerable<Investor> CreateTestInvestors() =>
            new List<Investor> {
                new Investor
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "John Doe",
                    Fundings = new List<Funding>()
                },
                new Investor
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Jane Doe",
                    Fundings = new List<Funding>()
                },
        };
    }
}