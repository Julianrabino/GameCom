using GameCom.Common.Interceptors;
using GameCom.Model.Base;
using GameCom.Repository.Base;
using System.Collections.Generic;

namespace GameCom.Service.Base
{
    public class BaseService<TEntity, TIdEntity>: IService<TEntity, TIdEntity>
        where TEntity : class, IEntity<TIdEntity>
    {
        protected IRepository<TEntity, TIdEntity> Repository { get; set; }

        public BaseService(IRepository<TEntity, TIdEntity> repository)
        {
            this.Repository = repository;
        }

        [TransactionInterceptor]
        public virtual TEntity Create(TEntity entity)
        {
            return this.Repository.Create(entity);
        }

        [TransactionInterceptor]
        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.Repository.GetAll();
        }

        [TransactionInterceptor]
        public virtual TEntity Get(TIdEntity id)
        {
            return this.Repository.Get(id);
        }

        [TransactionInterceptor]
        public virtual void Delete(TEntity entity)
        {
            this.Repository.Delete(entity);
        }

        [TransactionInterceptor]
        public virtual TEntity Update(TEntity entity)
        {
            return this.Repository.Update(entity);
        }
    }
}
