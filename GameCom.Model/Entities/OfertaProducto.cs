using GameCom.Model.Base;
using System;

namespace GameCom.Model.Entities
{
    public class OfertaProducto: EntityBase<int>
    {
        public virtual Producto Producto { get; set; }

        public virtual DateTime VigenciaDesde { get; set; }

        public virtual DateTime VigenciaHasta { get; set; }

        public virtual decimal PorcentajeDescuento { get; set; }
    }
}
