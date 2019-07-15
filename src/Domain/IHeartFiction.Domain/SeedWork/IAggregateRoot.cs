/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

namespace IHeartFiction.Domain.SeedWork
{
    /// <summary>
    ///     An aggregate root defines the business domain boundary.
    ///     This interface specifies if an object is the aggregate
    ///     root entity or not. All business transactions should go
    ///     through the aggregate root. This creates ease of
    ///     maintainability
    /// </summary>
    public interface IAggregateRoot { }
}
