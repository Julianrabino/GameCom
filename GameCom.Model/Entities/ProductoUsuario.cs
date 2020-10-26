using GameCom.Model.Base;
using System;

namespace GameCom.Model.Entities
{
    public class ProductoUsuario : EntityBase<int>
    {
        //public virtual int Id { get; set; }

        public virtual int Usuario { get; set; }

        //public virtual Usuario Usuario { get; set; }

        public virtual int Producto { get; set; }

        //public virtual Producto Producto { get; set; }

        public virtual DateTime FechaAdquisicion { get; set; }

        public virtual int MinutosUso { get; set; }

        public virtual bool Devuelto { get; set; }
    }
}
