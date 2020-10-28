using GameCom.Model.Entities;
using GameCom.Repository.Repositories;
using GameCom.Service.Base;

namespace GameCom.Service.Services
{
    public class UsuarioService : BaseService<Usuario, int>
    {
        public UsuarioService(UsuarioRepository repository)
            : base(repository)
        {
        }
    }
}
