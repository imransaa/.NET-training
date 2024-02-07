using System.ComponentModel.DataAnnotations;

namespace assignment.Dto
{
    public class DocumentDto
    {
        [Required(ErrorMessage = "Name is a Required feild")]
        [MinLength(2, ErrorMessage = "Name should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is a Required feild")]
        [MinLength(2, ErrorMessage = "Type should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Type { get; set; }
    }
}
