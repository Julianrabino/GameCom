using GameCom.Model.Base;
using GameCom.Model.Entities.Enums;

namespace GameCom.Model.Entities
{
    public class Pais : EntityBase<string>
    {        
        public virtual string Descripcion { get; set; }        
    }
}
