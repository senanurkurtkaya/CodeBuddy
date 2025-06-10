using CodeBuddy.API.Controllers.Base;
using CodeBuddy.Business.CQRS.Questions.Commands;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CodeBuddy.API.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Feed()
        {
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateQuestionCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
