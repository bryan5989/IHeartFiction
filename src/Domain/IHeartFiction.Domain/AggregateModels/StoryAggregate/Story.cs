/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.Events;
using IHeartFiction.Domain.Exceptions;
using IHeartFiction.Domain.Models;
using IHeartFiction.Domain.SeedWork;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace IHeartFiction.Domain.AggregateModels.StoryAggregate
{
    public class Story : Entity, IAggregateRoot
    {
        private readonly List<Comment> _comments;
        private readonly List<Chapter> _chapters;
        private readonly List<Author> _authors;

        public string Title { get; private set; }

        public IReadOnlyCollection<Author> Authors => _authors;
        public IReadOnlyCollection<Chapter> Chapters => _chapters;
        public IReadOnlyCollection<Comment> Comments => _comments;

        public Story(string title, params Author[] authors)
        {
            Contract.Requires(!string.IsNullOrEmpty(title));
            Contract.Requires(authors.Length >= 1);

            this.Title = title;

            _authors = authors.ToList();
            _chapters = new List<Chapter>();
            _comments = new List<Comment>();

            AddDomainEvent(new StoryCreated(title, authors));
        }

        public void AddComment(Author author, string content)
        {
            Contract.Requires(author != null);
            Contract.Requires(!string.IsNullOrEmpty(content));

            var comment = new Comment(author, content);

            _comments.Add(comment);

            AddDomainEvent(new CommentAdded(this.Id, content));
        }

        public void RemoveComment(int id)
        {
            Contract.Requires<CommentDoesNotExist>(_comments.Count(p => p.Id == id) != 0);

            var comment = _comments.Find(p => p.Id == id);
            _comments.Remove(comment);

            AddDomainEvent(new CommentRemoved(this.Id, id));
        }

        public Paginated<Comment> GetComments(int page, int perPage=5)
        {
            Contract.Requires(page >= 0);
            Contract.Requires(perPage >= 1);

            int totalPages = _comments.Count / perPage;
            ICollection<Comment> comments = _comments
                .OrderBy(p => p.Created)
                .Skip(page * perPage)
                .Take(perPage)
                .ToList();

            return new Paginated<Comment>(page, totalPages, perPage, comments);
        }

        public void AddChapter(string title, string htmlContent, int? chapterNumber = null)
        {
            
        }

        public void RemoveChapter(int id)
        {
            Contract.Requires<ChapterDoesNotExist>(_chapters.Count(p => p.Id == id) != 0);

            var chapter = _chapters.Find(p => p.Id == id);
            _chapters.Remove(chapter);

            AddDomainEvent(new ChapterRemoved(this.Id, id));
        }
    }
}
