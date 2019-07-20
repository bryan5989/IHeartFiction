/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.AggregateModels.StoryAggregate;
using IHeartFiction.Domain.Models;
using IHeartFiction.Domain.SeedWork;
using IHeartFiction.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IHeartFiction.Infrastructure.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly FictionContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public StoryRepository(FictionContext context) => _context = context;

        public async Task<Story> Get(int id)
        {
            var story = await _context.Stories.FindAsync(id);

            if (story == null) throw new StoryNotFound();

            return story;
        }

        public async Task<Story> Update(int id, Story story)
        {
            if (!Exists(id) || story.Id != id) throw new StoryNotFound();

            _context.Entry(story).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return story;
        }

        public async Task<Story> Post(Story story)
        {
            var saved = (await _context.Stories.AddAsync(story)).Entity;

            await _context.SaveChangesAsync();

            return saved;
        }

        public async Task<Story> Delete(int id)
        {
            if (!Exists(id)) throw new StoryNotFound();

            var story = await _context.Stories.FindAsync(id);

            _context.Stories.Remove(story);

            await _context.SaveChangesAsync();

            return story;
        }

        public async Task<Paginated<Story>> GetList(int page = 0, int perPage = 10)
        {
            var stories = await _context
                .Stories
                .Skip(page * perPage)
                .Take(page)
                .ToListAsync();

            var count = _context
                .Stories
                .Count();

            var pages = count == 0 ? 0 : count / perPage;

            return new Paginated<Story>(page, pages, perPage, stories);
        }

        private bool Exists(int id) => _context.Stories.Count(p => p.Id == id) != 0;
    }
}
