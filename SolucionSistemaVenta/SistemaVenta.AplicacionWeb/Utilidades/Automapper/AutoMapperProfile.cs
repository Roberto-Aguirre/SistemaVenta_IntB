
using SistemaVenta.AplicacionWeb.Models.ViewModels;
using SistemaVenta.Entity;
using System.Globalization;
using AutoMapper;


namespace SistemaVenta.AplicacionWeb.Utildiades.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            #region Rol
            CreateMap<Rol,VMRol>().ReverseMap();
            #endregion

            #region Usuario
            CreateMap<Usuario, VMUsuario>()
                .ForMember(destino =>
                destino.EsActivo,
                opt => opt.MapFrom(origen => origen.EsActivo == true ? 1 : 0))
                .ForMember(destino => destino.NombreRol, opt => opt.MapFrom(origen => origen.IdRolNavigation.Descripcion)
                
                );

            CreateMap<VMUsuario, Usuario>()
                .ForMember(destino => destino.EsActivo, opt => opt.MapFrom(origen => origen.EsActivo == 1 ? true : false))
                .ForMember(destino => destino.IdRolNavigation, opt => opt.Ignore());
            #endregion

            #region Negocio

            CreateMap<Negocio,VMNegocio>()
                .ForMember(destino=>destino.PorcentajeImpuesto,opt=>opt.MapFrom(origen=>Convert.ToString(origen.PorcentajeImpuesto.Value,new CultureInfo("es-MX"))));

            CreateMap<VMNegocio, Negocio>()
                .ForMember(destino => destino.PorcentajeImpuesto, obt => obt.MapFrom(origen=>Convert.ToDecimal(origen.PorcentajeImpuesto,new CultureInfo("es-MX"))));

            #endregion

            #region Producto

            #endregion

        }


    }
}
