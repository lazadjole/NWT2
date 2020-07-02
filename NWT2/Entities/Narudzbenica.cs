using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{  
    [Table ("Narudzbenice")]
    public class Narudzbenica
    {
        [Key]
        [Column("ID_Narudzbenice", TypeName = "uniqueidentifier")]
        public Guid NarudzbenicaID { get; set; }

        [Required]
        [MaxLength(15)]
        public string BrojNarudzbenice { get; set; }

        public Kupac kupac { get; set; }

        [ForeignKey("Kupci")]
        public Guid KupacID { get; set; }

        public Zaposleni Zaposleni { get; set; }

        [ForeignKey("Zaposleni")]
        public Guid ZaposleniId { get; set; }

        public StatusDostave statusDostave { get; set; }

        [ForeignKey("statusiDostave")]
        public Guid StatusDostaveID { get; set; }

        public NacinPlacanja  nacinPlacanja { get; set; }

        [NotMapped]
        [Column("ID_nacinPlacanja")]
        public Guid FKNacinPlacanjaID { get; set; }

        [Column(TypeName = "date")]
        public DateTime datumPrijema { get; set; }

        public Vozilo Vozilo { get; set; }

        [ForeignKey("Vozilo")]
        public Guid VoziloID { get; set; }

        public List<DetaljiNarudzbenice> DetaljiNarudzbenices { get; set; }

    }
}
