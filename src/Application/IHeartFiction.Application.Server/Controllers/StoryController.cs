/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.AggregateModels.StoryAggregate;
using IHeartFiction.Domain.Models;
using IHeartFiction.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IHeartFiction.Application.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryRepository _repository;

        public StoryController(IStoryRepository storyRepository)
        {
            _repository = storyRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Story>> Get(int id)
        {
            try
            {
                return await _repository.Get(id);
            }
            catch (StoryNotFound)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Story>> Post(Story story)
        {
            story = await _repository.Post(story);

            return CreatedAtAction(
                nameof(Get),
                nameof(StoryController),
                new { id = story.Id },
                story);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Story>> Put (int id, Story story)
        {
            try
            {
                return await _repository.Update(id, story);
            }
            catch (StoryNotFound)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (StoryNotFound)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}