using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

            //Discriminator(x =>
            //{
            //    x.Column("TipoProducto");
            //});
        }
    }
}
