namespace TwitterLike.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }
}
