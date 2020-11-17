using GameCom.Model.Entities;
using GameCom.Service.Base;

namespace GameCom.Service.Services.Interfaces
{
    public interface IUsuarioService: IService<Usuario, int>
    {
        void AgregarProducto(Usuario usuario, Producto producto);
    }
}
