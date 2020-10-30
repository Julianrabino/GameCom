using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameCom.Test.Repository
{
    [TestClass]
    public class GeneroProductoTest : BaseTestRepository
    {
        [TestMethod]
        public void TestInsertGenero()
        {
            var be = new GeneroProducto
            {
                Id = "VSIM",
                Descripcion = "Simuladores",
                TipoProductoAplica = Model.Entities.Enums.TipoProductoGenero.VideoJuego
            };

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(be);
            tx.Commit();
        }

        [TestMethod]
        public void TestUpdatePelicula()
        {
            var be = this.DbSession.Get<GeneroProducto>("VSIM");            
            be.Descripcion += " ED";
            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Update(be);
            tx.Commit();
        }
    }
}
