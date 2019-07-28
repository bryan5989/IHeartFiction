/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.AggregateModels.StoryAggregate;
using IHeartFiction.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IHeartFiction.Application.Server.Controllers
{
    /// <summary>
    ///    Basic CRUD controller for <see cref="story">stories</see>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryRepository _repository;

        /// <summary>
        ///     Default constructor requires an implementation of 
        ///     <see cref="IStoryRepository">IStoryRepository</see> via
        ///     dependency injection.
        /// </summary>
        /// <param name="storyRepository">
        ///     The story infrastructure to be used.
        /// </param>
        public StoryController(IStoryRepository storyRepository)
        {
            _repository = storyRepository;
        }

        /// <summary>
        ///     Finds a specific <see cref="story">story</see> based on the provided id.
        /// </summary>
        /// <param name="id">
        ///     The unique story identifier to find.
        /// </param>
        /// <returns>
        ///     The story based on id.
        /// </returns>
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

        /// <summary>
        ///     Creates a new <see cref="story">story</see>
        /// </summary>
        /// <param name="story">
        ///     The <see cref="story">story</see> to be created.
        /// </param>
        /// <returns>
        ///     The created <see cref="story">story</see>.
        /// </returns>
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

        /// <summary>
        ///     Updates an existing <see cref="story">story</see> based on the id.
        /// </summary>
        /// <param name="id">
        ///     The unique id of the <see cref="story">story</see> to update.
        /// </param>
        /// <param name="story">
        ///     The new values of the <see cref="story">story</see>.
        /// </param>
        /// <returns>
        ///     The updated <see cref="story">story</see>.
        /// </returns>
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

        /// <summary>
        ///     Deletes a specific <see cref="story">story</see> based on id.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of a <see cref="story">story</see> to delete.
        /// </param>
        /// <returns>
        ///     Ok on success, bad request on <see cref="StoryNotFound">story not found.</see>
        /// </returns>
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