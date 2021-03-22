namespace LendingPlatform.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;

    using LendingPlatform.Internal;
    using LendingPlatform.Data.Entities;
    using LendingPlatform.Data.Models;

    /// <summary>
    /// Project controller, which can provide all or a single project by id.
    /// </summary>
    /// <remarks>The context should be an IContext but I could not resolve with
    /// the DI.
    /// </remarks>
    [Route("api/projects")]
    public class ProjectController : ApiController {
        public ProjectController(LendingPlatformContext context) :
            base(context) { }

        /// <summary>
        /// Provide all projects as a view model.
        /// </summary>
        /// <remarks>The current assumption is that
        /// there is no login necessary to see the projects.</remarks>
        /// <returns>A list of project view models.</returns>
        [HttpGet, Route(""), AllowAnonymous]
        public async Task<IActionResult> GetProjectsAsync() =>
            Ok(await Context.Projects
                .AsNoTracking()
                .Select(p => ProjectViewModel.GetFrom(p))
                .ToListAsync());


        /// <summary>
        /// Show one specific project in detail
        /// </summary>
        /// <param name="id">Id of the project</param>
        /// <returns>A single project view model</returns>
        [HttpGet, Route("{id:guid}")]
        public async Task<IActionResult> GetProjectAsync(Guid id) {
            var project = (await Context.Projects
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id));

            if (project == null) {
                return NotFound("Project not found!");
            }
            return Ok(ProjectViewModel.GetFrom(project));
        }

        /// <summary>
        /// Action to fund a specific project.
        /// This method also checks for the existance of the project or
        /// investor and validates specifig submission restrictions.
        /// </summary>
        /// <remarks>Usually the controller would just only call a specific
        /// service or command to do the work.
        /// This is only for the PCO.</remarks>
        /// <param name="id">project id</param>
        /// <param name="model">binding model</param>
        /// <returns>The updated project view model.</returns>
        [HttpPost, Route("{id:guid}/fund")]
        public async Task<IActionResult> PostCreateTransactionAsync(
            Guid id, [FromBody] FundingBindingModel model){
            if (!ModelIsValid(model)) {
                return BadRequest("BindingModel is not valid!");
            }

            // The minimum and maximum values should be stored in a config-file
            if (!(model.Amount >= 100 && model.Amount <= 10000))
            {
                return BadRequest("Submission amount is to low or to high!");
            }

            var project = Context.Projects
                .SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound("Project not found");
            }

            if (project.IsFunded)
            {
                return Conflict("Project is already completely funded!");
            }

            if (DateTime.UtcNow > project.TargetDate)
            {
                return Conflict("Time for funding exceeded!");
            }


            // Usually the UserManager would take care of the current User and
            // the binding model would not contain the UserId
            // to get the current User         
            var investor = Context.Investors
                .Include(i => i.Fundings)
                .SingleOrDefault(i => i.Id == model.InvestorId);

            if (investor == null) {
                return NotFound(
                    $"Investor not found with id: {model.InvestorId}");
            }
            if (investor.Fundings.Any(t => t.Project.Id == project.Id))
            {
                return Conflict(
                    $"Already backed the project with id: {project.Id}");
            }

            project.CurrentFunding += model.Amount;
            if (project.CurrentFunding >= project.TargetFunding)
            {
                project.IsFunded = true;
            }

            investor.Fundings.Add(new Funding
            {
                Investor = investor,
                Project = project,
                Amount = model.Amount,
                CreationDate = DateTime.UtcNow
            });

            await Context.SaveChangesAsync();
            return Ok(ProjectViewModel.GetFrom(project));
        }
    }
}
