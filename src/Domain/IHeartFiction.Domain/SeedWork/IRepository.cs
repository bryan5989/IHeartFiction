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
    ///     Contract for repository pattern.
    /// </summary>
    /// <typeparam name="T">
    ///     T is an <see cref="IAggregateRoot"/>.
    ///     This means repositories only exist on domain boundaries.
    /// </typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
        /// <summary>
        ///     <see cref="IUnitOfWork"/>
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}
