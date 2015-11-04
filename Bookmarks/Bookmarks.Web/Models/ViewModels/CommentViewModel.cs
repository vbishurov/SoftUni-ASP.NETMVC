namespace Bookmarks.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel
    {
        public string Username { get; set; }

        public string Text { get; set; }
    }
}