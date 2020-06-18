using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{   [Table("statusiDostave")]
    public class StatusDostave
    {
        [Key]
        [Column("ID_statusa", TypeName = "uniqueidentifier")]
        public Guid StatusDostaveID { get; set; }

        [Required]
        [MaxLength(20)]
        public string NazivStatusa { get; set; }

        public List<Narudzbenica> Narudzbenice { get; set; }

    }
}
