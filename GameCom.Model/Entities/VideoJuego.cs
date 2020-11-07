using System.Collections.Generic;
using System.Linq;

namespace GameCom.Model.Entities
{
    public class VideoJuego: Producto
    {
        private ICollection<LogroProducto> logros;

        public VideoJuego(): base()
        {
            this.logros = new List<LogroProducto>();
        }

        public virtual string Desarroladora { get; set; }

        public virtual string RequerimientosMinimos { get; set; }

        public virtual string RequerimientosRecomendados { get; set; }

        #region logros
        public virtual IEnumerable<LogroProducto> Logros
        {
            get { return this.logros.AsEnumerable(); }
        }

        public virtual void AgregaraLogro(LogroProducto logro)
        {            
            this.logros.Add(logro);
            logro.Producto = this;
        }

        public virtual void EliminarLogro(LogroProducto logro)
        {
            this.logros.Remove(logro);
        }
        #endregion
    }
}
