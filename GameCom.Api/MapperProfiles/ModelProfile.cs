using AutoMapper;
using GameCom.Api.DTOs;
using GameCom.Common.Extensions;
using GameCom.Model.Entities;

namespace Stock.Api.MapperProfiles
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            //Mapeos de DTO a BE
            CreateMap<Usuario, UsuarioDTO>()
                .IgnoreAllNonExisting()
                .ForMember(t => t.Nombre, opt => opt.MapFrom(s => s.DatosPersonales.Nombre))
                .ForMember(t => t.Apellido, opt => opt.MapFrom(s => s.DatosPersonales.Apellido))
                .ForMember(t => t.FechaNacimiento, opt => opt.MapFrom(s => s.DatosPersonales.FechaNacimiento))
                .ForMember(t => t.Telefono, opt => opt.MapFrom(s => s.DatosPersonales.Telefono))
                .ReverseMap()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.Version, opt => opt.Ignore());
        }
    }


}
