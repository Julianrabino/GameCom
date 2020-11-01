using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class LogroProductoMap : ClassMapping<LogroProducto>
    {
        public LogroProductoMap()
        {
            Table("logro");

            ComponentAsId(b => b.Id, map =>
            {
                //map.Property(p => p.Producto, mk =>
                //{
                //    mk.Column("IdProducto");
                //});

                map.ManyToOne(b => b.Producto, mk =>
                {
                    mk.Column("IdProducto");
                });

                map.Property(p => p.Codigo, mk =>
                {
                    mk.Column("Codigo");
                });
            });

            Property(b => b.Descripcion, map =>
            {
                map.Length(100);
                map.Column("Descripcion");
                map.NotNullable(true);
            });
        }
    }
}
