namespace TwitterLike.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterBindingModel
    {
        [Required, Display(Name = "Username")]
        public string UserName { get; set; }

        [Required, Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}