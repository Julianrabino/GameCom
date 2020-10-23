using GameCom.Common.Interceptors;
using GameCom.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCom.Service.Base
{
    public interface IService<TEntity, TIdEntity>
        where TEntity : class, IEntity<TIdEntity>
    {
        TEntity Create(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity Get(TIdEntity id);

        void Delete(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
