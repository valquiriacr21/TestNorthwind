using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Keyless]
    public partial class SummaryOfSalesByYear
    {
        [Column(TypeName = "datetime")]
        [DataType(DataType.DateTime)]
        public DateTime? ShippedDate { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column(TypeName = "money")][DataType(DataType.Currency)]
        public decimal? Subtotal { get; set; }
    }
}
