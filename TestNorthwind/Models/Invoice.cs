using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Keyless]
    public partial class Invoice
    {
        [StringLength(40)]
        public string ShipName { get; set; }
        [StringLength(60)]
        public string ShipAddress { get; set; }
        [StringLength(15)]
        
        public string ShipCity { get; set; }
        [StringLength(15)]
        public string ShipRegion { get; set; }
        [StringLength(10)]
        [DataType(DataType.PostalCode)]
        public string ShipPostalCode { get; set; }
        [StringLength(15)]
        public string ShipCountry { get; set; }
        [Column("CustomerID")]
        [StringLength(5)]
        [ForeignKey("CustomerID")]
        public string CustomerId { get; set; }
        [Required(ErrorMessage = "Customer Name.. is Required")]
        [StringLength(40)]
        public string CustomerName { get; set; }
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
        [Required(ErrorMessage = "Sales person.. is Required")]
        [StringLength(31)]
        public string Salesperson { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column(TypeName = "datetime")]
        [DataType(DataType.DateTime)]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        [DataType(DataType.DateTime)]
        public DateTime? RequiredDate { get; set; }
        [Column(TypeName = "datetime")]
        [DataType(DataType.DateTime)]
        public DateTime? ShippedDate { get; set; }
        [Required(ErrorMessage = "Shipper Name.. is Required")]
        [StringLength(40)]
        public string ShipperName { get; set; }
        [Column("ProductID")]
        [ForeignKey("ProductID")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name.. is Required")]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        
        public decimal? ExtendedPrice { get; set; }
        [Column(TypeName = "money")]
        [DataType(DataType.Currency)]
        
        public decimal? Freight { get; set; }
    }
}
