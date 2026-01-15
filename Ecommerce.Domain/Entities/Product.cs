using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required, StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 999999999)]
        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
