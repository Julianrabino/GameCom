using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class ProductoMap : ClassMapping<Producto>
    {
        public ProductoMap()
        {
            Table("producto");

            Id(b => b.Id, map =>
            {
                map.Generator(Generators.Identity);
                map.Column("IdProducto");
            });

            Version(b => b.Version, map =>
            {
                map.Column("Version");
            });

            Property(b => b.Nombre, map =>
            {
                map.Length(100);
                map.Column("Nombre");
                map.NotNullable(true);
            });

            Property(b => b.Descripcion, map =>
            {
                map.Length(255);
                map.Column("Descripcion");
            });

            Bag<GeneroProducto>("generos", map =>
            {
                map.Table("producto_genero");
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.Persist);
                map.Key(k =>
                {
                    k.Column("IdProducto");
                });
            },
            action => action.ManyToMany(k => k.Column("CodigoGenero")));

            Bag<ReseniaProducto>("resenias", map =>
            {
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                map.Inverse(true);
                map.Key(k =>
                {
                    k.Column("IdProducto");
                });
            },
            action => action.OneToMany());

            Bag<PrecioProducto>("precios", map =>
            {
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                map.Inverse(true);
                map.Key(k =>
                {
                    k.Column("IdProducto");
                });
            },
            action => action.OneToMany());

            Bag<OfertaProducto>("ofertas", map =>
            {
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                map.Inverse(true);
                map.Key(k =>
                {
                    k.Column("IdProducto");
                });
            },
            action => action.OneToMany());

            //Discriminator(x =>
            //{
            //    x.Column("TipoProducto");
            //});
        }
    }
}
