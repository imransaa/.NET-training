using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace assignment.Models
{
    public class GroupAuthorization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // One-To-Many Relations
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int RoleId { get; set; }
        public AuthorizationRole Role { get; set; }
    }
}
