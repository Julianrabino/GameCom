using System;
using System.Collections.Generic;
using System.Text;

namespace GameCom.Model.Entities
{
    public class VideoJuego: Producto
    {
        public virtual string Desarroladora { get; set; }

        public virtual string RequerimientosMinimos { get; set; }

        public virtual string RequerimientosRecomendados { get; set; }
    }
}
