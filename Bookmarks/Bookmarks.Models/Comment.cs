namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Bookmark")]
        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }
    }
}
