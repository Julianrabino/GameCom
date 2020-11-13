using GameCom.Model.Entities;
using GameCom.Model.Entities.Enums;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace GameCom.Repository.Mapping
{
    public class GeneroProductoMap : ClassMapping<GeneroProducto>
    {
        public GeneroProductoMap()
        {
            Table("genero");

            Id(b => b.Id, map =>
            {
                map.Generator(Generators.Assigned);
                map.Column("CodigoGenero");
            });            

            Property(b => b.Descripcion, map =>
            {
                map.Length(100);                
                map.Column("Descripcion");
                map.NotNullable(true);
            });

            Property(b => b.TipoProductoAplica, map =>
            {
                map.Column("TipoGenero");
                map.Type<EnumType<TipoProductoGenero>>();
            });
        }
    }
}
