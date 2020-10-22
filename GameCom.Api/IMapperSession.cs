using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCom.Api
{
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(ProductType entity);
        Task Delete(ProductType entity);

        IQueryable<ProductType> ProductTypes { get; }
    }
}
