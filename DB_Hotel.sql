/*
SQLyog Enterprise v12.09 (64 bit)
MySQL - 5.7.19 : Database - db_hotel
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`db_hotel` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `db_hotel`;

/*Table structure for table `kamar` */

DROP TABLE IF EXISTS `kamar`;

CREATE TABLE `kamar` (
  `id_kamar` varchar(3) NOT NULL,
  `tipe_kamar` varchar(20) NOT NULL,
  `harga` int(11) NOT NULL,
  `fasilitas` text NOT NULL,
  PRIMARY KEY (`id_kamar`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `kamar` */

insert  into `kamar`(`id_kamar`,`tipe_kamar`,`harga`,`fasilitas`) values ('101','Single',200000,'AC,TV,Shower'),('202','Triple',500000,'AC,TV,Shower'),('303','Single',200000,'AC,TV,Shower'),('505','Triple',500000,'AC,TV,Shower'),('707','Double',350000,'AC,TV,Shower'),('909','Double',300000,'AC,TV,Shower');

/*Table structure for table `konsumen` */

DROP TABLE IF EXISTS `konsumen`;

CREATE TABLE `konsumen` (
  `id_konsumen` varchar(15) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `j_kelamin` varchar(10) NOT NULL,
  `tgl_lahir` date NOT NULL,
  `tempat_lahir` varchar(40) NOT NULL,
  `alamat` text NOT NULL,
  `kota` varchar(40) NOT NULL,
  `no_telp` varchar(12) NOT NULL,
  PRIMARY KEY (`id_konsumen`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `konsumen` */

insert  into `konsumen`(`id_konsumen`,`nama`,`j_kelamin`,`tgl_lahir`,`tempat_lahir`,`alamat`,`kota`,`no_telp`) values ('K001','Asep Saepulloh','Laki-laki','1993-06-15','Bandung','Jl. Dipatiukur','Bandung','089643552132'),('K002','Iman Nasrul','Laki-laki','1990-11-16','Solo','Jl. Kolonel Masturi','Cimahi','08798767554'),('K003','Nandang','Laki-laki','2004-07-16','Jakarta','Jl. Peta','Bandung','089768565444'),('K004','Nida Amelia','Perempuan','1995-07-14','Bekasi','Jl.Moh Toha','Bandung','081231145234');

/*Table structure for table `pegawai` */

DROP TABLE IF EXISTS `pegawai`;

CREATE TABLE `pegawai` (
  `id_pegawai` varchar(10) NOT NULL,
  `nama` varchar(30) NOT NULL,
  `j_kelamin` varchar(10) NOT NULL,
  `tgl_lahir` date NOT NULL,
  `tempat_lahir` varchar(40) NOT NULL,
  `alamat` text NOT NULL,
  `no_telp` varchar(12) NOT NULL,
  `pass` varchar(12) NOT NULL,
  PRIMARY KEY (`id_pegawai`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pegawai` */

insert  into `pegawai`(`id_pegawai`,`nama`,`j_kelamin`,`tgl_lahir`,`tempat_lahir`,`alamat`,`no_telp`,`pass`) values ('admin','Fatah','Laki-laki','1989-02-10','Padang','Jl. Cidahu','081325667543','admin'),('P001','Gading','Laki','2000-01-15','Bandung','Jl. Sukajadi','08875444542',''),('P002','Siti','Perempuan','1989-11-30','Jakarta','Jl. Tubagus Ismail','08976554667',''),('P003','Nadia','Perempuan','1989-03-16','Solo','Jl. Wastu Kencana','089765432112','');

/*Table structure for table `pembayaran` */

DROP TABLE IF EXISTS `pembayaran`;

CREATE TABLE `pembayaran` (
  `id_pembayaran` varchar(10) NOT NULL,
  `id_reservasi` varchar(10) NOT NULL,
  `jenis_bayar` varchar(25) NOT NULL,
  `subtotal` int(11) NOT NULL,
  `bayar_tambahan` int(11) NOT NULL,
  `total` int(11) NOT NULL,
  `bayar` int(11) NOT NULL,
  `kembalian` int(11) NOT NULL,
  PRIMARY KEY (`id_pembayaran`),
  KEY `id_reservasi` (`id_reservasi`),
  CONSTRAINT `pembayaran_ibfk_1` FOREIGN KEY (`id_reservasi`) REFERENCES `reservasi` (`id_reservasi`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pembayaran` */

insert  into `pembayaran`(`id_pembayaran`,`id_reservasi`,`jenis_bayar`,`subtotal`,`bayar_tambahan`,`total`,`bayar`,`kembalian`) values ('P001','R123','Tunai',500000,0,500000,500000,0);

/*Table structure for table `reservasi` */

DROP TABLE IF EXISTS `reservasi`;

CREATE TABLE `reservasi` (
  `id_reservasi` varchar(10) NOT NULL,
  `id_konsumen` varchar(10) NOT NULL,
  `tgl_reservasi` date NOT NULL,
  `check_in` date NOT NULL,
  `check_out` date NOT NULL,
  `id_kamar` varchar(3) NOT NULL,
  `hari` int(11) NOT NULL,
  `tambahan` varchar(20) DEFAULT NULL,
  `id_pegawai` varchar(10) NOT NULL,
  PRIMARY KEY (`id_reservasi`),
  KEY `id_konsumen` (`id_konsumen`),
  KEY `id_pegawai` (`id_pegawai`),
  KEY `reservasi_ibfk_4` (`id_kamar`),
  CONSTRAINT `reservasi_ibfk_1` FOREIGN KEY (`id_konsumen`) REFERENCES `konsumen` (`id_konsumen`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reservasi_ibfk_3` FOREIGN KEY (`id_pegawai`) REFERENCES `pegawai` (`id_pegawai`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reservasi_ibfk_4` FOREIGN KEY (`id_kamar`) REFERENCES `kamar` (`id_kamar`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `reservasi` */

insert  into `reservasi`(`id_reservasi`,`id_konsumen`,`tgl_reservasi`,`check_in`,`check_out`,`id_kamar`,`hari`,`tambahan`,`id_pegawai`) values ('R123','K001','2018-01-02','2018-01-17','2018-01-18','505',1,NULL,'P003'),('R213','K003','2018-01-18','2018-01-20','2018-01-23','707',3,'','P003'),('R343','K004','2018-01-16','2018-01-17','2018-01-19','303',2,NULL,'P001');

/* Trigger structure for table `konsumen` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `history_update` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'localhost' */ /*!50003 TRIGGER `history_update` BEFORE UPDATE ON `konsumen` FOR EACH ROW 
	set new.id_konsumen = old.id_konsumen */$$


DELIMITER ;

/*Table structure for table `struk` */

DROP TABLE IF EXISTS `struk`;

/*!50001 DROP VIEW IF EXISTS `struk` */;
/*!50001 DROP TABLE IF EXISTS `struk` */;

/*!50001 CREATE TABLE  `struk`(
 `id_konsumen` varchar(15) ,
 `id_reservasi` varchar(10) ,
 `jenis_bayar` varchar(25) ,
 `id_kamar` varchar(3) ,
 `check_in` date ,
 `check_out` date ,
 `hari` int(11) ,
 `subtotal` int(11) ,
 `bayar_tambahan` int(11) ,
 `total` int(11) ,
 `bayar` int(11) ,
 `kembalian` int(11) ,
 `nama` varchar(30) ,
 `no_telp` varchar(12) ,
 `Tanggal` datetime 
)*/;

/*View structure for view struk */

/*!50001 DROP TABLE IF EXISTS `struk` */;
/*!50001 DROP VIEW IF EXISTS `struk` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `struk` AS (select `konsumen`.`id_konsumen` AS `id_konsumen`,`reservasi`.`id_reservasi` AS `id_reservasi`,`pembayaran`.`jenis_bayar` AS `jenis_bayar`,`kamar`.`id_kamar` AS `id_kamar`,`reservasi`.`check_in` AS `check_in`,`reservasi`.`check_out` AS `check_out`,`reservasi`.`hari` AS `hari`,`pembayaran`.`subtotal` AS `subtotal`,`pembayaran`.`bayar_tambahan` AS `bayar_tambahan`,`pembayaran`.`total` AS `total`,`pembayaran`.`bayar` AS `bayar`,`pembayaran`.`kembalian` AS `kembalian`,`pegawai`.`nama` AS `nama`,`pegawai`.`no_telp` AS `no_telp`,now() AS `Tanggal` from ((((`kamar` join `pembayaran`) join `konsumen`) join `pegawai`) join `reservasi`) where ((`kamar`.`id_kamar` = `reservasi`.`id_kamar`) and (`konsumen`.`id_konsumen` = `reservasi`.`id_konsumen`) and (`pegawai`.`id_pegawai` = `reservasi`.`id_pegawai`) and (`pembayaran`.`id_reservasi` = `reservasi`.`id_reservasi`))) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
