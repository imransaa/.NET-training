using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment.Dto
{
    public class TypeDto
    {
        [Required(ErrorMessage = "Type is a Required feild")]
        [MinLength(2, ErrorMessage = "Type should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Type { get; set; }

        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }
    }
}
