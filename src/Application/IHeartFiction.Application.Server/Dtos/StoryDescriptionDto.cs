using IHeartFiction.Domain.AggregateModels.StoryAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;

namespace IHeartFiction.Application.Server.Dtos
{
    /// <summary>
    ///     Used to transfer just the details of the story to the frontend.
    /// </summary>
    public class StoryDescriptionDto
    {
        /// <summary>
        ///     Unique identifier of the story.
        ///     Used for links and the such.
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///     The title of the story.
        /// </summary>
        public string Title { get; }

        /// <summary>
        ///     The First 100 characters of the story's description.
        /// </summary>
        [StringLength(100)]
        public string Description { get; }

        /// <summary>
        ///     The names of the author's whom wrote the story.
        /// </summary>
        public ICollection<string> Authors { get; }

        /// <summary>
        ///     Constructor of Story Descriptions.
        /// </summary>
        /// <param name="id">
        ///     Unique identifier of a story.
        /// </param>
        /// <param name="title">
        ///     The title of a story.
        /// </param>
        /// <param name="description">
        ///     The description of the story.
        ///     Will be limited to 100 characters.
        /// </param>
        /// <param name="authors"></param>
        public StoryDescriptionDto(int id, string title, string description, ICollection<string> authors)
        {
            Contract.Requires(id > 0);
            Contract.Requires(!string.IsNullOrEmpty(title));
            Contract.Requires(!string.IsNullOrEmpty(description));
            Contract.Requires(authors.Count >= 1);

            Title = title;
            Description = String.Concat(description.Take(100));
            Authors = authors;
        }

        public static implicit operator StoryDescriptionDto(Story story)
        {
            var description = new StoryDescriptionDto(
                story.Id, 
                story.Title, 
                story.Description, 
                story.Authors.Select(p => p.Name).ToList());

            return description;
        }
    }
}
