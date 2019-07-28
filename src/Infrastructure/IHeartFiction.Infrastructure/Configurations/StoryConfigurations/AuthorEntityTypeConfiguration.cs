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
    /// <summary>
    ///     Configures the <see cref="Story">story</see> <see cref="Author">author</see> via
    ///     the <see cref="IEntityTypeConfiguration{TEntity}">entity type configuration.</see>
    /// </summary>
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        /// <summary>
        ///     Ensures that the database uses the <see cref="Author">author</see>'s name as primary key.
        /// </summary>
        /// <param name="builder">
        ///     Helps build the entity in terms of Entity Framework.
        /// </param>
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasKey(p => p.Name);
        }
    }
}
