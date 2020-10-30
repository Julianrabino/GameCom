using GameCom.Model.Base;
using GameCom.Model.Entities.Enums;

namespace GameCom.Model.Entities
{
    public class GeneroProducto: EntityBase<string>
    {        
        public virtual string Descripcion { get; set; }
        
        public virtual TipoProductoGenero TipoProductoAplica { get; set; }
    }
}
