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

insert  into `kamar`(`id_kamar`,`tipe_kamar`,`harga`,`fasilitas`) values ('101','Double',350000,'skljdflkldskfklsdjfk'),('303','Single',200000,'zkdasjlkd'),('505','Triple',500000,'asdlkjaldk'),('707','Double',350000,'kjhkjzxc'),('909','Double',300000,'jkhkjhka');

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

insert  into `konsumen`(`id_konsumen`,`nama`,`j_kelamin`,`tgl_lahir`,`tempat_lahir`,`alamat`,`kota`,`no_telp`) values ('1','roni','Laki-laki','2018-01-15','kjsdfh','kjefh','ksdjfh','2304987'),('10','skjdfh','Laki-laki','2018-01-16','sdfsdf','sdf','sdf','sdf'),('11','ksdhfk','Laki-laki','2018-01-16','sdf','sdf','sdf','sdf'),('3','doni','Laki-laki','2018-01-16','jgjhg','jhgjh','jhgjh','435345');

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

insert  into `pegawai`(`id_pegawai`,`nama`,`j_kelamin`,`tgl_lahir`,`tempat_lahir`,`alamat`,`no_telp`,`pass`) values ('123','admin','Perempuan','2018-01-15','qwe','qwe','qwe',''),('456','admin','Perempuan','2017-12-29','dfg','dfg','dfg',''),('9279','admin','Perempuan','2018-01-15','dsfjkh','skdjfh','sdjkfh',''),('admin','admin','Laki-laki','2018-01-13','askjdh','kasjd','ksjdfh','admin');

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

insert  into `pembayaran`(`id_pembayaran`,`id_reservasi`,`jenis_bayar`,`subtotal`,`bayar_tambahan`,`total`,`bayar`,`kembalian`) values ('P234','R123','Tunai',300000,0,300000,300000,0),('P6757','R7657','Tunai',300000,125000,425000,500000,75000);

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
  `catatan` text NOT NULL,
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

insert  into `reservasi`(`id_reservasi`,`id_konsumen`,`tgl_reservasi`,`check_in`,`check_out`,`id_kamar`,`hari`,`catatan`,`id_pegawai`) values ('R123','3','2018-01-16','2018-01-17','2018-01-18','505',1,'dsfsdfa','admin'),('R343','11','2018-01-16','2018-01-17','2018-01-19','303',2,'sdfsdf','admin'),('R7657','10','2017-12-29','2017-12-30','2017-12-31','909',1,'Extra Bed','admin'),('R9879','1','2017-12-18','2017-12-22','2017-12-25','909',3,'Extra Bed','admin');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
