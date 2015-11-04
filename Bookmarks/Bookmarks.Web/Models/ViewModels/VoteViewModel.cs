namespace Bookmarks.Web.Models.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class VoteViewModel
    {
        public string Username { get; set; }

        public int Stars { get; set; }
    }
}