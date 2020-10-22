using GameCom.Model.Entities;
using GameCom.Repository.Repositories;
using GameCom.Service.Base;

namespace GameCom.Service.Services
{
    public class ProductTypeService : BaseService<ProductType, int>
    {
        public ProductTypeService(ProductTypeRepository repository)
            : base(repository)
        {
        }
    }
}
