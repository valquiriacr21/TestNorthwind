﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Index("CategoryId", Name = "CategoriesProducts")]
    [Index("CategoryId", Name = "CategoryID")]
    [Index("ProductName", Name = "ProductName")]
    [Index("SupplierId", Name = "SupplierID")]
    [Index("SupplierId", Name = "SuppliersProducts")]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name.. is Required")]
        [StringLength(40)]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        [Column("CategoryID")]
        public int? CategoryId { get; set; }
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "money")][DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("Products")]
        public virtual Supplier Supplier { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
