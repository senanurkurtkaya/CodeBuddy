using CodeBuddy.DataAccess.Repositories;
using CodeBuddy.Domains.Models.Tags;
using CodeBuddy.Infrastructure.Shared.Exceptions;

using FluentValidation;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace CodeBuddy.Business.CQRS.Tags.Commands
{
    public class CreateTagCommand : IRequest
    {
        public string Name { get; set; }
    }

    internal class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
    {
        public CreateTagCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }

    internal class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
    {
        private readonly IBaseRepository<Tag> _baseRepository;

        public CreateTagCommandHandler(IBaseRepository<Tag> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var exists = await _baseRepository.GetAll().AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (exists)
            {
                throw new ConflictException(nameof(Tag), nameof(Tag.Name), request.Name);
            }

            var tag = new Tag(request.Name);

            await _baseRepository.AddAsync(tag, cancellationToken, saveChanges: true);
        }
    }
}
