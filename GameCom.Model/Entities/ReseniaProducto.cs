using GameCom.Model.Base;

namespace GameCom.Model.Entities
{
    public class ReseniaProducto : EntityBase<int>
    {
        public virtual Producto Producto { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual string Titulo { get; set; }

        public virtual string Cuerpo { get; set; }

        public virtual int MinutosUsoUsuario { get; set; }

        public virtual bool Recomendado { get; set; }
    }
}
