/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.Events;
using IHeartFiction.Domain.SeedWork;
using System;

namespace IHeartFiction.Domain.AggregateModels.StoryAggregate
{
    public class Comment : Entity
    {
        public int StoryId { get; set; }

        public Author Author { get; }
        public DateTime Modified { get; private set; }

        public string Content { get; private set;  }

        public Comment(Author author, string content)
        {
            this.Author = author;
            this.Content = content;
        }

        public void Modify(string content)
        {
            this.Modified = DateTime.Now;
            this.Content = content;

            this.AddDomainEvent(new CommentModified(this.StoryId, this.Id, this.Content));
        }
    }
}
