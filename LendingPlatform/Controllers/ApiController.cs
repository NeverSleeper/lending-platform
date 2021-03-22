namespace LendingPlatform.Controllers
{
    using LendingPlatform.Internal;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Basement for custom controllers which is providing a context and
    /// a model validation function.
    /// </summary>
    /// <remarks>The context should be an IContext but I could not resolve with
    /// the DI.
    /// </remarks>
    public abstract class ApiController : Controller{

        protected LendingPlatformContext Context { get;}

        public ApiController(LendingPlatformContext context) =>
            Context = context;

        public bool ModelIsValid(object model) =>
            model != null && ModelState.IsValid;
    }
}
