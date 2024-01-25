using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace assignment.Models
{
    public class DocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Type is a Required feild")]
        [MinLength(2, ErrorMessage = "Type should contain alteast 2 character")]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)*$", ErrorMessage = "Use only Characters")]
        public string Type { get; set; }

        [DefaultValue("getdate()")]
        public DateTime CreatedAt { get; set; }

        // Many-To-Many Relations
        public ICollection<Document> Documents { get; set; }
    }
}
