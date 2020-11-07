using GameCom.Model.Base;
using System.Collections.Generic;
using System.Linq;

namespace GameCom.Model.Entities
{
    public class Producto: EntityBase<int>, IVersionable
    {
        protected ISet<GeneroProducto> generos;

        protected ISet<ReseniaProducto> resenias;

        protected ICollection<PrecioProducto> precios;

        protected ICollection<OfertaProducto> ofertas;

        public Producto()
        {
            this.generos = new HashSet<GeneroProducto>();
            this.resenias = new HashSet<ReseniaProducto>();
            this.precios = new List<PrecioProducto>();
            this.ofertas = new List<OfertaProducto>();
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

        #region Precios
        public virtual IEnumerable<PrecioProducto> Precios
        {
            get { return this.precios.AsEnumerable(); }
        }

        public virtual void AgregarPrecio(PrecioProducto precio)
        {
            this.precios.Add(precio);
            precio.Producto = this;
        }

        public virtual void EliminarPrecio(PrecioProducto precio)
        {
            this.precios.Remove(precio);            
        }
        #endregion

        #region ofertas
        public virtual IEnumerable<OfertaProducto> Ofertas
        {
            get { return this.ofertas.AsEnumerable(); }
        }

        public virtual void AgregarOferta(OfertaProducto oferta)
        {
            this.ofertas.Add(oferta);
            oferta.Producto = this;
        }

        public virtual void EliminarOferta(OfertaProducto oferta)
        {
            this.ofertas.Remove(oferta);
        }
        #endregion
    }
}
