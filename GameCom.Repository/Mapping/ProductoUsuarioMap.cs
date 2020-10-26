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

            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);                
                x.Column("IdUsuarioPoseeProducto");
            });

            Property(b => b.Usuario, x =>
            {
                x.Column("IdUsuario");
                x.NotNullable(true);
            });

            Property(b => b.Producto, x =>
            {
                x.Column("IdProducto");
                x.NotNullable(true);
            });

            Property(b => b.FechaAdquisicion, x =>
            {
                x.Column("FechaAdquisicion");
                x.NotNullable(true);
            });

            Property(b => b.MinutosUso, x =>
            {
                x.Column("TiempoUsoMinutos");
                x.NotNullable(true);
            });

            Property(b => b.Devuelto, x =>
            {
                x.Column("Devuelto");
                x.NotNullable(true);
                //x.Type(NHibernateUtil.tu);
            });            
        }
    }
}
