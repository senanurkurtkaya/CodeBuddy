using CodeBuddy.DataAccess.Helpers;

using Microsoft.AspNetCore.Mvc;

namespace CodeBuddy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevelopmentController : ControllerBase
    {
        private readonly IDbContextHelper _dbContextHelper;

        public DevelopmentController(IDbContextHelper dbContextHelper)
        {
            _dbContextHelper = dbContextHelper;
        }

        [HttpPost("EnsureDatabaseCreated")]
        public async Task<IActionResult> EnsureDatabaseCreated(CancellationToken cancellation)
        {
            await _dbContextHelper.EnsureCreated(cancellation);

            return Ok();
        }

        [HttpPost("EnsureDatabaseDeleted")]
        public async Task<IActionResult> EnsureDatabaseDeleted(CancellationToken cancellation)
        {
            await _dbContextHelper.EnsureDeleted(cancellation);

            return Ok();
        }
    }
}
