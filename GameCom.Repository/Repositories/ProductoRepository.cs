using GameCom.Model.Entities;
using GameCom.Repository.Base;
using NHibernate;

namespace GameCom.Repository.Repositories
{
    public class ProductoRepository : BaseRepository<Producto, int>
    {
        public ProductoRepository(ISession dbSession)
            : base(dbSession)
        {
        }
    }
}
