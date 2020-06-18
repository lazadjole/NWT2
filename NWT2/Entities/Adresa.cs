using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{  
    [Table("Adrese")]
    public class Adresa
    {   
        [Key]
        [Column("ID_Adrese", TypeName = "uniqueidentifier")]
        public Guid AdresaID { get; set; }

        [MaxLength(60)]
        [Required]
        public string Ulica { get; set; }

        public int Broj { get; set; }

        [Required]
        [MaxLength(30)]
        public string Grad { get; set; }

        public List<Kupac> Kupci { get; set; }

        public List<Zaposleni> Zaposleni { get; set; }
    }
}
