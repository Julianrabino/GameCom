﻿using GameCom.Model.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace GameCom.Repository.Mapping
{
    public class VideoJuegoMap : JoinedSubclassMapping<VideoJuego>
    {
        public VideoJuegoMap()
        {
            Key(b =>
            {
                b.Column("IdVideoJuego");                
            });            

            Property(b => b.Desarroladora, map =>
            {
                map.Length(100);
                map.Column("Desarrolladora");
                map.NotNullable(true);
            });

            Property(b => b.RequerimientosMinimos, map =>
            {
                map.Column("RequerimientosMinimos");
            });

            Property(b => b.RequerimientosRecomendados, map =>
            {
                map.Column("RequerimientosRecomendados");
            });

            Bag<LogroProducto>("logros", map =>
            {
                map.Access(Accessor.Field);
                map.Lazy(CollectionLazy.Lazy);
                map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                map.Inverse(true);
                map.Key(k =>
                {
                    k.Column("IdProducto");
                });
            },
            action => action.OneToMany());
        }
    }
}
