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

        [Required]
        public Kupac kupac { get; set; }

        [NotMapped]
        [Column("ID_kupca")]
        public int FKKupacID { get; set; }

        [Required]
        public Zaposleni Zaposleni { get; set; }

        [NotMapped]
        [Column("ID_zaposlenog")]
        public int FKZaposleniId { get; set; }

        [Required]
        public StatusDostave statusDostave { get; set; }

        [NotMapped]
        [Column("ID_statusaDostave")]
        public int FKStatusDostaveID { get; set; }

        public NacinPlacanja  nacinPlacanja { get; set; }

        [NotMapped]
        [Column("ID_nacinPlacanja")]
        public int FKNacinPlacanjaID { get; set; }

        [Column(TypeName = "date")]
        public DateTime datumPrijema { get; set; }

        [Required]
        public Vozilo Vozilo { get; set; }

        [NotMapped]
        [Column("ID_vozila")]
        public int FKVoziloID { get; set; }

        public List<DetaljiNarudzbenice> DetaljiNarudzbenices { get; set; }

    }
}
