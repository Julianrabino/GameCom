using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class LogroProductoUsuarioMap : ClassMapping<LogroProductoUsuario>
    {
        public LogroProductoUsuarioMap()
        {            
            Table("usuario_producto_logro");

            Id(b => b.Id, map =>
            {
                map.Generator(Generators.Identity);                
                map.Column("IdUsuarioProductoLogro");
            });

            ManyToOne(b => b.Usuario, map =>
            {
                map.Column("IdUsuario");
                map.NotNullable(true);
            });

            ManyToOne(b => b.Logro, map =>
            {
                map.Columns(c1 =>
                {
                    c1.Name("IdProducto");
                    c1.NotNullable(true);
                }, c2 =>
                {
                    c2.Name("CodigoLogro");
                    c2.NotNullable(true);
                });
                
            });

            Property(b => b.Fecha, mpa =>
            {
                mpa.Column("FechaAlta");
                mpa.NotNullable(true);
            });
        }
    }
}
