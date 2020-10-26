using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Table("usuario");

            Id(b => b.Id, map =>
            {
                map.Generator(Generators.Identity);
                map.Column("IdUsuario");
            });

            Version(b => b.Version, map =>
            {
                map.Column("Version");
            });

            Property(b => b.Email, map =>
            {
                map.Length(100);
                map.Column("Email");
                map.NotNullable(true);
            });

            Property(b => b.Nombre, map =>
            {
                map.Length(100);
                map.Column("Nombre");
                map.NotNullable(true);
            });

            Property(b => b.Apellido, map =>
            {
                map.Length(100);
                map.Column("Apellido");
                map.NotNullable(true);
            });

            Property(b => b.Alias, map =>
            {
                map.Length(100);
                map.Column("Alias");
                map.NotNullable(true);
            });

            Set<ProductoUsuario>("productos", map =>
            {
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                map.Inverse(true);
                map.Key(k =>
                {
                    k.Column("IdUsuario");
                });
            },
            action => action.OneToMany());
        }
    }
}
