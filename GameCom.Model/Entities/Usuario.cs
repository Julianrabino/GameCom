﻿using GameCom.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCom.Model.Entities
{
    public class Usuario : EntityBase<int>, IVersionable
    {
        protected ISet<ProductoUsuario> productos;

        public Usuario()
        {
            this.productos = new HashSet<ProductoUsuario>();
        }

        //public virtual int Id { get; set; }

        public virtual string Email { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Apellido { get; set; }

        public virtual string Alias { get; set; }

        public virtual int Version { get; set; }        

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
    }
}