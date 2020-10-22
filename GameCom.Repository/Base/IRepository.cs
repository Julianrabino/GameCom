using GameCom.Model.Base;
using System.Collections.Generic;
using System.Linq;

namespace GameCom.Repository.Base
{
    public interface IRepository<TEntity, TIdEntity>
       where TEntity : class, IEntity<TIdEntity>
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(TIdEntity id);

        void Delete(TEntity entity);

        TEntity Save(TEntity entity);
    }
}
