using GameCom.Model.Base;
using System.Collections.Generic;
using System.Linq;

namespace GameCom.Model.Entities
{
    public class Producto: EntityBase<int>, IVersionable
    {
        protected ISet<GeneroProducto> generos;

        public Producto()
        {
            this.generos = new HashSet<GeneroProducto>();
        }

        public virtual string Nombre { get; set; }

        public virtual string Descripcion { get; set; }

        public virtual int Version { get; set; }

        #region Generos
        public virtual IEnumerable<GeneroProducto> Generos
        {
            get { return this.generos.AsEnumerable(); }
        }

        public virtual void AgregarGenero(GeneroProducto genero)
        {
            this.generos.Add(genero);
        }

        public virtual void EliminarGenero(GeneroProducto genero)
        {
            this.generos.Remove(genero);
        }
        #endregion
    }
}
