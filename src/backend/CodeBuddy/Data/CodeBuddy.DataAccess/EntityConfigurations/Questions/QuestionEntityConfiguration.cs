using CodeBuddy.DataAccess.EntityConfigurations.Base;
using CodeBuddy.Domains.Models.Questions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeBuddy.DataAccess.EntityConfigurations.Questions
{
    internal class QuestionEntityConfiguration : BaseEntityConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);
        }
    }
}
