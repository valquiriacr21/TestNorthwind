using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Keyless]
    public partial class OrderDetailsExtended
    {
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name.. is Required")]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column(TypeName = "money")][DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        [Column(TypeName = "money")][DataType(DataType.Currency)]
        public decimal? ExtendedPrice { get; set; }
    }
}
