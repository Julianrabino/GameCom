using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class ReseniaProductoMap : ClassMapping<ReseniaProducto>
    {
        public ReseniaProductoMap()
        {
            Table("resenia_producto");

            Id(b => b.Id, map =>
                {
                    map.Generator(Generators.Identity);
                    map.Column("IdResenia");
                });

            ManyToOne(b => b.Producto, map =>
            {
                map.Column("IdProducto");
                map.NotNullable(true);
            });

            ManyToOne(b => b.Usuario, map =>
            {
                map.Column("IdUsuario");
                map.NotNullable(true);
            });

            Property(b => b.Titulo, map =>
            {
                map.Column("Titulo");
                map.Length(45);
                map.NotNullable(true);
            });

            Property(b => b.Cuerpo, map =>
            {
                map.Column("Cuerpo");
                map.NotNullable(true);
            });

            Property(b => b.MinutosUsoUsuario, map =>
            {
                map.Column("MinutosUsoUsuario");
                map.NotNullable(true);
            });

            Property(b => b.Recomendado, map =>
            {
                map.Column("Recomendado");
                map.NotNullable(true);
            });
        }
    }
}
