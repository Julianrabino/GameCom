using GameCom.Model.Entities;
using GameCom.Model.Entities.Enums;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace GameCom.Repository.Mapping
{
    public class OfertaProductoMap : ClassMapping<OfertaProducto>
    {
        public OfertaProductoMap()
        {
            Table("oferta_producto");

            Id(b => b.Id, map =>
                {
                    map.Generator(Generators.Identity);
                    map.Column("IdOfertaProducto");
                });

            ManyToOne(b => b.Producto, mk =>
            {
                mk.Column("IdProducto");
                mk.NotNullable(true);
            });

            Property(b => b.VigenciaDesde, map =>
            {                       
                map.Column("FechaVigenciaDesde");
                map.NotNullable(true);
            });

            Property(b => b.VigenciaHasta, map =>
            {
                map.Column("FechaVigenciaHasta");
                map.NotNullable(true);
            });

            Property(b => b.PorcentajeDescuento, map =>
            {
                map.Column("PorcentajeDescuento");
                map.NotNullable(true);
            });
        }
    }
}
