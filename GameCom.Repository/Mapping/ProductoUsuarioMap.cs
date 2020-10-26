using GameCom.Model.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class ProductoUsuarioMap : ClassMapping<ProductoUsuario>
    {
        public ProductoUsuarioMap()
        {            
            Table("usuario_posee_producto");

            Id(b => b.Id, mpa =>
            {
                mpa.Generator(Generators.Identity);                
                mpa.Column("IdUsuarioPoseeProducto");
            });

            //Property(b => b.Usuario, x =>
            //{
            //    x.Column("IdUsuario");
            //    x.NotNullable(true);
            //});

            ManyToOne(b => b.Usuario, map =>
            {
                map.Column("IdUsuario");
            });

            //Property(b => b.Producto, map =>
            //{
            //    map.Column("IdProducto");
            //    map.NotNullable(true);
            //});

            ManyToOne(b => b.Producto, map =>
            {
                map.Column("IdProducto");
            });

            Property(b => b.FechaAdquisicion, mpa =>
            {
                mpa.Column("FechaAdquisicion");
                mpa.NotNullable(true);
            });

            Property(b => b.MinutosUso, map =>
            {
                map.Column("TiempoUsoMinutos");
                map.NotNullable(true);
            });

            Property(b => b.Devuelto, map =>
            {
                map.Column("Devuelto");
                map.NotNullable(true);
            });            
        }
    }
}
