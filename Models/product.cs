using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_API.Models
{
    [Table("Product")]
    public class product
    {
        [Key]
        public int Id { get; set; }
        public string Productname { get; set; }
        [Column(TypeName = "Decimal(18,2)")]
        public decimal Price { get; set; }
        [StringLength(2000)]
        [Column(TypeName = "VARCHAR")]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

    }
}
