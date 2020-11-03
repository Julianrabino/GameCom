using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class PaisMap : ClassMapping<Pais>
    {
        public PaisMap()
        {
            Table("pais");

            Id(b => b.Id, map =>
                {
                    map.Generator(Generators.Assigned);
                    map.Column("Codigo");
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
