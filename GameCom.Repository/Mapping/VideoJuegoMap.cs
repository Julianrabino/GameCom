using GameCom.Model.Entities;
using NHibernate;
using NHibernate.Mapping;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCom.Repository.Mapping
{
    public class VideoJuegoMap : JoinedSubclassMapping<VideoJuego>
    {
        public VideoJuegoMap()
        {
            Key(x =>
            {
                x.Column("IdVideoJuego");                
            });            

            Property(b => b.Desarroladora, x =>
            {
                x.Length(100);
                //x.Type(NHibernateUtil.String);
                x.Column("Desarrolladora");
                x.NotNullable(true);
            });

            Property(b => b.RequerimientosMinimos, x =>
            {
                x.Column("RequerimientosMinimos");
            });

            Property(b => b.RequerimientosRecomendados, x =>
            {
                x.Column("RequerimientosRecomendados");
            });            
        }
    }
}
