using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeErector.Models
{
    public class ContactDetails
    {
        [Key]
        [Required]
        [Column(TypeName = "int")]
        public int ContactId { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CDate { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Alphabeths Only...!")]
        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string CustName { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string massage { get; set; }
    }
}
