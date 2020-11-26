using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class PeliculaMap : JoinedSubclassMapping<Pelicula>
    {
        public PeliculaMap()
        {
            Key(x =>
            {
                x.Column("IdPelicula");
            });

            Property(b => b.Productora, map =>
            {
                map.Length(100);
                map.Column("Productora");
                map.NotNullable(true);
            });

            Property(b => b.Resenia, map =>
            {
                map.Column("Resenia");
            });

            Property(b => b.DuracionMinutos, map =>
            {
                map.Column("DuracionMinutos");
            });
        }
    }
}
