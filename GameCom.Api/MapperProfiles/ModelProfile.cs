using AutoMapper;
using GameCom.Api.DTOs;
using GameCom.Common.Extensions;
using GameCom.Model.Entities;

namespace Stock.Api.MapperProfiles
{
    public class ModelProfile: Profile
    {
        public ModelProfile()
        {
            CreateMap<ProductType, ProductTypeDTO>()
                //.IgnoreAllNonExisting()
                .ReverseMap()
                .ForMember(s => s.Id, opt => opt.Ignore());

            //CreateMap<Product, ProductDTO>()
            //    .ForMember(d => d.ProductTypeId, opt => opt.MapFrom(s => s.ProductType.Id))
            //    .ForMember(d => d.ProductTypeDesc, opt => opt.MapFrom(s => s.ProductType.Description))
            //    .ReverseMap()
            //    .ForMember(s => s.Id, opt => opt.Ignore())
            //    .ForMember(s => s.ProductType, opt => opt.Ignore());                

            CreateMap<Usuario, UsuarioDTO>()
                .IgnoreAllNonExisting()
                .ForMember(t => t.Nombre, opt => opt.MapFrom(s => s.DatosPersonales.Nombre))
                .ForMember(t => t.Apellido, opt => opt.MapFrom(s => s.DatosPersonales.Apellido))
                .ForMember(t => t.FechaNacimiento, opt => opt.MapFrom(s => s.DatosPersonales.FechaNacimiento))
                .ForMember(t => t.Telefono, opt => opt.MapFrom(s => s.DatosPersonales.Telefono))
                .ReverseMap()
                .ForMember(s => s.Id, opt => opt.Ignore());
        }        
    }

    
}
