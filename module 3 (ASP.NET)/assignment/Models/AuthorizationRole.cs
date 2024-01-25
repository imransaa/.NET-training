using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace assignment.Models
{
    public class AuthorizationRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Role is a Required feild")]
        [MinLength(2, ErrorMessage = "Role should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Role { get; set; }

        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }

        // Many-To-Many Relations
        public ICollection<UserAuthorization> UserAuthorizations { get; set; }
        public ICollection<GroupAuthorization> GroupAuthorizations { get; set; }

    }
}
