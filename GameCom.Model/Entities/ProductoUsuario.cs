using GameCom.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCom.Model.Entities
{
    public class ProductoUsuario : EntityBase<IdProductoUsuario>
    {
        private ICollection<LogroProductoUsuario> logros;

        public ProductoUsuario()
        {
            this.Id = new IdProductoUsuario();
            this.logros = new List<LogroProductoUsuario>();
        }

        #region indirecciones a ID
        public virtual Usuario Usuario
        {
            get { return this.Id.Usuario; }
            set { this.Id.Usuario = value; }
        }

        public virtual Producto Producto
        {
            get { return this.Id.Producto; }
            set { this.Id.Producto = value; }
        }
        #endregion

        public virtual DateTime FechaAdquisicion { get; set; }

        public virtual int MinutosUso { get; set; }

        public virtual bool Devuelto { get; set; }

        #region logros
        public virtual IEnumerable<LogroProductoUsuario> Logros
        {
            get { return this.logros.AsEnumerable(); }
        }

        public virtual void AgregarLogro(LogroProductoUsuario logroProducto)
        {            
            this.logros.Add(logroProducto);
            logroProducto.Usuario = this.Usuario;
        }

        public virtual void EliminarLogro(LogroProductoUsuario logro)
        {
            this.logros.Remove(logro);
        }
        #endregion
    }
}
