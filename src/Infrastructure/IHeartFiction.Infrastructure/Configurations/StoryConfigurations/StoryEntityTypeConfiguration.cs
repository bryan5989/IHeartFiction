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

namespace IHeartFiction.Infrastructure.Configurations
{
    public class StoryEntityTypeConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.Ignore(p => p.DomainEvents);

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Title)
                .IsRequired(true);

            builder
                .Metadata
                .FindNavigation(nameof(Story.Authors))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .Metadata
                .FindNavigation(nameof(Story.Chapters))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder
                .Metadata
                .FindNavigation(nameof(Story.Comments))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
