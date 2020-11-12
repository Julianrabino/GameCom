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
            var pelicula = new Pelicula
            {
                Nombre = "Pelicula a borrar",
                Descripcion = "Pelicula a borrar",
                Resenia = "Pelicula a borrar",
                Productora = "Warner",
                DuracionMinutos = 115
            };

            using var tx1 = this.DbSession.BeginTransaction();
            this.DbSession.Save(pelicula);
            tx1.Commit();
            
            using var tx2 = this.DbSession.BeginTransaction();
            this.DbSession.Delete(pelicula);
            tx2.Commit();
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
        public void TestEliminarGenero()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);
            var genero = this.DbSession.Get<GeneroProducto>("VSIM");

            videoJuego.EliminarGenero(genero);

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Update(videoJuego);
            tx.Commit();
        }

        [TestMethod]
        public void TestInsertLogroVideoJuego()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);
            videoJuego.AgregaraLogro(new LogroProducto("002")
            {
                Descripcion = "Segundo Vuelo"
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
                Valor = 40
            });

            videoJuego.AgregarPrecio(new PrecioProducto
            {                
                FechaAlta = DateTime.Now,
                Valor = 110
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

        [TestMethod]
        public void TestObtenerPrecioActual()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);
            var precioArgentina = this.DbSession
                .QueryOver<PrecioProducto>()
                .Where(p => p.Producto.Id == 5)
                .Where(p => p.Pais != null && p.Pais.Id == "ARG")
                .OrderBy(p => p.FechaAlta).Desc
                .List().First();

            var precioMundial = this.DbSession
                .QueryOver<PrecioProducto>()
                .Where(p => p.Producto.Id == 5)
                .Where(p => p.Pais == null)
                .OrderBy(p => p.FechaAlta).Desc
                .List().First();

            Assert.IsNotNull(precioArgentina);
            Assert.IsNotNull(precioMundial);
        }

        [TestMethod]
        public void TestAgregarOferta()
        {
            var videoJuego = this.DbSession.Get<VideoJuego>(5);

            var inicioVigencia = DateTime.Now;
            var nuevaOfeta = new OfertaProducto
            {
                VigenciaDesde = inicioVigencia,
                VigenciaHasta = inicioVigencia.AddDays(7),
                PorcentajeDescuento = 20
            };

            videoJuego.AgregarOferta(nuevaOfeta);
            //Prueba de duplicidad: Agrega dos veces la misma oferta pero se persiste una vez sola 
            videoJuego.AgregarOferta(nuevaOfeta);

            using var tx = this.DbSession.BeginTransaction();
            this.DbSession.Save(videoJuego);
            tx.Commit();
        }
    }
}
