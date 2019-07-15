/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using System.Threading;
using System.Threading.Tasks;

namespace IHeartFiction.Domain.SeedWork
{
    /// <summary>
    ///     Unit of Work Pattern.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        ///     Save The Changes to the Database without calling any mediatr, or event patterns.
        ///     The sole purpose of this function is to just save data. It aligns directly with
        ///     entity framework core's "SaveChangesAsync" on its "DbContext" class. Which
        ///     allows an easy inheritance of both this interface, and a dbcontext. Leading to
        ///     implementation of an existing Object Relational Mapper at the infrastructure
        ///     level. 
        /// </summary>
        /// <param name="cancellationToken">
        ///     Asychronous token that allows the task to be cancelled.
        /// </param>
        /// <returns>
        ///     The number of entities that were saved during the transaction.
        /// </returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Save the changes and dispute all events, and side effect functionality on those
        ///     changes which are being tracked by the unit of work. It is not uncommon that
        ///     <seealso cref="SaveChangesAsync"/> will be called through this implementation.
        ///     However it should be noted this contract is intended to dispatch events,
        ///     execute commands, and propogate these related task throughout the business
        ///     domain.
        /// </summary>
        /// <param name="cancellationToken">
        ///     Asychronous token that allows the task to be cancelled.
        /// </param>>
        /// <returns>
        ///     This contract expects the success of the function to be returned. True for
        ///     successful, and false for failure.
        /// </returns>
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
