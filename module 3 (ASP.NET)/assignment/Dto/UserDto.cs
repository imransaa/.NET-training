using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment.Dto
{
    public class UserDto
    {
        [Required(ErrorMessage = "Name is a Required feild")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Minimumm 3 Characters are required")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a Required feild")]
        [MinLength(3, ErrorMessage = "Minimumm 3 Characters are required")]
        [EmailAddress]
        public string Email { get; set; }

        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }
    }

    public class SigninDto
    {
        [Required(ErrorMessage = "Email is a Required feild")]
        [MinLength(3, ErrorMessage = "Minimumm 3 Characters are required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is a Required feild")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[~!@#$%^&*()_+\\-=/*-+{}[\\]'\";:,.<>/?\\\\|])[a-zA-Z0-9~!@#$%^&*()_+\\-=/*-+{}[\\]'\";:,.<>/?\\\\|]+$", 
            ErrorMessage = "Password should contain digits, capital letters, small letters and special characters")]
        public string Password { get; set; }
    }

    public class TokenDto
    {
        [Required]
        public string Token { get; set; }
    }

    public class SignupDto
    {
        [Required(ErrorMessage = "Name is a Required feild")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Minimumm 3 Characters are required")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a Required feild")]
        [MinLength(3, ErrorMessage = "Minimumm 3 Characters are required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is a Required feild")]
        [MinLength(8, ErrorMessage = "Minimumm 8 Characters are required")]
        public string Password { get; set; }
    }
}
