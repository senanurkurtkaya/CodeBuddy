using CodeBuddy.Domains.Models.Base;
using CodeBuddy.Domains.Models.Tags;
using CodeBuddy.Infrastructure.Shared.Enums;

namespace CodeBuddy.Domains.Models.Questions
{
    public class Question : BaseEntity
    {
        private readonly List<Tag> _tags = new List<Tag>();

        public Question() : base()
        {
            Status = QuestionStatus.Created;
        }

        public Question(string title, string content, QuestionStatus status)
        {
            Title = title;
            Content = content;
            Status = status;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public QuestionStatus Status { get; private set; }

        public DateTime? CompletedAt { get; private set; }

        public IReadOnlyList<Tag> Tags => _tags;
    }
}
