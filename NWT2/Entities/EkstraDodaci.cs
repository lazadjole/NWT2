using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{   [Table("EkstraDodaci")]
    public class EkstraDodaci
    {
        [Key]
        [Column("ID_Dodaci", TypeName = "uniqueidentifier")]
        public Guid Ekstra_dodaciID { get; set; }

      
        public Dodatak Dodatak { get; set; }

        [Required]
        [ForeignKey("Dodaci")]
        public Guid DodatakID { get; set; }

        [NotMapped]

        public DetaljiNarudzbenice DetaljiNarudzbenice { get; set; }

        [Required]
        [ForeignKey("DetaljiNarudzbenica")]
        public Guid DetaljiNarudzbeniceID { get; set; }
    }
}
