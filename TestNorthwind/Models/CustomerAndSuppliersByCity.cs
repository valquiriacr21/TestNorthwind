using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Keyless]
    public partial class CustomerAndSuppliersByCity
    {
        [StringLength(15)]
        public string City { get; set; }
        [Required(ErrorMessage = "Company Name.. is Required")]
        [StringLength(40)]
        public string CompanyName { get; set; }
        [StringLength(30)]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Relationship.. is Required")]
        [StringLength(9)]
        [Unicode(false)]
        public string Relationship { get; set; }
    }
}
