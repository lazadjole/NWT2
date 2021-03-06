﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Entities

{   [Table("Zaposleni")]
    public class Zaposleni
    {
        [Key]
        [Column("ID_zaposlen", TypeName = "uniqueidentifier")]
        public Guid ZaposleniId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Ime { get; set; }

        [MaxLength(30)]
        [Required]
        public String Prezime { get; set; }

        public Adresa Adresa { get; set; }

        [ForeignKey("Adrese")]
        public Guid AdresaID { get; set; }

        [MaxLength(15)]
        public string BrojTelefona { get; set; }

        public List<Narudzbenica> Narudzbenice { get; set; }

    }
}
