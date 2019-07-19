/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.Models;
using IHeartFiction.Domain.SeedWork;
using System.Threading.Tasks;

namespace IHeartFiction.Domain.AggregateModels.StoryAggregate
{
    public interface IStoryRepository : IRepository<Story>
    {
        Task<Story> Get(int id);

        Task<Story> Update(int id, Story story);

        Task<Story> Post(Story story);

        Task<Story> Delete(int id);

        Task<Paginated<Story>> GetList(int page = 0, int perPage = 10);
    }
}
