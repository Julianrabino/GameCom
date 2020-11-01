using GameCom.Model.Base;
using System;

namespace GameCom.Model.Entities
{
    public class LogroProductoUsuario : EntityBase<int>
    {
        public virtual Usuario Usuario { get; set; }

        public virtual LogroProducto Logro { get; set; }

        public virtual DateTime Fecha { get; set; }
    }
}
