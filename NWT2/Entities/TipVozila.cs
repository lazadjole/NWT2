using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{   [Table("TipoviVozila")]
    public class TipVozila
    {
        [Key]
        [Column("ID_tipVozila", TypeName = "uniqueidentifier")]
        public Guid TipVozilaID { get; set; }

        [Required]
        [MaxLength(30)]
        public string vrstaVozila { get; set; }

        public List<Vozilo> Vozila { get; set; }
    }
}
