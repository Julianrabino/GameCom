using GameCom.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCom.Model.Entities
{
    public class Producto: IEntity<int>
    {
        public virtual int Id { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual int TipoProducto { get; set; }
    }
}
