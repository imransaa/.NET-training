using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace assignment.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is a Required feild")]
        [StringLength(250, MinimumLength =3, ErrorMessage ="Minimumm 3 Characters are required")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage ="Use only Characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a Required feild")]
        [MinLength(3, ErrorMessage = "Minimumm 3 Characters are required")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage ="Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Hashed Password is requried")]
        public string HashedPassword { get; set; }

        [Required(ErrorMessage ="Salt is requried")]
        public string Salt { get; set; }

        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }

        // Many-To-Many Relations
        [InverseProperty("Creator")]
        public ICollection<Group> CreatedGroups { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<UserAuthorization> UserAuthorizations { get; set; }

    }
}
