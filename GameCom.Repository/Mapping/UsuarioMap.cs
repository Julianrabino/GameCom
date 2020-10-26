using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class UsuarioMap: ClassMapping<Usuario>
    {
        public UsuarioMap()
        {            
            Table("usuario");

            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);                
                x.Column("IdUsuario");
            });

            Version(b => b.Version, x =>
            {
                x.Column("Version");
            });

            Property(b => b.Email, x =>
            {
                x.Length(100);
                x.Column("Email");
                x.NotNullable(true);
            });

            Property(b => b.Nombre, x =>
            {
                x.Length(100);
                x.Column("Nombre");
                x.NotNullable(true);
            });

            Property(b => b.Apellido, x =>
            {
                x.Length(100);
                x.Column("Apellido");
                x.NotNullable(true);
            });

            Property(b => b.Alias, x =>
            {
                x.Length(100);
                x.Column("Alias");
                x.NotNullable(true);
            });
        }
    }
}
