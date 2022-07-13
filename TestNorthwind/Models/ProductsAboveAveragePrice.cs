using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Keyless]
    public partial class ProductsAboveAveragePrice
    {
        [Required(ErrorMessage = "Product Name.. is Required")]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }
    }
}
