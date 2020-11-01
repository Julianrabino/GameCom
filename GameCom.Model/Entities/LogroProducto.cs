using GameCom.Model.Base;
using System;
using System.Runtime.InteropServices;

namespace GameCom.Model.Entities
{
    public class LogroProducto : EntityBase<IdLogroProducto>
    {
        public LogroProducto(string codigo): this()
        {
            this.Id.Codigo = codigo;
        }

        public LogroProducto()
        {
            this.Id = new IdLogroProducto();
        }

        public virtual string Descripcion { get; set; }
    }
}
