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
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.AdresaController.GetAdresaByIDAsync), new { id = src.AdresaID })));
            CreateMap<Entities.DetaljiNarudzbenice, Models.DetaljiNarudzbenice>()
                .ForMember(dest =>dest.PicaID, opt=>opt.MapFrom(src=>src.PicaID))
                .ForMember(dest => dest.Self, src => src.MapFrom(src => Link.To(nameof(Controllers.DetaljiNarudzbeniceController.GetDetaljiNarudzbeniceByIDasync), new { id = src.DetaljiNarudzbeniceID })));
            CreateMap<Entities.Dodatak, Models.Dodatak>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.DodatakController.GetDodatakByIdAsync), new { id = src.DodatakID })));
            CreateMap<Entities.EkstraDodaci, Models.EkstraDodaci>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.EkstraDodaciController.GetEkstraDodaciByIDAsync), new { id = src.Ekstra_dodaciID }))); 
            CreateMap<Entities.Kupac, Models.Kupac>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.KupacController.GetKupacByIdAsync), new { id = src.KupacID }))); 
                 CreateMap<Entities.Narudzbenica, Models.Narudzbenica>()
                 .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.NarudzbenicaController.GetNarudzbenicaByIdAsync), new { id = src.NarudzbenicaID })));
            CreateMap<Entities.Pica, Models.Pica>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.PicaController.GetPicaByIdAsync), new { id = src.PicaID }))); 
            CreateMap<Entities.StatusDostave, Models.StatusDostave>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.StatusDostaveController.GetStatusDostaveByIdAsync), new { id = src.StatusDostaveID })));
            CreateMap<Entities.TipVozila, Models.TipVozila>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.TipVozilaController.GetTipVozilaByIdAsync), new { id = src.TipVozilaID })));
            CreateMap<Entities.Vozilo, Models.Vozilo>().ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.VoziloController.GetVoziloByIdAsync), new { id = src.VoziloID })));
            CreateMap<Entities.Zaposleni, Models.Zaposlen>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(nameof(Controllers.ZaposleniController.GetZaposlenogByIDAsync), new { id = src.ZaposleniId })));
        }
    }
}
