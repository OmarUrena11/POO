-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: localhost    Database: programoo
-- ------------------------------------------------------
-- Server version	8.0.46

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
-- Table structure for table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empleados` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Edad` tinyint unsigned NOT NULL,
  `Salario` decimal(8,2) NOT NULL,
  `Codigo` int NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empleados`
--

LOCK TABLES `empleados` WRITE;
/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados` VALUES (1,'Josue Villeguitas',22,30000.00,483721),(2,'Omar ',24,50000.00,915604),(4,'Adriana',21,20000.00,267839),(5,'Jose',30,15000.00,731526),(6,'Ramon',34,12000.00,594183),(7,'Ramiro',40,30500.00,826475),(8,'Carlos',26,23000.00,350918),(9,'Hugo',34,20000.00,648207);
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) NOT NULL,
  `Precio` decimal(8,2) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,'Carne',150.00),(2,'Tomate',12.00),(3,'Cereal',100.00),(4,'Pan',70.00),(5,'Queso',50.00),(6,'Tortilla',40.00),(7,'Galletas',20.00),(8,'Leche',28.00),(9,'Huevos',52.00),(10,'Cafe',95.00),(11,'Jamon',68.00);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas`
--

DROP TABLE IF EXISTS `ventas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ventas` (
  `ID` int NOT NULL,
  `CodigoVenta` varchar(20) NOT NULL,
  `Empleado` int NOT NULL,
  `Fecha` datetime NOT NULL,
  `Total` decimal(8,2) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `Empleado` (`Empleado`),
  CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`Empleado`) REFERENCES `empleados` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas`
--

LOCK TABLES `ventas` WRITE;
/*!40000 ALTER TABLE `ventas` DISABLE KEYS */;
INSERT INTO `ventas` VALUES (1,'20261005001',2,'2026-10-05 19:20:15',228.00),(2,'20261006001',1,'2026-10-06 11:43:10',186.00),(3,'',1,'2026-10-08 16:45:05',910.00),(4,'20261008165041',1,'2026-10-08 16:50:41',696.00),(5,'3',1,'2026-10-08 16:55:04',126.00),(6,'4',1,'2026-10-08 17:00:24',332.00),(7,'20261008005',1,'2026-10-08 17:04:59',446.00);
/*!40000 ALTER TABLE `ventas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ventas_productos`
--

DROP TABLE IF EXISTS `ventas_productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ventas_productos` (
  `ID` int NOT NULL,
  `IDCuenta` int NOT NULL,
  `IDProducto` int NOT NULL,
  `Precio` decimal(8,2) NOT NULL,
  `Cantidad` int NOT NULL,
  `Total` decimal(8,2) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IDCuenta` (`IDCuenta`),
  KEY `IDProducto` (`IDProducto`),
  CONSTRAINT `ventas_productos_ibfk_1` FOREIGN KEY (`IDCuenta`) REFERENCES `ventas` (`ID`),
  CONSTRAINT `ventas_productos_ibfk_2` FOREIGN KEY (`IDProducto`) REFERENCES `productos` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ventas_productos`
--

LOCK TABLES `ventas_productos` WRITE;
/*!40000 ALTER TABLE `ventas_productos` DISABLE KEYS */;
INSERT INTO `ventas_productos` VALUES (1,1,3,100.00,2,200.00),(2,1,8,28.00,1,28.00),(3,2,2,12.00,3,36.00),(4,2,5,50.00,3,150.00),(5,3,2,12.00,3,36.00),(6,3,4,70.00,5,350.00),(7,3,4,70.00,6,420.00),(8,3,9,52.00,2,104.00),(9,4,1,150.00,4,600.00),(10,4,8,28.00,2,56.00),(11,4,6,40.00,1,40.00),(12,5,2,12.00,3,36.00),(13,5,5,50.00,1,50.00),(14,5,7,20.00,2,40.00),(15,6,2,12.00,1,12.00),(16,6,6,40.00,8,320.00),(17,7,2,12.00,3,36.00),(18,7,7,20.00,3,60.00),(19,7,4,70.00,5,350.00);
/*!40000 ALTER TABLE `ventas_productos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-10-08 17:21:17
