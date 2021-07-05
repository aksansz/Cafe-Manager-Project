-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `order_id` int NOT NULL AUTO_INCREMENT,
  `table_id` int NOT NULL,
  `product_id` int NOT NULL,
  `quantity` int NOT NULL,
  PRIMARY KEY (`order_id`),
  KEY `key_p_idx` (`product_id`),
  KEY `key_table_idx` (`table_id`),
  CONSTRAINT `key_p` FOREIGN KEY (`product_id`) REFERENCES `product` (`product_id`),
  CONSTRAINT `key_table` FOREIGN KEY (`table_id`) REFERENCES `table` (`table_id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (63,1,1,1),(64,1,3,1),(65,10,23,3);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `product_id` int NOT NULL AUTO_INCREMENT,
  `product_name` varchar(45) NOT NULL,
  `price` double NOT NULL DEFAULT '0',
  `product_type_id` int NOT NULL,
  PRIMARY KEY (`product_id`),
  KEY `key_t_idx` (`product_type_id`),
  CONSTRAINT `key_t` FOREIGN KEY (`product_type_id`) REFERENCES `product_types` (`type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (1,'Menemen',10,1),(2,'Omlet',4,1),(3,'Tek Kişilik Kahvaltı',17,1),(4,'Çift Kişilik Kahvaltı',30,1),(5,'Köfte Dürüm',12,2),(6,'Patso',8,2),(7,'Tavuk Döner Dürüm',10,2),(8,'Mevsim Salata',8,3),(9,'Şinitzel Salata',8,3),(10,'Ton Balıklı Salata',8,3),(11,'Beyaz Peynirli Salata',8,3),(12,'Hamburger',17,4),(13,'Çizburger',18,4),(14,'Kaşarlı Tost',11,4),(15,'Sucuklu Tost',12,4),(16,'Karışık Tost',13,4),(17,'Kola',5,5),(18,'Fanta',5,5),(19,'Soda',4,5),(20,'Meyve Suyu',5,5),(21,'Ayran',4,5),(22,'Limonata',6,5),(23,'Çay',3,6),(24,'Cappucino',8,6),(25,'Sıcak Çikolata',10,6),(26,'Türk Kahvesi',10,6),(27,'Bitki Çayı',6,6),(28,'Latte',8,6),(29,'Sütlaç',6,7),(30,'Tavuk Göğsü',6,7),(31,'Kazandibi',6,7),(32,'Sufle',7,7),(33,'Tiramisu',7,7),(34,'Dondurma',8,7);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_types`
--

DROP TABLE IF EXISTS `product_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_types` (
  `type_id` int NOT NULL AUTO_INCREMENT,
  `type_name` varchar(45) NOT NULL,
  PRIMARY KEY (`type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_types`
--

LOCK TABLES `product_types` WRITE;
/*!40000 ALTER TABLE `product_types` DISABLE KEYS */;
INSERT INTO `product_types` VALUES (1,'Kahvaltılar'),(2,'Dürümler'),(3,'Salatalar'),(4,'Aparatifler'),(5,'Soğuk İçecekler'),(6,'Sıcak İçecekler'),(7,'Tatlı ve Pasta');
/*!40000 ALTER TABLE `product_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `table`
--

DROP TABLE IF EXISTS `table`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `table` (
  `table_id` int NOT NULL AUTO_INCREMENT,
  `payment_status` varchar(45) NOT NULL,
  PRIMARY KEY (`table_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `table`
--

LOCK TABLES `table` WRITE;
/*!40000 ALTER TABLE `table` DISABLE KEYS */;
INSERT INTO `table` VALUES (1,'Not Paid'),(2,'Paid'),(3,'Paid'),(4,'Paid'),(5,'Paid'),(6,'Paid'),(7,'Paid'),(8,'Paid'),(9,'Paid'),(10,'Not Paid'),(11,'Paid'),(12,'Paid');
/*!40000 ALTER TABLE `table` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-05 17:08:33
