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
  `id_kamar` varchar(5) NOT NULL,
  `tipe_kamar` varchar(20) NOT NULL,
  `harga` int(11) NOT NULL,
  `fasilitas` text NOT NULL,
  PRIMARY KEY (`id_kamar`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `kamar` */

insert  into `kamar`(`id_kamar`,`tipe_kamar`,`harga`,`fasilitas`) values ('101','deluxe',2300000,'TV,Water heater'),('232','Superior',3000000,'sdlfkj ask'),('303','deluxe',300000,'kajdh'),('404','deluxe',440,'skfhjkdfhsf\nskdjfh\nsdfkjh'),('909','superior',700000,'akjdkj\nasdlj\nasldj');

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

insert  into `konsumen`(`id_konsumen`,`nama`,`j_kelamin`,`tgl_lahir`,`tempat_lahir`,`alamat`,`kota`,`no_telp`) values ('5656565656','hfgfh','Laki-laki','2018-01-08','sdjkhk','kjadh','kajh','dkj'),('9898989898','ahd','Perempuan','2018-01-08','d','s','gh','djh');

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

insert  into `pegawai`(`id_pegawai`,`nama`,`j_kelamin`,`tgl_lahir`,`tempat_lahir`,`alamat`,`no_telp`,`pass`) values ('0987654321','jdfghjdf','Perempuan','2017-12-29','dhj','asjg','298478','12'),('12','hakjd','Laki-laki','2017-12-29','sdfkjh','akjdh','akdjh','qw'),('1234567890','sdkjhk','Perempuan','2018-01-08','mnmjk','kjhkj','98089080','admin');

/*Table structure for table `pembayaran` */

DROP TABLE IF EXISTS `pembayaran`;

CREATE TABLE `pembayaran` (
  `id_pembayaran` varchar(10) NOT NULL,
  `id_reservasi` varchar(10) NOT NULL,
  `id_konsumen` varchar(10) NOT NULL,
  `jenis_bayar` varchar(25) NOT NULL,
  `subtotal` int(11) NOT NULL,
  `tax_service` int(11) NOT NULL,
  `total_payment` int(11) NOT NULL,
  `cash` int(11) NOT NULL,
  `change` int(11) NOT NULL,
  `unpayment` int(11) NOT NULL,
  `id_pegawai` varchar(10) NOT NULL,
  PRIMARY KEY (`id_pembayaran`),
  KEY `id_reservasi` (`id_reservasi`),
  KEY `id_pegawai` (`id_pegawai`),
  CONSTRAINT `pembayaran_ibfk_1` FOREIGN KEY (`id_reservasi`) REFERENCES `reservasi` (`id_reservasi`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `pembayaran_ibfk_2` FOREIGN KEY (`id_pegawai`) REFERENCES `pegawai` (`id_pegawai`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `pembayaran` */

/*Table structure for table `reservasi` */

DROP TABLE IF EXISTS `reservasi`;

CREATE TABLE `reservasi` (
  `id_reservasi` varchar(10) NOT NULL,
  `id_konsumen` varchar(10) NOT NULL,
  `tgl_reservasi` date NOT NULL,
  `check_in` date NOT NULL,
  `check_out` date NOT NULL,
  `id_kamar` varchar(4) NOT NULL,
  `hari` int(11) NOT NULL,
  `catatan` text NOT NULL,
  `id_pegawai` varchar(10) NOT NULL,
  PRIMARY KEY (`id_reservasi`),
  KEY `id_konsumen` (`id_konsumen`),
  KEY `id_kamar` (`id_kamar`),
  KEY `id_pegawai` (`id_pegawai`),
  CONSTRAINT `reservasi_ibfk_1` FOREIGN KEY (`id_konsumen`) REFERENCES `konsumen` (`id_konsumen`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reservasi_ibfk_2` FOREIGN KEY (`id_kamar`) REFERENCES `kamar` (`id_kamar`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `reservasi_ibfk_3` FOREIGN KEY (`id_pegawai`) REFERENCES `pegawai` (`id_pegawai`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `reservasi` */

insert  into `reservasi`(`id_reservasi`,`id_konsumen`,`tgl_reservasi`,`check_in`,`check_out`,`id_kamar`,`hari`,`catatan`,`id_pegawai`) values ('249879','5656565656','2018-01-17','2018-01-02','2018-01-08','404',2,'lkjlkj','0987654321'),('834893274','9898989898','2018-01-12','2018-01-01','2018-01-08','303',3,'sdf','1234567890'),('893573','5656565656','2018-01-08','2018-01-19','2018-01-02','909',2,'sdfsdf\r\n','1234567890');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
