using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace assignment.Models
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a Required feild")]
        [MinLength(2, ErrorMessage = "Name should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Name { get; set; }

        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }

        // One-To-One relations
        public int CreatorId { get; set; }
        public User? Creator{ get; set; }

        public int TypeId { get; set; }
        public DocumentType? Type { get; set; }

        // Many-To-Many Relations
        public ICollection<UserAuthorization> UserAuthorizations { get; set; }
        public ICollection<GroupAuthorization> GroupAuthorizations { get; set; }


    }
}
