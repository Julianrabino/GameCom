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

            Id(x => x.Id, x =>
                {
                    x.Generator(Generators.Identity);
                    //x.Type(NHibernateUtil.Int64);
                    x.Column("IdProducto");
                });

            //Version(b => b.Version, x =>
            //{
            //    x.Column("Version");
            //});

            Property(b => b.Nombre, x =>
            {
                x.Length(100);
                //x.Type(NHibernateUtil.String);
                x.Column("Nombre");
                x.NotNullable(true);
            });

            Property(b => b.Descripcion, x =>
            {
                x.Length(255);
                //x.Type(NHibernateUtil.String);
                x.Column("Descripcion");
            });

            Property(b => b.TipoProducto, x =>
            {                
                //x.Type(NHibernateUtil.String);
                x.Column("TipoProducto");
            });

            //Discriminator(x =>
            //{
            //    x.Column("TipoProducto");
            //});
        }
    }
}
