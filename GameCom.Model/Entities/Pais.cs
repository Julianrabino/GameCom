using GameCom.Model.Base;

namespace GameCom.Model.Entities
{
    public class Pais : EntityBase<string>
    {        
        public virtual string Descripcion { get; set; }        
    }
}
