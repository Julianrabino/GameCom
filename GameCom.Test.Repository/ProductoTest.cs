using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameCom.Test.Repository
{
    [TestClass]
    public class ProductoTest: BaseTestRepository
    {
        [TestMethod]
        public void TestInsertPelicula()
        {
            var pelicula = new Pelicula
            {
                Nombre = "La Máscara",
                Descripcion = "Pelicula la máscara",
                Resenia = "Un perdedor encuentra una máscara que le cambiará la vida",
                Productora = "Warner",
                DuracionMinutos = 115
            };

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(pelicula);
            tx.Commit();
        }

        [TestMethod]
        public void TestUodatePelicula()
        {
            var pelicula = this.DbSession.Get<Pelicula>(3);            
            pelicula.Descripcion += "ED";
            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Update(pelicula);
            tx.Commit();
        }
    }
}
