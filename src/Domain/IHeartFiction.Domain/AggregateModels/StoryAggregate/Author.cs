/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using System.Collections.Generic;
using IHeartFiction.Domain.SeedWork;

namespace IHeartFiction.Domain.AggregateModels.StoryAggregate
{
    /// <summary>
    ///     Relates to the name of an author in the context of a <see cref="Story">story</see>.
    ///     Not the final resting place of an author.
    /// </summary>
    public class Author : ValueObject
    {
        /// <summary>
        ///     The name of the author.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     An author is just a name.
        /// </summary>
        /// <param name="name">
        ///     The name of the author.
        /// </param>
        public Author(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Comparison values to see if two author are equal.
        /// </summary>
        /// <returns>
        ///     The name of the author to comapre on.
        /// </returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }
    }
}
