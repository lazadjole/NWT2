using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{   
    [Table("Pice")]
    public class Pica
    {
        [Key]
        [Column("ID_Pice", TypeName = "uniqueidentifier")]
        public Guid PicaID { get; set; }

        [Required]
        [MaxLength(18)]
        public string NazivPice { get; set; }

        [Required]
        [MaxLength(18)]
        public string Kratak_opis { get; set; }

        [Column(TypeName ="smallint")]
        public int Cena { get; set; }
    }
}
