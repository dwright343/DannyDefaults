using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DannyDefaults.Models
{
    public class Default_Model
    {
        [Key]
        [Required]
        public int DefaultId { get; set; }
        public string DefaultName { get; set; }
        public string DefaultLetter { get; set; }
        public int DefaultInt { get; set; } = 1;
        public DateTime DefaultDate { get; set; }
    }
}
