using GameCom.Model.Base;
using GameCom.Repository.Exceptions;
using NHibernate;
using System.Linq;

namespace GameCom.Repository.Base
{
    public class BaseRepository<TEntity, TIdEntity> : IRepository<TEntity, TIdEntity>
        where TEntity : class, IEntity<TIdEntity>
    {
        protected ISession DbSession { get; set; }

        public BaseRepository(ISession DbSession)
        {
            this.DbSession = DbSession;
        }       

        public IQueryable<TEntity> GetAll()
        {
            return this.DbSession.Query<TEntity>();
        }

        public TEntity Get(TIdEntity id)
        {
            var result = this.DbSession.Get<TEntity>(id);
            if (result == null)
                throw new RepositoryException(string.Format("No existe la entidad ({0}) para el identificador {1}", typeof(TEntity).Name, id.ToString()));
            return result;
        }

        public void Delete(TEntity entity)
        {
            this.DbSession.Delete(entity);
        }

        public TEntity Create(TEntity entity)
        {
            this.DbSession.Save(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            this.DbSession.Update(entity);
            return entity;
        }
    }
}
