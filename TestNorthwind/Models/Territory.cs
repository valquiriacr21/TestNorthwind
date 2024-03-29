﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TestNorthwind.Models
{
    public partial class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [Column("TerritoryID")]
        [StringLength(20)]
        public string TerritoryId { get; set; }
        [Required(ErrorMessage = "Territory Description.. is Required")]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }
        [Column("RegionID")]
        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("Territories")]
        public virtual Region Region { get; set; }

        [ForeignKey("TerritoryId")]
        [InverseProperty("Territories")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
