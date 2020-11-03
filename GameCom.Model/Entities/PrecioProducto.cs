using GameCom.Model.Base;
using System;

namespace GameCom.Model.Entities
{
    public class PrecioProducto : EntityBase<int>
    {
        public  virtual Producto Producto { get; set; }

        public virtual Pais Pais { get; set; }

        public virtual DateTime FechaAlta { get; set; }

        public virtual decimal Valor { get; set; }
    }
}
