using CodeBuddy.Domains.Models.Base;
using CodeBuddy.Domains.Models.Questions;

namespace CodeBuddy.Domains.Models.Tags
{
    public class Tag : BaseEntity
    {
        private readonly List<Question> _questions = new List<Question>();

        public Tag(string name)
            : base()
        {
            Name = name;
        }

        public string Name { get; private set; }

        public IReadOnlyList<Question> Questions => _questions;
    }
}
