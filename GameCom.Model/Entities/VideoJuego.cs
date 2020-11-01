using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GameCom.Model.Entities
{
    public class VideoJuego: Producto
    {
        private ISet<LogroProducto> logros;

        public VideoJuego(): base()
        {
            this.logros = new HashSet<LogroProducto>();
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
            logro.Id.Producto = this;
            this.logros.Add(logro);
        }

        public virtual void EliminarLogro(LogroProducto logro)
        {
            this.logros.Remove(logro);
        }
        #endregion
    }
}
