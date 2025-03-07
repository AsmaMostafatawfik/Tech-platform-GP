using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Data.Entities
{
    public enum Category
    {
        GamingLaptop, FlagshipSmartphone, ProfessionalCamera, WirelessHeadphones, Smartwatch, TabletPro
    }

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required, StringLength(25)]
        public string Name { get; set; } = string.Empty;
        [Required, StringLength(400)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 100000)]
        public int StockQuantity { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public string Brand { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
