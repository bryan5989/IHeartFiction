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

namespace IHeartFiction.Infrastructure.Seeds.StorySeed
{
    public class ChapterSeed : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.HasData(
                new Chapter(1, "Chapter Title 1", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(1, "Chapter Title 2", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(1, "Chapter Title 3", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(1, "Chapter Title 4", "<b>Some awesome text</b><b>Some more awesome text</b>"));

            builder.HasData(
                new Chapter(2, "Chapter Title 1", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(2, "Chapter Title 2", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(2, "Chapter Title 3", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(2, "Chapter Title 4", "<b>Some awesome text</b><b>Some more awesome text</b>"));

            builder.HasData(
                new Chapter(3, "Chapter Title 1", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(3, "Chapter Title 2", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(3, "Chapter Title 3", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(3, "Chapter Title 4", "<b>Some awesome text</b><b>Some more awesome text</b>"));

            builder.HasData(
                new Chapter(4, "Chapter Title 1", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(4, "Chapter Title 2", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(4, "Chapter Title 3", "<b>Some awesome text</b><b>Some more awesome text</b>"),
                new Chapter(4, "Chapter Title 4", "<b>Some awesome text</b><b>Some more awesome text</b>"));
        }
    }
}
