using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GameCom.Test.Repository
{
    [TestClass]
    public class UsuarioTest: BaseTestRepository
    {

        [TestMethod]
        public void TestGetUsuario()
        {
            var usuario = this.DbSession.Get<Usuario>(1);
            Assert.IsTrue(usuario.Productos.Any());
        }

        [TestMethod]
        public void TestInsertProductoAUsuario()
        {
            var usuario = this.DbSession.Get<Usuario>(1);

            var producto = new ProductoUsuario
            {                
                Producto = 1,
                Devuelto = false,
                FechaAdquisicion = DateTime.Now,
                MinutosUso = 0
            };

            usuario.AgregarProducto(producto);

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(usuario);
            tx.Commit();
        }

        [TestMethod]
        public void TestEliminarProductoAUsuario()
        {
            var usuario = this.DbSession.Get<Usuario>(1);
            var producto = usuario.Productos.FirstOrDefault(p => p.Id == 2);
            usuario.EliminarProducto(producto);

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(usuario);
            tx.Commit();
        }


        [TestMethod]
        public void TestInsertUsuario()
        {
            var be = new Usuario
            {
                Email = "JulianCesar18@hotmail.com",
                Nombre = "Julian",
                Apellido = "Rabino",
                Alias = "Joncito"
            };

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(be);
            tx.Commit();
        }

        [TestMethod]
        public void TestInsertProductoUsuario()
        {
            //var be = new ProductoUsuario
            //{
            //    Usuario = 1,
            //    Producto = 1,
            //    Devuelto = false,
            //    FechaAdquisicion = DateTime.Today,
            //    MinutosUso = 0
            //};

            //using var tx = this.DbSession.BeginTransaction();
            //this.DbSession.Save(be);
            //tx.Commit();
        }

        [TestMethod]
        public void TestUpdateProductoUsuario()
        {
            var be = this.DbSession.Get<ProductoUsuario>(1);
            be.FechaAdquisicion = DateTime.Now;
            be.Devuelto = true;
            be.MinutosUso = 60;
            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Update(be);
            tx.Commit();
        }
    }
}
