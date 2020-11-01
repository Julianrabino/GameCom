using GameCom.Model.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System.Security.Cryptography;

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
            });

            ManyToOne(b => b.Logro, map =>
            {
                map.Columns(c1 =>
                {
                    c1.Name("IdProducto");
                }, c2 =>
                {
                    c2.Name("CodigoLogro");
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
