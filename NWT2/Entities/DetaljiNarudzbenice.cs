using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{
    [Table("DetaljiNarudzbenica")]
    public class DetaljiNarudzbenice
    {
        [Key]
        [Column("ID_DetNarudzbenice", TypeName = "uniqueidentifier")]
        public Guid DetaljiNarudzbeniceID { get; set; }

        [Required]
        public Pica Pica { get; set; }

        [NotMapped]
        [Column("ID_pice")]
        public int FKPicaID { get; set; }

        [Required]
        public Narudzbenica Narudzbenica { get; set; }

        [NotMapped]
        [Column("ID_narudzbenica")]
        public int FKNarudzbenicaID { get; set; }

        [Required]
        [Column(TypeName ="tinyint")]
        public int Kolicina { get; set; }

        public List<EkstraDodaci> EkstraDodaci { get; set; }



    }
}
