using System;
using System.ComponentModel.DataAnnotations;

namespace Product.Common
{
    [Serializable]
    public sealed class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(ErrorMessage = "Name can't be greater than 100 chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [MaxLength(ErrorMessage = "Category can't be greater than 100 chars")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0,int.MaxValue,ErrorMessage = "Quantity can't be negative or more than integer limits")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "UnitPrice is required")]
        [Range(0.0, double.MaxValue, ErrorMessage = "UnitPrice can't be negative or more than representation limits")]
        public decimal UnitPrice { get; set; }

        [Range(0.0, double.MaxValue, ErrorMessage = "TotalPrice can't be negative or more than representation limits")]
        public decimal TotalPrice { get; set; }
    }
}