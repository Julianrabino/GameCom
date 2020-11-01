using GameCom.Model.Base;
using System.Collections.Generic;
using System.Linq;

namespace GameCom.Model.Entities
{
    public class Producto: EntityBase<int>, IVersionable
    {
        protected ISet<GeneroProducto> generos;

        protected ISet<ReseniaProducto> resenias;

        public Producto()
        {
            this.generos = new HashSet<GeneroProducto>();
            this.resenias = new HashSet<ReseniaProducto>();
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


        #region Resenias
        public virtual IEnumerable<ReseniaProducto> Resenias
        {
            get { return this.resenias.AsEnumerable(); }
        }

        public virtual void AgregarResenia(ReseniaProducto resenia)
        {
            this.resenias.Add(resenia);
            resenia.Producto = this;
        }

        public virtual void EliminarResenia(ReseniaProducto resenia)
        {
            this.resenias.Remove(resenia);
        }
        #endregion
    }
}
