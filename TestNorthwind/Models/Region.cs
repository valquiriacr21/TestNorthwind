﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestNorthwind.Models
{
    [Table("Region")]
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        [Key]
        [Column("RegionID")]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "Region Description.. is Required")]
        [StringLength(50)]
        public string RegionDescription { get; set; }
        
        [InverseProperty("Region")]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
