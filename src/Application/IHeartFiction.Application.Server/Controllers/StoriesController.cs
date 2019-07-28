/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Application.Server.Dtos;
using IHeartFiction.Domain.AggregateModels.StoryAggregate;
using IHeartFiction.Domain.SeedWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IHeartFiction.Application.Server.Controllers
{
    /// <summary>
    ///     Returns <see cref="StoryDescriptionDto">story description data transfer object</see> via
    ///     stardard create, update, read, delete methodologies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryRepository _repository;

        /// <summary>
        ///     Default constructor expects an <see cref="IStoryRepository">story repository</see> through
        ///     dependency injection. Allows for easily switching of backend.
        /// </summary>
        /// <param name="storyRepository"></param>
        public StoriesController(IStoryRepository storyRepository) => _repository = storyRepository;

        /// <summary>
        ///     Get a specific page of the stories.
        /// </summary>
        /// <param name="page">
        ///     The page to access of stories.
        /// </param>
        /// <param name="perPage">
        ///     The amount of stories per page.
        /// </param>
        /// <returns>
        ///     A paginated view of stories.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Paginated<StoryDescriptionDto>>> Get(int page = 0, int perPage = 10)
        {
            var stories = await _repository.GetList(page, perPage);
            var descriptions = new Paginated<StoryDescriptionDto>(
                page,
                stories.TotalPages,
                perPage,
                stories.Items.Select(p => (StoryDescriptionDto)p).ToList());

            return descriptions;
        }
    }
}