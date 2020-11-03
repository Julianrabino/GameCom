using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class PrecioProductoMap : ClassMapping<PrecioProducto>
    {
        public PrecioProductoMap()
        {
            Table("precio_producto");

            Id(b => b.Id, map =>
                {
                    map.Generator(Generators.Identity);
                    map.Column("IdPrecioProducto");
                });

            ManyToOne(b => b.Producto, mk =>
            {
                mk.Column("IdProducto");
                mk.NotNullable(true);
            });

            ManyToOne(b => b.Pais, mk =>
            {
                mk.Column("CodigoPais");
                mk.NotNullable(false);
            });

            Property(b => b.FechaAlta, map =>
            {                
                map.Column("FechaAlta");
                map.NotNullable(true);
            });

            Property(b => b.Valor, map =>
            {
                map.Column("Valor");
                map.NotNullable(true);
            });
        }
    }
}
