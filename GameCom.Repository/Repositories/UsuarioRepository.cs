using GameCom.Model.Entities;
using GameCom.Repository.Base;
using NHibernate;

namespace GameCom.Repository.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, int>
    {
        public UsuarioRepository(ISession dbSession)
            : base(dbSession)
        {
        }
    }
}
