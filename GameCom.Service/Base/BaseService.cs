using GameCom.Model.Base;
using GameCom.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCom.Service.Base
{
    public class BaseService<TEntity, TIdEntity>
        where TEntity : class, IEntity<TIdEntity>
    {
        protected IRepository<TEntity, TIdEntity> Repository { get; set; }

        public BaseService(IRepository<TEntity, TIdEntity> repository)
        {
            this.Repository = repository;
        }

        public TEntity Create(TEntity entity)
        {
            return this.Repository.Save(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.Repository.GetAll();
        }

        public TEntity Get(TIdEntity id)
        {
            return this.Repository.Get(id);
        }

        public void Delete(TEntity entity)
        {
            this.Repository.Delete(entity);
        }

        public TEntity Update(TEntity entity)
        {
            return this.Repository.Save(entity);
        }
    }
}
