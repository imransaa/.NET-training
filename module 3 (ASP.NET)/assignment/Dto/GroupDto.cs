using assignment.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment.Dto
{
    public class CreateGroupDto
    {
        [Required(ErrorMessage = "Name is a Required feild")]
        [MinLength(2, ErrorMessage = "Name should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Name { get; set; }
    }

    public class GroupDetailsDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a Required feild")]
        [MinLength(2, ErrorMessage = "Name should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class GroupMembersDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a Required feild")]
        [MinLength(2, ErrorMessage = "Name should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public class GroupMemberDto
    {
        [Required(ErrorMessage ="User Emails is a required feild")]
        public List<string> Emails { get; set; }
    }
}
