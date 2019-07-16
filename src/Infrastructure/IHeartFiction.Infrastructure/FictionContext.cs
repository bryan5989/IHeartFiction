/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using StoryAggregate = IHeartFiction.Domain.AggregateModels.StoryAggregate;
using IHeartFiction.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace IHeartFiction.Infrastructure
{
    public class FictionContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public DbSet<StoryAggregate.Author> StoryAuthors { get; set; }
        public DbSet<StoryAggregate.Chapter> StoryChapters { get; set; }
        public DbSet<StoryAggregate.Comment> StoryComment { get; set; }
        public DbSet<StoryAggregate.Story> Stories { get; set; }

        private FictionContext(DbContextOptions<FictionContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public FictionContext(DbContextOptions<FictionContext> options, IMediator mediator) : base(options)
        {
            Database.EnsureCreated();

            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
