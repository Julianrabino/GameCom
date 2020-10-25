using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameCom.Test.Repo
{
    [TestClass]
    public class ProductTypeTest: BaseTestRepository
    {        
        //[TestMethod]
        public void TestInsert()
        {            
            var productoType = new ProductType
            {
                Initials = "TPR",
                Description = "Prueba desde test"
            };

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(productoType);
            tx.Commit();
        }
    }
}
