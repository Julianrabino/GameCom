using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameCom.Test.Repository
{
    [TestClass]
    public class PaisTest : BaseTestRepository
    {
        [TestMethod]
        public void TestInsert()
        {
            var be = new Pais
            {
                Id = "ARG",
                Descripcion = "Argentina",                
            };

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(be);
            tx.Commit();
        }

        [TestMethod]
        public void TestUpdatePais()
        {
            var be = this.DbSession.Get<Pais>("ARG");
            be.Descripcion += " ED";
            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Update(be);
            tx.Commit();
        }
    }
}
