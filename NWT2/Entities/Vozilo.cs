using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{   
    [Table("Vozilo")]
    public class Vozilo
    {
        [Key]
        [Column("ID_Vozila", TypeName = "uniqueidentifier")]
        public Guid VoziloID { get; set; }

        [Required]
        public TipVozila TipVozila { get; set; }

        [NotMapped]
        [Column("ID_tipaVozila")]
        public Guid FKTipVozilaID { get; set; }

        [Required]
        [MaxLength(15)]
        public string EvidencioniBr { get; set; }

        [Required]
        [MaxLength(10)]
        public string MarkaVozila { get; set; }

        [MaxLength(60)]
        public string DetaljiVozila { get; set; }

        public List<Narudzbenica> Narudzbenice { get; set; }

    }
}
