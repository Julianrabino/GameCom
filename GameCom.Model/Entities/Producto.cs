using GameCom.Model.Base;

namespace GameCom.Model.Entities
{
    public class Producto: EntityBase<int>, IVersionable
    {        
        public virtual string Nombre { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual int Version { get; set; }
    }
}
