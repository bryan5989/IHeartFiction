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
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryRepository _repository;

        public StoriesController(IStoryRepository storyRepository) => _repository = storyRepository;

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