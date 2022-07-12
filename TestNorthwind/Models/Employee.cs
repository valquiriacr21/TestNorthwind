﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    [Index("LastName", Name = "LastName")]
    [Index("PostalCode", Name = "PostalCode")]
    public partial class Employee
    {
        public Employee()
        {
            InverseReportsToNavigation = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            Territories = new HashSet<Territory>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Last Name.. is Required")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(10)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }
        [Column(TypeName = "datetime")]
        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "datetime")]
        [DataType(DataType.DateTime)]
        public DateTime? HireDate { get; set; }
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
        public string HomePhone { get; set; }
        [StringLength(4)]
        public string Extension { get; set; }
        [Column(TypeName = "image")]
        [DataType(DataType.Upload)]
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        [StringLength(255)]
        public string PhotoPath { get; set; }

        [ForeignKey("ReportsTo")]
        [InverseProperty("InverseReportsToNavigation")]
        public virtual Employee ReportsToNavigation { get; set; }
        [InverseProperty("ReportsToNavigation")]
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Order> Orders { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Employees")]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
