using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetsManager.API.Models.Entities
{
    public class Asset
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? ValidFrom { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? ValidTo { get; set; }
    }
}
