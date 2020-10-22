using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCom.Api
{
    public class ProductTypeMap: ClassMapping<ProductType>
    {
        public ProductTypeMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                //x.Type(NHibernateUtil.Int64);
                x.Column("Id");                
            });

            Property(b => b.Initials, x =>
            {
                x.Length(5);
                //x.Type(NHibernateUtil.String);
                x.Column("Initials");
                x.NotNullable(true);
            });

            Property(b => b.Description, x =>
            {
                x.Length(100);
                //x.Type(NHibernateUtil.String);
                x.Column("Description");
                x.NotNullable(true);
            });

            Table("producttype");
        }
    }
}
