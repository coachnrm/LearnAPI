using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Models
{
    [Table("tbl_product")]
    public class TblProduct
    {
        [Key]
        [Column("code")]
        [StringLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = null!;

        [Column("name")]
        [Unicode(false)]
        public string? Name { get; set; }

        [Column("price", TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
    }
}