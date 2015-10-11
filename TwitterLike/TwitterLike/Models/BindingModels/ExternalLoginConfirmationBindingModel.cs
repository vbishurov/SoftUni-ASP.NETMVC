namespace TwitterLike.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}