using GameCom.Model.Entities;
using GameCom.Test.Repo.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GameCom.Test.Repository
{
    [TestClass]
    public class ProductoTest: BaseTestRepository
    {
        [TestMethod]
        public void TestObtenerProducto()
        {
            var be = this.DbSession.Get<VideoJuego>(5);
            Assert.IsTrue(be.Resenias.Any());
        }

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
        public void TestUpdatePelicula()
        {
            var pelicula = this.DbSession.Get<Pelicula>(4);            
            pelicula.Descripcion += "ED";
            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Update(pelicula);
            tx.Commit();
        }

        [TestMethod]
        public void TestDeletePelicula()
        {
            var pelicula = this.DbSession.Get<Pelicula>(3);            
            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Delete(pelicula);
            tx.Commit();
        }

        [TestMethod]
        public void TestInsertVideoJuego()
        {
            var pelicula = new VideoJuego
            {
                Nombre = "Flight Simualtor",
                Descripcion = "El mejor simualdor de vuelos",
                Desarroladora = "Microsoft",
                RequerimientosMinimos = "Una máquina de la NASA",
                RequerimientosRecomendados = "Dos máquinas de la NASA"                
            };

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(pelicula);
            tx.Commit();
        }

        [TestMethod]
        public void TestAgregarGenero()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);
            var genero = this.DbSession.Get<GeneroProducto>("VSIM");

            videoJuego.AgregarGenero(genero);
            
            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Update(videoJuego);
            tx.Commit();
        }

        [TestMethod]
        public void TestInsertLogroVideoJuego()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);
            videoJuego.AgregaraLogro(new LogroProducto("001")
            {
                Descripcion = "Primer Vuelo"
            });

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(videoJuego);
            tx.Commit();
        }

        [TestMethod]
        public void TestAgregarResenia()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);
            var usuario = this.DbSession.Get<Usuario>(1);
            var productoUsuario = usuario.Productos.FirstOrDefault(p => p.Producto.Equals(videoJuego));

            videoJuego.AgregarResenia(new ReseniaProducto 
            { 
                MinutosUsoUsuario = productoUsuario.MinutosUso,
                Cuerpo = "Está buenardo",
                Titulo = "Compralo",
                Recomendado = true,
                Usuario = usuario
            });

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(videoJuego);
            tx.Commit();
        }

        [TestMethod]
        public void TestAgregarPrecio()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);
            var pais = this.DbSession.Get<Pais>("ARG");            

            videoJuego.AgregarPrecio(new PrecioProducto
            {
                Pais = pais,
                FechaAlta = DateTime.Now,
                Valor = 50
            });

            videoJuego.AgregarPrecio(new PrecioProducto
            {                
                FechaAlta = DateTime.Now,
                Valor = 100
            });

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(videoJuego);
            tx.Commit();
        }

        [TestMethod]
        public void TestEliminarPrecio()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);
            var precio = videoJuego.Precios.Last();

            videoJuego.EliminarPrecio(precio);

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(videoJuego);
            tx.Commit();
        }
    }
}
