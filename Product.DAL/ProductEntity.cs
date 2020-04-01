using System;
using System.ComponentModel.DataAnnotations;

namespace Product.DAL
{
    public sealed class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}