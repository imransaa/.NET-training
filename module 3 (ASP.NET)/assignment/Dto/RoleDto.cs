using System.ComponentModel.DataAnnotations;

namespace assignment.Dto
{
    public class RoleDto
    {
        [Required(ErrorMessage = "Role is a Required feild")]
        [MinLength(2, ErrorMessage = "Role should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Role { get; set; }
    }
}
