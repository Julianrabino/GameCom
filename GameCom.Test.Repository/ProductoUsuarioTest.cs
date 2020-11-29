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
            var segundoLogro = (juegoUsuario.Producto as VideoJuego).Logros.First(l => l.Codigo == "002");
            juegoUsuario.AgregarLogro(new LogroProductoUsuario
            {
                Fecha = DateTime.Now,
                Logro = segundoLogro
            });

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(juegoUsuario);
            tx.Commit();
        }


        [TestMethod]
        public void TestEliminarLogroVideoJuegoAUsuario()
        {
            var usuario = this.DbSession.Get<Usuario>(1);
            var juegoUsuario = usuario.Productos.Where(p => (p.Producto is VideoJuego) && (p.Producto as VideoJuego).Nombre == "Flight Simualtor").First();            
            var ultimoLogro = juegoUsuario.Logros.Last(l => l.Logro.Codigo == "002");
            juegoUsuario.EliminarLogro(ultimoLogro);

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(juegoUsuario);
            tx.Commit();
        }
    }
}
