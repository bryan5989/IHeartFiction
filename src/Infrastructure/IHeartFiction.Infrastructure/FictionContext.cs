/* Maintained By Johnathan P. Irvin
 *
 * ======== Disclaimer ========
 * This software may use 3rd party libraries, that have their own seperate licenses.
 * This software uses the GNU, General Public License (GPL v3) as defined at the link below.
 * https://www.gnu.org/licenses/gpl-3.0.en.html
 */

using IHeartFiction.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using StoryAggregate = IHeartFiction.Domain.AggregateModels.StoryAggregate;
using StoryConfiguration = IHeartFiction.Infrastructure.Configurations.StoryConfigurations;
using StorySeed = IHeartFiction.Infrastructure.Seeds.StorySeed;

namespace IHeartFiction.Infrastructure
{
    public class FictionContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

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

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StoryConfiguration.AuthorEntityTypeConfiguration());
            builder.ApplyConfiguration(new StoryConfiguration.ChapterEntityTypeConfiguration());
            builder.ApplyConfiguration(new StoryConfiguration.CommentEntityTypeConfiguration());
            builder.ApplyConfiguration(new StoryConfiguration.StoryEntityTypeConfiguration());

#if DEBUG
            builder.ApplyConfiguration(new StorySeed.AuthorSeed());
#endif
        }
    }
}
