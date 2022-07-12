using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Keyless]
    public partial class CategorySalesFor1997
    {
        [Required(ErrorMessage = "Category Name.. is Required")]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Column(TypeName = "money")][DataType(DataType.Currency)]
        public decimal? CategorySales { get; set; }
    }
}
