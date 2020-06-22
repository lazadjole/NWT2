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

        [Required]
        public Dodatak Dodatak { get; set; }

        [NotMapped]
        [Column("ID_Dodatka")]
        public Guid FKDodatakID { get; set; }

        [Required]
        public DetaljiNarudzbenice DetaljiNarudzbenice { get; set; }

        [NotMapped]
        [Column("ID_DetaljiNarudzbenice")]
        public Guid FKDetaljiNarudzbeniceID { get; set; }
    }
}
