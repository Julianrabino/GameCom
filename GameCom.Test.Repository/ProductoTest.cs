using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameCom.Test.Repository
{
    [TestClass]
    public class ProductoTest: BaseTestRepository
    {
        [TestMethod]
        public void TestInsert()
        {
            var pelicula = new Pelicula
            {
                Nombre = "Lo que el viento se llevó",
                Descripcion = "Pelicula lo que el viento se llevó",
                Resenia = "Una mujer que da todo por amor",
                TipoProducto = 1,
                Productora = "Warner",
                DuracionMinutos = 190
            };

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(pelicula);
            tx.Commit();
        }

        [TestMethod]
        public void TestUodate()
        {
            var pelicula = this.DbSession.Get<Pelicula>(1);
            pelicula.Descripcion += "ED";
            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Update(pelicula);
            tx.Commit();
        }
    }
}
