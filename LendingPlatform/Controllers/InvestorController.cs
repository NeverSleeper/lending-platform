using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using LendingPlatform.Internal;
using LendingPlatform.Data.Models;

namespace LendingPlatform.Controllers
{
    /// <summary>
    /// This controller provides an endpoint to provide a singular investor.
    /// </summary>
    /// <remarks>The context should be an IContext but I could not resolve with
    /// the DI.
    /// </remarks>
    [Route("api/investors")]
    public class InvestorController : ApiController
    {
        public InvestorController(LendingPlatformContext context)
            : base(context) { }

        [Route("{id:guid}")]
        public async Task<IActionResult> GetUserInfo(Guid id)
        {
            var investor = await Context.Investors
                .AsNoTracking()
                .Include(i => i.Fundings)
                .ThenInclude(f => f.Project)
                .SingleOrDefaultAsync(i => i.Id == id);

            if (investor == null)
            {
                return NotFound($"Investor not found with id: {id}");
            }
            return Ok(InvestorViewModel.GetFrom(investor));
        }
    }
}

