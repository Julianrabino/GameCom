using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameCom.Test.Repository
{
    [TestClass]
    public class UsuarioTest: BaseTestRepository
    {
        [TestMethod]
        public void TestInsertUsuario()
        {
            var be = new Usuario
            {
                Email = "Julianrabino@gmail.com",
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
            var be = new ProductoUsuario
            {
                Usuario = 1,
                Producto = 1,
                Devuelto = false,
                FechaAdquisicion = DateTime.Today,
                MinutosUso = 0
            };

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(be);
            tx.Commit();
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
