using System.ComponentModel.DataAnnotations;

namespace miniproject.viewModel
{
    public class RegisterVM
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
