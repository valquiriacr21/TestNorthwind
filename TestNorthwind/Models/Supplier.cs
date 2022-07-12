using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Index("CompanyName", Name = "CompanyName")]
    [Index("PostalCode", Name = "PostalCode")]
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Company Name is Required")]
        [StringLength(40)]

        public string CompanyName { get; set; }
        [StringLength(30)]
        public string ContactName { get; set; }
        [StringLength(30)]
        public string ContactTitle { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        [StringLength(15)]
        public string Country { get; set; }
        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [StringLength(24)]
        public string Fax { get; set; }
        public string HomePage { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
