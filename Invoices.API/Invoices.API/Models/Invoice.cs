using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.API.Models
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime IssueDate { get; set; }
        public int IssueYear { get; set; }
        public int IssueMonth { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Total { get; set; }

    }
}
