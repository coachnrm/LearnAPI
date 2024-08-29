using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Modal
{
    public class CustomerModal
    {
        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string Code {get; set;} = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string Name {get; set;} = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string? Email {get; set;} 

        [StringLength(50)]
        [Unicode(false)]
        public string? Phone {get; set;}

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Creditlimit {get; set;}

        public bool? IsActive {get; set;}

        public string? Statusname {get; set;}
    }
}