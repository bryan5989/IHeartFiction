/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.Events.Story;
using IHeartFiction.Domain.SeedWork;

namespace IHeartFiction.Domain.AggregateModels.StoryAggregate
{
    /// <summary>
    ///     A unit of content within a <see cref="Story">story</see>.
    /// </summary>
    public class Chapter : Entity
    {
        /// <summary>
        ///     The unique identifier of the <see cref="Story">story</see> that the chapter belongs to.
        /// </summary>
        public int StoryId { get; }

        /// <summary>
        ///     Chapter number is a unique number to order the chapters.
        ///     This is NOT the primary key of this entity. If not set,
        ///     no organization can be applied by a chapter number.
        /// </summary>
        public int? ChapterNumber { get; private set; }

        /// <summary>
        ///     The title of the chapter.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        ///     The actul content of the chapter.
        /// </summary>
        public string HtmlContent { get; private set; }

        public Chapter(int storyId, string title, string htmlContent, int? chapterNumber = null)
        {
            StoryId = storyId;
            HtmlContent = htmlContent;
            Title = title;
            ChapterNumber = chapterNumber;
        }

        public Chapter UpdateTitle(string title)
        {
            if (Title != title)
            {
                Title = title;
                AddDomainEvent(new ChapterTitleModified(StoryId, Id, title));
            }

            return this;
        }

        public Chapter UpdateContent(string htmlContent)
        {
            if(HtmlContent != htmlContent)
            {
                HtmlContent = htmlContent;
                AddDomainEvent(new ChapterTitleModified(StoryId, Id, htmlContent));
            }

            return this;
        }
    }
}
