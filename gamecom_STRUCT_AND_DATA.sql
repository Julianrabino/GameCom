CREATE DATABASE  IF NOT EXISTS `gamecom` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `gamecom`;
-- MySQL dump 10.13  Distrib 8.0.21, for Win64 (x86_64)
--
-- Host: localhost    Database: gamecom
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `genero`
--

DROP TABLE IF EXISTS `genero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genero` (
  `CodigoGenero` varchar(10) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `TipoGenero` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`CodigoGenero`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genero`
--

LOCK TABLES `genero` WRITE;
/*!40000 ALTER TABLE `genero` DISABLE KEYS */;
REPLACE INTO `genero` (`CodigoGenero`, `Descripcion`, `TipoGenero`) VALUES ('VSIM','Simuladores ED',1);
/*!40000 ALTER TABLE `genero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logro`
--

DROP TABLE IF EXISTS `logro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `logro` (
  `IdProducto` int NOT NULL,
  `Codigo` varchar(10) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`IdProducto`,`Codigo`),
  CONSTRAINT `FK_logro_producto` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`IdProducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logro`
--

LOCK TABLES `logro` WRITE;
/*!40000 ALTER TABLE `logro` DISABLE KEYS */;
REPLACE INTO `logro` (`IdProducto`, `Codigo`, `Descripcion`) VALUES (5,'001','Primer Vuelo'),(5,'002','Segundo Vuelo');
/*!40000 ALTER TABLE `logro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `oferta_producto`
--

DROP TABLE IF EXISTS `oferta_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `oferta_producto` (
  `IdOfertaProducto` int NOT NULL AUTO_INCREMENT,
  `FechaVigenciaDesde` datetime NOT NULL,
  `FechaVigenciaHasta` datetime NOT NULL,
  `PorcentajeDescuento` decimal(10,0) NOT NULL,
  `IdProducto` int NOT NULL,
  PRIMARY KEY (`IdOfertaProducto`),
  KEY `FK_oferta_producto_IdProducto_idx` (`IdProducto`),
  CONSTRAINT `FK_oferta_producto_IdProducto` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`IdProducto`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `oferta_producto`
--

LOCK TABLES `oferta_producto` WRITE;
/*!40000 ALTER TABLE `oferta_producto` DISABLE KEYS */;
REPLACE INTO `oferta_producto` (`IdOfertaProducto`, `FechaVigenciaDesde`, `FechaVigenciaHasta`, `PorcentajeDescuento`, `IdProducto`) VALUES (1,'2020-11-03 22:22:25','2020-11-10 22:22:25',20,5),(2,'2020-11-07 18:35:29','2020-11-14 18:35:29',20,5);
/*!40000 ALTER TABLE `oferta_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pais`
--

DROP TABLE IF EXISTS `pais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pais` (
  `Codigo` varchar(10) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`Codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pais`
--

LOCK TABLES `pais` WRITE;
/*!40000 ALTER TABLE `pais` DISABLE KEYS */;
REPLACE INTO `pais` (`Codigo`, `Descripcion`) VALUES ('ARG','Argentina ED');
/*!40000 ALTER TABLE `pais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pelicula`
--

DROP TABLE IF EXISTS `pelicula`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pelicula` (
  `IdPelicula` int NOT NULL,
  `Productora` varchar(100) NOT NULL,
  `Resenia` longtext,
  `DuracionMinutos` int DEFAULT NULL,
  PRIMARY KEY (`IdPelicula`),
  CONSTRAINT `FK_pelicula_producto` FOREIGN KEY (`IdPelicula`) REFERENCES `producto` (`IdProducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pelicula`
--

LOCK TABLES `pelicula` WRITE;
/*!40000 ALTER TABLE `pelicula` DISABLE KEYS */;
REPLACE INTO `pelicula` (`IdPelicula`, `Productora`, `Resenia`, `DuracionMinutos`) VALUES (1,'Warner','Una mujer que da todo por amor',190),(4,'Warner','Un perdedor encuentra una máscara que le cambiará la vida',115);
/*!40000 ALTER TABLE `pelicula` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `precio_producto`
--

DROP TABLE IF EXISTS `precio_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `precio_producto` (
  `IdPrecioProducto` int NOT NULL AUTO_INCREMENT,
  `IdProducto` int NOT NULL,
  `CodigoPais` varchar(10) DEFAULT NULL,
  `FechaAlta` datetime NOT NULL,
  `Valor` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`IdPrecioProducto`),
  KEY `FK_precio_producto_IdProducto_idx` (`IdProducto`),
  KEY `FK_precio_producto_CodigoPais_idx` (`CodigoPais`),
  CONSTRAINT `FK_precio_producto_CodigoPais` FOREIGN KEY (`CodigoPais`) REFERENCES `pais` (`Codigo`),
  CONSTRAINT `FK_precio_producto_IdProducto` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`IdProducto`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `precio_producto`
--

LOCK TABLES `precio_producto` WRITE;
/*!40000 ALTER TABLE `precio_producto` DISABLE KEYS */;
REPLACE INTO `precio_producto` (`IdPrecioProducto`, `IdProducto`, `CodigoPais`, `FechaAlta`, `Valor`) VALUES (1,5,'ARG','2020-11-02 23:23:49',50),(3,5,'ARG','2020-11-03 21:52:01',30),(4,5,NULL,'2020-11-03 21:52:02',100),(5,5,'ARG','2020-11-07 18:46:58',40),(6,5,NULL,'2020-11-07 18:46:59',110);
/*!40000 ALTER TABLE `precio_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto`
--

DROP TABLE IF EXISTS `producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producto` (
  `IdProducto` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` varchar(255) DEFAULT NULL,
  `Version` int NOT NULL DEFAULT '1',
  PRIMARY KEY (`IdProducto`),
  UNIQUE KEY `Nombre_UNIQUE` (`Nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto`
--

LOCK TABLES `producto` WRITE;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
REPLACE INTO `producto` (`IdProducto`, `Nombre`, `Descripcion`, `Version`) VALUES (1,'Lo que el viento se llevó','Pelicula lo que el viento se llevóED',1),(4,'La Máscara','Pelicula la máscaraEDED',3),(5,'Flight Simualtor','El mejor simualdor de vuelos',17);
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `producto_genero`
--

DROP TABLE IF EXISTS `producto_genero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `producto_genero` (
  `IdProducto` int NOT NULL,
  `CodigoGenero` varchar(10) NOT NULL,
  PRIMARY KEY (`IdProducto`,`CodigoGenero`),
  KEY `FK_Producto_Genero_CodigoGenero_idx` (`CodigoGenero`),
  CONSTRAINT `FK_Producto_Genero_CodigoGenero` FOREIGN KEY (`CodigoGenero`) REFERENCES `genero` (`CodigoGenero`),
  CONSTRAINT `FK_Producto_Genero_IdProducto` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`IdProducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `producto_genero`
--

LOCK TABLES `producto_genero` WRITE;
/*!40000 ALTER TABLE `producto_genero` DISABLE KEYS */;
REPLACE INTO `producto_genero` (`IdProducto`, `CodigoGenero`) VALUES (5,'VSIM');
/*!40000 ALTER TABLE `producto_genero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resenia_producto`
--

DROP TABLE IF EXISTS `resenia_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resenia_producto` (
  `IdResenia` int NOT NULL AUTO_INCREMENT,
  `IdProducto` int NOT NULL,
  `IdUsuario` int NOT NULL,
  `Titulo` varchar(45) NOT NULL,
  `Cuerpo` longtext NOT NULL,
  `MinutosUsoUsuario` int NOT NULL,
  `Recomendado` tinyint NOT NULL,
  PRIMARY KEY (`IdResenia`),
  UNIQUE KEY `Usuariop_producto_IX` (`IdProducto`,`IdUsuario`),
  KEY `FK_resenia_producto_Usuario_idx` (`IdUsuario`),
  KEY `FK_resenia_producto_Producto_idx` (`IdProducto`),
  CONSTRAINT `FK_resenia_producto_Producto` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`IdProducto`),
  CONSTRAINT `FK_resenia_producto_Usuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resenia_producto`
--

LOCK TABLES `resenia_producto` WRITE;
/*!40000 ALTER TABLE `resenia_producto` DISABLE KEYS */;
REPLACE INTO `resenia_producto` (`IdResenia`, `IdProducto`, `IdUsuario`, `Titulo`, `Cuerpo`, `MinutosUsoUsuario`, `Recomendado`) VALUES (5,5,4,'Compralo','asda dasdasdasda asdasda sda sd asdassdddddddddddddddddddas das dasdasdddd asda dasdasdasda asdasda sda sd asdassdddddddddddddddddddas das dasdasddddasda dasdasdasda asdasda sda sd asdassdddddddddddddddddddas das dasdasddddasda dasdasdasda asdasda sda sd asdassdddddddddddddddddddas das dasdasddddasda dasdasdasda asdasda sda sd asdassdddddddddddddddddddas das dasdasddddasda dasdasdasda asdasda sda sd asdassdddddddddddddddddddas das dasdasdddd 123',0,1),(7,5,1,'Compralo','Está buenardo',0,1);
/*!40000 ALTER TABLE `resenia_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `Email` varchar(100) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Alias` varchar(100) DEFAULT NULL,
  `Version` int NOT NULL DEFAULT '1',
  `FechaNacimiento` datetime DEFAULT NULL,
  `Telefono` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`),
  UNIQUE KEY `NombreUsuario_UNIQUE` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
REPLACE INTO `usuario` (`IdUsuario`, `Email`, `Nombre`, `Apellido`, `Alias`, `Version`, `FechaNacimiento`, `Telefono`) VALUES (1,'Julianrabino@gmail.com','Julián César','Rabino','Joncito V',28,'1984-03-20 00:00:00',NULL),(3,'JulianCesar18@hotmail.com','Julian','Rabino','Joncito',8,NULL,NULL),(4,'Josesucho@hotmail.com','José','Suarez','Josego',4,NULL,NULL);
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario_amigo_usuario`
--

DROP TABLE IF EXISTS `usuario_amigo_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario_amigo_usuario` (
  `IdUsuarioA` int NOT NULL,
  `IdUsuarioB` int NOT NULL,
  PRIMARY KEY (`IdUsuarioA`,`IdUsuarioB`),
  KEY `FK_Usuario_amigo_usuario_B_idx` (`IdUsuarioB`),
  CONSTRAINT `FK_Usuario_amigo_usuario_A` FOREIGN KEY (`IdUsuarioA`) REFERENCES `usuario` (`IdUsuario`),
  CONSTRAINT `FK_Usuario_amigo_usuario_B` FOREIGN KEY (`IdUsuarioB`) REFERENCES `usuario` (`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_amigo_usuario`
--

LOCK TABLES `usuario_amigo_usuario` WRITE;
/*!40000 ALTER TABLE `usuario_amigo_usuario` DISABLE KEYS */;
REPLACE INTO `usuario_amigo_usuario` (`IdUsuarioA`, `IdUsuarioB`) VALUES (4,1),(1,4);
/*!40000 ALTER TABLE `usuario_amigo_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario_posee_producto`
--

DROP TABLE IF EXISTS `usuario_posee_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario_posee_producto` (
  `IdUsuario` int NOT NULL,
  `IdProducto` int NOT NULL,
  `FechaAdquisicion` datetime NOT NULL,
  `TiempoUsoMinutos` int NOT NULL DEFAULT '0',
  `Devuelto` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdUsuario`,`IdProducto`),
  KEY `FK_UsuarioPoseeProducto_Usuario_idx` (`IdUsuario`) /*!80000 INVISIBLE */,
  KEY `FK_UsuarioPoseeProcuto_Producto_idx` (`IdProducto`),
  CONSTRAINT `FK_UsuarioPoseeProcuto_Producto` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`IdProducto`),
  CONSTRAINT `FK_UsuarioPoseeProducto_Usuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_posee_producto`
--

LOCK TABLES `usuario_posee_producto` WRITE;
/*!40000 ALTER TABLE `usuario_posee_producto` DISABLE KEYS */;
REPLACE INTO `usuario_posee_producto` (`IdUsuario`, `IdProducto`, `FechaAdquisicion`, `TiempoUsoMinutos`, `Devuelto`) VALUES (1,1,'2020-10-25 21:31:23',60,1),(1,5,'2020-11-07 20:19:12',0,0),(4,5,'2020-11-04 19:36:38',0,0);
/*!40000 ALTER TABLE `usuario_posee_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario_producto_logro`
--

DROP TABLE IF EXISTS `usuario_producto_logro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario_producto_logro` (
  `IdUsuarioProductoLogro` int NOT NULL AUTO_INCREMENT,
  `IdUsuario` int NOT NULL,
  `IdProducto` int NOT NULL,
  `CodigoLogro` varchar(10) NOT NULL,
  `FechaAlta` datetime NOT NULL,
  PRIMARY KEY (`IdUsuarioProductoLogro`),
  UNIQUE KEY `UQ_Produco_usuario_logro` (`IdUsuario`,`IdProducto`,`CodigoLogro`),
  KEY `FK_Usuario_producto_logro_IdUsuario_idx` (`IdUsuario`) /*!80000 INVISIBLE */,
  KEY `FK_Usuario_producto_logro_ProductoLogro_idx` (`IdProducto`,`CodigoLogro`) /*!80000 INVISIBLE */,
  CONSTRAINT `FK_Usuario_producto_logro_IdUsuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`IdUsuario`),
  CONSTRAINT `FK_Usuario_producto_logro_ProductoLogro` FOREIGN KEY (`IdProducto`, `CodigoLogro`) REFERENCES `logro` (`IdProducto`, `Codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_producto_logro`
--

LOCK TABLES `usuario_producto_logro` WRITE;
/*!40000 ALTER TABLE `usuario_producto_logro` DISABLE KEYS */;
REPLACE INTO `usuario_producto_logro` (`IdUsuarioProductoLogro`, `IdUsuario`, `IdProducto`, `CodigoLogro`, `FechaAlta`) VALUES (1,1,5,'001','2020-11-01 00:55:12'),(5,1,5,'002','2020-11-07 20:12:41');
/*!40000 ALTER TABLE `usuario_producto_logro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario_solicitud_usuario`
--

DROP TABLE IF EXISTS `usuario_solicitud_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario_solicitud_usuario` (
  `IdUsuarioSolicitante` int NOT NULL,
  `IdUsuarioSolicitado` int NOT NULL,
  PRIMARY KEY (`IdUsuarioSolicitante`,`IdUsuarioSolicitado`),
  KEY `FK_Usuario_Solicitud_Usuario_B_idx` (`IdUsuarioSolicitado`),
  CONSTRAINT `FK_Usuario_Solicitud_Usuario_A` FOREIGN KEY (`IdUsuarioSolicitante`) REFERENCES `usuario` (`IdUsuario`),
  CONSTRAINT `FK_Usuario_Solicitud_Usuario_B` FOREIGN KEY (`IdUsuarioSolicitado`) REFERENCES `usuario` (`IdUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_solicitud_usuario`
--

LOCK TABLES `usuario_solicitud_usuario` WRITE;
/*!40000 ALTER TABLE `usuario_solicitud_usuario` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuario_solicitud_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `videojuego`
--

DROP TABLE IF EXISTS `videojuego`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `videojuego` (
  `IdVideoJuego` int NOT NULL,
  `Desarrolladora` varchar(100) NOT NULL,
  `RequerimientosMinimos` longtext,
  `RequerimientosRecomendados` longtext,
  KEY `FK_videojuego_producto_idx` (`IdVideoJuego`),
  CONSTRAINT `FK_videojuego_producto` FOREIGN KEY (`IdVideoJuego`) REFERENCES `producto` (`IdProducto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videojuego`
--

LOCK TABLES `videojuego` WRITE;
/*!40000 ALTER TABLE `videojuego` DISABLE KEYS */;
REPLACE INTO `videojuego` (`IdVideoJuego`, `Desarrolladora`, `RequerimientosMinimos`, `RequerimientosRecomendados`) VALUES (5,'Microsoft','Una máquina de la NASA','Dos máquinas de la NASA');
/*!40000 ALTER TABLE `videojuego` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'gamecom'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-11-10  0:49:57
