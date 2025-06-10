using CodeBuddy.Business.CQRS.Questions.DTOs;
using CodeBuddy.DataAccess.Repositories;
using CodeBuddy.Domains.Models.Questions;

using FluentValidation;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddy.Business.CQRS.Questions.Commands
{
    public class CreateQuestionCommand : IRequest<CreateQuestionResponseDTO>
    {
        public required string Title { get; set; }

        public required string Content { get; set; }

        public List<int>? TagIds { get; set; }
    }

    internal class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.TagIds).NotEmpty().When(x => x.TagIds != null);
        }
    }

    internal class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreateQuestionResponseDTO>
    {
        private readonly IBaseRepository<Question> _questionsRepository;

        public CreateQuestionCommandHandler(IBaseRepository<Question> questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task<CreateQuestionResponseDTO> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question(request.Title, request.Content);

            await _questionsRepository.AddAsync(question, cancellationToken, saveChanges: true);



            return new CreateQuestionResponseDTO
            {
                Id = question.Id
            };
        }
    }
}
