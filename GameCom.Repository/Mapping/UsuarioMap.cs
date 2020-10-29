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

            Component(b => b.DatosPersonales, map =>
            {
                map.Property(b => b.Nombre, c =>
                {
                    c.Length(100);
                    c.Column("Nombre");
                    c.NotNullable(true);
                });

                map.Property(b => b.Apellido, c =>
                {
                    c.Length(100);
                    c.Column("Apellido");
                    c.NotNullable(true);
                });

                map.Property(b => b.FechaNacimiento, c =>
                {
                    c.Column("FechaNacimiento");
                });

                map.Property(b => b.Telefono, c =>
                {
                    c.Length(45);
                    c.Column("Telefono");
                });
            });

            //Property(b => b.Nombre, map =>
            //{
            //    map.Length(100);
            //    map.Column("Nombre");
            //    map.NotNullable(true);
            //});

            //Property(b => b.Apellido, map =>
            //{
            //    map.Length(100);
            //    map.Column("Apellido");
            //    map.NotNullable(true);
            //});

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

            Set<Usuario>("solicitudesAmistadEnviadas", map =>
            {
                map.Table("usuario_solicitud_usuario");
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.Persist);
                map.Inverse(true);
                map.Key(k =>
                {
                    k.Column("IdUsuarioSolicitante");                    
                });
            },
            action => action.ManyToMany(k => k.Column("IdUsuarioSolicitado")));

            Set<Usuario>("solicitudesAmistadRecibidas", map =>
            {
                map.Table("usuario_solicitud_usuario");
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.Persist);
                map.Key(k =>
                {
                    k.Column("IdUsuarioSolicitado");
                });
            },
            action => action.ManyToMany(k => k.Column("IdUsuarioSolicitante")));


            Set<Usuario>("amistades", map =>
            {
                map.Table("usuario_amigo_usuario");
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.Persist);
                map.Key(k =>
                {
                    k.Column("IdUsuarioA");
                });
            },
           action => action.ManyToMany(k => k.Column("IdUsuarioB")));
        }
    }
}
