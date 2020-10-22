using GameCom.Model.Entities;
using GameCom.Repository.Base;
using NHibernate;

namespace GameCom.Repository.Repositories
{
    public class ProductTypeRepository : BaseRepository<ProductType, int>
    {
        public ProductTypeRepository(ISession dbSession)
            : base(dbSession)
        {
        }
    }
}
