using GameCom.Model.Entities;
using GameCom.Repository.Repositories;
using GameCom.Service.Base;
using GameCom.Service.Services.Interfaces;

namespace GameCom.Service.Services
{
    public class ProductoService : BaseService<Producto, int>, IProductoService
    {
        public ProductoService(ProductoRepository repository)
            : base(repository)
        {
        }
    }
}
