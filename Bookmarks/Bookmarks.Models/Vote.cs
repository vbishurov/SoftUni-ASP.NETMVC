namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vote
    {
        public int Id { get; set; }

        [Range(0, 10)]
        public int Stars { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Bookmark")]
        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }
    }
}
