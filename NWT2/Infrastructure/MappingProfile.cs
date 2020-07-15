using AutoMapper;
using NWT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWT2.Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Adresa,Models.Adresa>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.AdreseController.GetAdresaByIDAsync), new { id = src.AdresaID })));
            CreateMap<Entities.DetaljiNarudzbenice, Models.DetaljiNarudzbenice>()
                .ForMember(dest =>dest.NazivPice, opt=>opt.MapFrom(src=>src.Pica.NazivPice))
                .ForMember(dest=>dest.BrojNarudzbenice,opt=>opt.MapFrom(src=>src.Narudzbenica.BrojNarudzbenice))
                .ForMember(dest => dest.Self, src => src.MapFrom(src => Link.To(nameof(Controllers.DetaljiNarudzbeniceController.GetDetaljiNarudzbeniceByIDasync), new { id = src.DetaljiNarudzbeniceID })));
            CreateMap<Entities.Dodatak, Models.Dodatak>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.DodaciController.GetDodatakByIdAsync), new { id = src.DodatakID })));
            CreateMap<Entities.EkstraDodaci, Models.EkstraDodaci>()
                .ForMember(dest=>dest.NazivDodatka,opt=>opt.MapFrom(src=>src.Dodatak.Naziv_dodatka))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.EkstraDodaciController.GetEkstraDodaciByIDAsync), new { id = src.Ekstra_dodaciID }))); 
            CreateMap<Entities.Kupac, Models.Kupac>()
                .ForMember(dest=>dest.Grad,opt=>opt.MapFrom(src=>src.Adresa.Grad))
                .ForMember(dest => dest.Ulica, opt => opt.MapFrom(src => src.Adresa.Ulica))
                .ForMember(dest => dest.Broj, opt => opt.MapFrom(src => src.Adresa.Broj))
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.KupciController.GetKupacByIdAsync), new { id = src.KupacID }))); 
                 CreateMap<Entities.Narudzbenica, Models.Narudzbenica>()
                 .ForMember(dest => dest.imeKupca, opt => opt.MapFrom(src => src.kupac.Ime))
                 .ForMember(dest => dest.prezimeKupca, opt => opt.MapFrom(src => src.kupac.Prezime))
                 .ForMember(dest => dest.imeZaposleng, opt => opt.MapFrom(src => src.Zaposleni.Ime))
                 .ForMember(dest => dest.prezimeZaposlenog, opt => opt.MapFrom(src => src.Zaposleni.Prezime))
                 .ForMember(dest => dest.statusDostave, opt => opt.MapFrom(src => src.statusDostave.NazivStatusa))
                 .ForMember(dest => dest.evidencioniBrVozila, opt => opt.MapFrom(src => src.Vozilo.EvidencioniBr))
                 .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.NarudzbeniceController.GetNarudzbenicaByIdAsync), new { id = src.NarudzbenicaID })));
            CreateMap<Entities.Pica, Models.Pica>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.PiceController.GetPicaByIdAsync), new { id = src.PicaID }))); 
            CreateMap<Entities.StatusDostave, Models.StatusDostave>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.StatusDostaveController.GetStatusDostaveByIdAsync), new { id = src.StatusDostaveID })));
            CreateMap<Entities.TipVozila, Models.TipVozila>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.TipVozilaController.GetTipVozilaByIdAsync), new { id = src.TipVozilaID })));
            CreateMap<Entities.Vozilo, Models.Vozilo>().ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.VozilaController.GetVoziloByIdAsync), new { id = src.VoziloID })));
            CreateMap<Entities.Zaposleni, Models.Zaposlen>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.ZaposleniController.GetZaposlenogByIDAsync), new { id = src.ZaposleniId })));
        }
    }
}
