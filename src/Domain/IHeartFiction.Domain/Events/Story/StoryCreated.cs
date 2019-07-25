/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.AggregateModels.StoryAggregate;
using MediatR;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace IHeartFiction.Domain.Events.Story
{
    public class StoryCreated : INotification
    {
        private readonly List<Author> _authors;

        public string Title { get; }
        public IReadOnlyCollection<Author> Authors => _authors;

        public StoryCreated(string title, params Author[] authors)
        {
            Contract.Requires(!string.IsNullOrEmpty(title));
            Contract.Requires(authors.Length >= 1);

            Title = title;
            _authors = authors.ToList();
        }
    }
}
