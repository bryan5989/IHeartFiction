/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using IHeartFiction.Domain.SeedWork;

namespace IHeartFiction.Domain.Models
{
    public class Paginated<T> : ValueObject
    {
        private readonly List<T> _items;

        public int ItemsPerPage { get; }

        public int Page { get; }
        public int TotalPages { get; }

        public IReadOnlyCollection<T> Items => _items;

        public Paginated(int page, int totalPages, int itemsPerPage, ICollection<T> items)
        {
            Contract.Requires(page >= 0);
            Contract.Requires(totalPages >= 0);
            Contract.Requires(itemsPerPage >= 1);
            Contract.Requires(items.Count <= itemsPerPage);

            Page = page;
            TotalPages = totalPages;
            ItemsPerPage = itemsPerPage;

            _items = items.ToList();
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new System.NotImplementedException();
        }
    }
}
