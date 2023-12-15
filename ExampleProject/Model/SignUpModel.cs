using System.ComponentModel.DataAnnotations;

namespace ExampleProject.Model
{
    public class SignUpModel
    {
        [Required]
        [EmailAddress]
        [Display (Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Display(Name = "Password")]
        [Compare ("ConformPassword")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Conform Password")]
        public string ConformPassword { get; set; }
    }
}
