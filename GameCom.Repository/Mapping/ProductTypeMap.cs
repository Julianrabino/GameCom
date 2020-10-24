using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class ProductTypeMap: ClassMapping<ProductType>
    {
        public ProductTypeMap()
        {
            //DynamicUpdate(false);
            //OptimisticLock(OptimisticLockMode.Version);

            Table("producttype");

            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                //x.Type(NHibernateUtil.Int64);
                x.Column("Id");
            });

            Version(b => b.Version, x =>
            {
                x.Column("Version");
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
        }
    }
}
