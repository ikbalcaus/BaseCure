using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BaseCureAPI.DB.Models
{
    [Table("Gradovi")]
    public class Gradovi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int grad_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Naziv { get; set; }

        [Required]
        [MaxLength(255)]
        public string Entitet { get; set; }

    }
}
