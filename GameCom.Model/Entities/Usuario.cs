using GameCom.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCom.Model.Entities
{
    public class Usuario : EntityBase<int>, IVersionable
    {
        protected ISet<ProductoUsuario> productos;

        protected ISet<Usuario> solicitudesAmistadEnviadas;

        protected ISet<Usuario> solicitudesAmistadRecibidas;

        protected ISet<Usuario> amistades;
        

        public Usuario()
        {
            this.productos = new HashSet<ProductoUsuario>();
            this.solicitudesAmistadEnviadas = new HashSet<Usuario>();
            this.solicitudesAmistadRecibidas = new HashSet<Usuario>();
            this.amistades = new HashSet<Usuario>();
            this.DatosPersonales = new UsuarioDatosPersonales();
        }

        //public virtual int Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string Alias { get; set; }

        public virtual int Version { get; set; }

        public virtual UsuarioDatosPersonales DatosPersonales { get; set; }

        #region Productos
        public virtual IEnumerable<ProductoUsuario> Productos
        {
            get { return this.productos.AsEnumerable(); }
        }

        public virtual void AgregarProducto(ProductoUsuario producto)
        {
            this.productos.Add(producto);
            producto.Usuario = this;
        }

        public virtual void EliminarProducto(ProductoUsuario producto)
        {
            this.productos.Remove(producto);
            //producto.Usuario = null;
        }
        #endregion

        #region SolicitudesEnviadas
        public virtual IEnumerable<Usuario> SolicitudesAmistadEnviadas
        {
            get { return this.solicitudesAmistadEnviadas.AsEnumerable(); }
        }

        public virtual void EnviarSolicitudAmistad(Usuario usuario)
        {
            this.solicitudesAmistadEnviadas.Add(usuario);
            usuario.solicitudesAmistadRecibidas.Add(this);
        }

        public virtual void CancelarSolicitudAmistadEnviada(Usuario usuario)
        {
            this.solicitudesAmistadEnviadas.Remove(usuario);
            usuario.solicitudesAmistadRecibidas.Remove(this);
        }
        #endregion

        #region SolicitudesRecibidas
        public virtual IEnumerable<Usuario> SolicitudesAmistadRecibidas
        {
            get { return this.solicitudesAmistadRecibidas.AsEnumerable(); }
        }

        public virtual void AceptarSolicitudAmistad(Usuario usuario)
        {
            this.solicitudesAmistadRecibidas.Remove(usuario);
            usuario.solicitudesAmistadEnviadas.Remove(this);
            this.amistades.Add(usuario);
            usuario.amistades.Add(this);
        }

        public virtual void RechazarSolicitudAmistad(Usuario usuario)
        {
            this.solicitudesAmistadRecibidas.Remove(usuario);
            usuario.solicitudesAmistadEnviadas.Remove(this);
        }
        #endregion

        #region admistades
        public virtual IEnumerable<Usuario> Amistades
        {
            get { return this.amistades.AsEnumerable(); }
        }

        public virtual void EliminarAmistad(Usuario usuario)
        {
            this.amistades.Remove(usuario);
            usuario.amistades.Remove(this);
        }
        #endregion
    }
}
