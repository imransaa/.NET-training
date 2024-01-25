using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment.Models
{
    //[PrimaryKey(nameof(DocumentId), nameof(UserId))]
    public class UserAuthorization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // One-To-Many Relations
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public AuthorizationRole Role { get; set; }
    }
}
