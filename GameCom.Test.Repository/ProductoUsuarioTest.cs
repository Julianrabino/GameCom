using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Criterion;
using System;
using System.Linq;

namespace GameCom.Test.Repository
{
    [TestClass]
    public class ProductoUsuarioTest : BaseTestRepository
    {

        [TestMethod]
        public void TestInsertLogroVideoJuegoAUsuario()
        {
            var usuario = this.DbSession.Get<Usuario>(1);
            var juegoUsuario = usuario.Productos.Where(p => (p.Producto is VideoJuego) && (p.Producto as VideoJuego).Nombre == "Flight Simualtor").First();
            //var juegoUsuario = usuario.Productos.Where(p => p.Producto.Id == 5).First();
            var primerLogro = (juegoUsuario.Producto as VideoJuego).Logros.First();
            juegoUsuario.AgregarLogro(new LogroProductoUsuario
            {
                Fecha = DateTime.Now,
                Logro = primerLogro
            });

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(juegoUsuario);
            tx.Commit();
        }
    }
}
