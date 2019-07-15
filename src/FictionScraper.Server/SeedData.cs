using FictionScraper.Shared;
using System;

namespace FictionScraper.Server
{
    public class SeedData
    {
        public static void SeedDatabase(AppDbContext context)
        {
            var chapters = new StoryChapter[]
            {
                new StoryChapter()
                {
                    ChapterSeq = 1,
                    HtmlContent = "<h1>BOO!</h1>",
                    StoryGuid = Guid.NewGuid()
                }
            };

            context.Chapters.AddRange(chapters);
            context.SaveChanges();
        }
    }
}
