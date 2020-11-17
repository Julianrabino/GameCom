using GameCom.Model.Entities;
using GameCom.Repository.Base;
using GameCom.Service.Base;
using GameCom.Service.Services.Interfaces;
using System;

namespace GameCom.Service.Services
{
    public class UsuarioService : BaseService<Usuario, int>, IUsuarioService
    {
        public UsuarioService(IRepository<Usuario, int> repository)
            : base(repository)
        {
        }

        public void AgregarProducto(Usuario usuario, Producto producto)
        {
            var productoUsuario = new ProductoUsuario
            {
                Id = new IdProductoUsuario
                {
                    Producto = producto
                },
                FechaAdquisicion = DateTime.Now
            };

            usuario.AgregarProducto(productoUsuario);
        }
    }
}
