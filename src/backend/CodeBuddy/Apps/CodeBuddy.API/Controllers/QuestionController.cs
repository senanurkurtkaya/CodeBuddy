using CodeBuddy.API.Controllers.Base;

using Microsoft.AspNetCore.Mvc;


namespace CodeBuddy.API.Controllers
{
    public class QuestionController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Feed()
        {
            return Ok();
        }
    }
}
