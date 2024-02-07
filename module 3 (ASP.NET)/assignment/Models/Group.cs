using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace assignment.Models
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is a Required feild")]
        [MinLength(2, ErrorMessage ="Name should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Name { get; set; }

        [DefaultValue("now()")]
        public DateTime CreatedAt { get; set; }

        // One-To-Many Relations
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public User? Creator { get; set; }

        // Many-To-Many Relations
        public ICollection<User> Users { get; set; }
        public ICollection<GroupAuthorization>? GroupAuthorizations { get; set; }
    }
}
