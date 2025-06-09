using CodeBuddy.DataAccess.EntityConfigurations.Base;
using CodeBuddy.Domains.Models.Tags;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeBuddy.DataAccess.EntityConfigurations.Tags
{
    internal class TagEntityConfiguration : BaseEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);
        }
    }
}
