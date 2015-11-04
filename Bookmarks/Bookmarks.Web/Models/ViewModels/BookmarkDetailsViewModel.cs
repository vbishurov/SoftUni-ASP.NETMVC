namespace Bookmarks.Web.Models.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BookmarkDetailsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public CategoryViewModel Category { get; set; }

        public IList<CommentViewModel> Comments { get; set; }

        public IList<VoteViewModel> Votes { get; set; }

        public double? AverageRating { get; set; }

        public int VotesCount { get; set; }
    }
}