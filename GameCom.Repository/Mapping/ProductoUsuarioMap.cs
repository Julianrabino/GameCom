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

            ComponentAsId(b => b.Id, map =>
            {
                map.ManyToOne(b => b.Usuario, mk =>
                {
                    mk.Column("IdUsuario");
                });

                map.ManyToOne(b => b.Producto, mk =>
                {
                    mk.Column("IdProducto");
                    mk.Lazy(LazyRelation.NoProxy);
                });
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

            Bag<LogroProductoUsuario>("logros", map =>
            {
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                map.Inverse(true);
                map.Key(k =>
                {
                    k.Columns(
                        c1 => c1.Name("IdUsuario"),
                        c2 => c2.Name("IdProducto")
                    );
                    //k.ForeignKey
                });
            },
            action => action.OneToMany());
        }
    }
}
