namespace LendingPlattform.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    using LendingPlatform.Controllers;
    using LendingPlatform.Internal;
    using LendingPlatform.Helper;
    using LendingPlatform.Data.Models;

    /// <summary>
    /// This constroller is currently just for creating a few
    /// projects and investors with fixed ids.
    /// </summary>
    /// <remarks>The context should be an IContext but I could not resolve with
    /// the DI.
    /// </remarks>
    [Route("api/test")]
    public class TestController : ApiController
    {
        public TestController(LendingPlatformContext context) : base(context) { }

        [HttpPost, Route("create-projects")]
        public async Task<IActionResult> PostCreateProjectsAsync()
        {
            var listOfProjects = TestHelper.CreateTestProjects();
            if (Context.Projects.Any(p => listOfProjects.Contains(p)))
            {
                return Conflict("At least one project exists already!");
            }

            await Context.Projects.AddRangeAsync(listOfProjects);
            await Context.SaveChangesAsync();
            return Ok(listOfProjects.Select(ProjectViewModel.GetFrom));
        }

        [HttpPost, Route("create-investors")]
        public async Task<IActionResult> PostCreateInvestorsAsync() {

            var listOfInvestors = TestHelper.CreateTestInvestors();
            if (Context.Investors.Any(i => listOfInvestors.Contains(i))) {
                return Conflict("At least one investor exists already!");
            }

            await Context.AddRangeAsync(listOfInvestors);
            await Context.SaveChangesAsync();
            return Ok(listOfInvestors.Select(InvestorViewModel.GetFrom));
        }
    }
}