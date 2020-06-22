using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities
{  
    
    [Table("Kupci")]
    public class Kupac
    {   
        [Key]
        [Column("ID_Kupca", TypeName = "uniqueidentifier")]
        public Guid KupacID { get; set; }

        [MaxLength(18)]
        [Required]
        public string Ime { get; set; }

        [MaxLength(18)]
        [Required]
        public string Prezime { get; set; }

        [MaxLength(18)]
        [Required]
        public string Telefon { get; set; }
        [Required]
        public Adresa Adresa { get; set; }

        [NotMapped]
        public Guid FKAdresaID { get; set; }

        public List<Narudzbenica> Narudzbenice { get; set; }
    }
}
