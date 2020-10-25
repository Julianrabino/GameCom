using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

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

            Property(b => b.Productora, x =>
            {
                x.Length(100);
                //x.Type(NHibernateUtil.String);
                x.Column("Productora");
                x.NotNullable(true);
            });

            Property(b => b.Resenia, x =>
            {
                x.Column("Resenia");
            });

            Property(b => b.DuracionMinutos, x =>
            {
                x.Column("DuracionMinutos");
            });
        }
    }
}
