/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.SeedWork;

namespace IHeartFiction.Domain.AggregateModels.StoryAggregate
{
    /// <summary>
    ///     Relates to the name of an author in the context of a <see cref="Story">story</see>.
    ///     Not the final resting place of an author.
    /// </summary>
    public class Author : Entity
    {
        /// <summary>
        ///     The name of the author.
        /// </summary>
        public string Name { get; set; }
    }
}
