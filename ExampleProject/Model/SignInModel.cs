using System.ComponentModel.DataAnnotations;

namespace ExampleProject.Model
{
    public class SignInModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType (DataType.Password)]
        public string Password { get; set; }

    }
}
