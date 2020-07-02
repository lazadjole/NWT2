using Newtonsoft.Json;
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

        
        public Pica Pica { get; set; }

        [ForeignKey("Pica")]
        public Guid PicaID { get; set; }

        
        public Narudzbenica Narudzbenica { get; set; }

        [ForeignKey("Narudzbenica")]
        public Guid NarudzbenicaID { get; set; }

        [Required]
        [Column(TypeName ="tinyint")]
        public int Kolicina { get; set; }


        public List<EkstraDodaci> EkstraDodaci { get; set; }



    }
}
