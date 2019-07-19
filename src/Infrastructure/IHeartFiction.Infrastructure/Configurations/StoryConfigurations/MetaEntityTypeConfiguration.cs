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
    public class MetaEntityTypeConfiguration : IEntityTypeConfiguration<Meta>
    {
        // TODO: Implement
        public void Configure(EntityTypeBuilder<Meta> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
