using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{  
    [Table("Dodaci")]
    public class Dodatak
    {
        [Key]
        [Column("ID_Dodaci", TypeName = "uniqueidentifier")]
        public Guid DodatakID { get; set; }

        [Required]
        [MaxLength(18)]
        public string Naziv_dodatka { get; set; }

        [Column(TypeName ="smallint")]
        public int Cena { get; set; }

        public List<EkstraDodaci> EkstraDodaci { get; set; }
    }
}
