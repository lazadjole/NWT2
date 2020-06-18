using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{   [Table("NaciniPlacanja")]
    public class NacinPlacanja
    {   
        [Key]
        [Column("ID_NacinPlacanja", TypeName = "uniqueidentifier")]
        public Guid NacinPlacanjaID { get; set; }

        [MaxLength(30)]
        [Required]
        public string NazivNacinaPlacanja { get; set; }

        public List<Narudzbenica> Narudzbenice { get; set; }
    }
}
