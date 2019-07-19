/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.AggregateModels.StoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IHeartFiction.Infrastructure.Configurations.StoryConfigurations
{
    public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .Ignore(p => p.DomainEvents);

            builder
                .Property(p => new { p.StoryId, p.Id });

            builder
                .HasOne<Story>()
                .WithMany(p => p.Comments)
                .HasForeignKey(p => p.StoryId);

            builder
                .Property(p => p.Created)
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Content)
                .IsRequired();

            builder
                .Property(p => p.Modified)
                .IsRequired(false);

            builder
                .Property(p => p.Author)
                .IsRequired(false);

            builder
                .HasOne(p => p.Author)
                .WithMany();
        }
    }
}
