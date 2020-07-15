using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NWT2.Models;

namespace NWT2.Controllers
{   [Route("/")]
    public class RootController : Controller
    {   
        [HttpGet(Name=nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new RootResponse
            {
                Self = Link.To(nameof(GetRoot)),
                Adrese = Link.To(nameof(AdreseController.GetAdresaAsync)),
                DetaljiNarudzbenica = Link.To(nameof(DetaljiNarudzbeniceController.GetDetaljiNarudzbeniceAsync)),
                Dodaci = Link.To(nameof(DodaciController.GetDodaciAsync)),
                EkstraDodaci = Link.To(nameof(EkstraDodaciController.GetEkstraDodaciAsync)),
                Kupci = Link.To(nameof(KupciController.GetKupciAsync)),
                Narudzbenice = Link.To(nameof(NarudzbeniceController.GetNarudzbeniceAsync)),
                Pice = Link.To(nameof(PiceController.GetPiceAsync)),
                StatusDostave = Link.To(nameof(StatusDostaveController.GetStatusDostaveAsync)),
                TipoviVozila = Link.To(nameof(TipVozilaController.GetTipVozilaAsync)),
                Vozila = Link.To(nameof(VozilaController.GetVozilaAsync)),
                Zaposleni = Link.To(nameof(ZaposleniController.GetZaposleniAsync)),

            };

            return Ok( response);
            
        }
    }
}