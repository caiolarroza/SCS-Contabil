-- phpMyAdmin SQL Dump
-- version 4.4.13.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: 03-Dez-2015 às 23:45
-- Versão do servidor: 5.6.26
-- PHP Version: 5.5.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `scs`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `endereco`
--

CREATE TABLE IF NOT EXISTS `endereco` (
  `EndCod` int(11) NOT NULL,
  `EndEnd` varchar(60) NOT NULL,
  `EndNum` varchar(7) NOT NULL,
  `EndCom` varchar(30) DEFAULT NULL,
  `EndBai` varchar(30) DEFAULT NULL,
  `EndMun` varchar(30) DEFAULT NULL,
  `EndEst` char(2) DEFAULT NULL,
  `EndCep` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `fornecedor`
--

CREATE TABLE IF NOT EXISTS `fornecedor` (
  `ForCod` int(11) NOT NULL,
  `ForRaz` varchar(40) NOT NULL,
  `ForNom` varchar(40) DEFAULT NULL,
  `ForCnp` varchar(20) DEFAULT NULL,
  `ForImu` varchar(20) DEFAULT NULL,
  `ForIes` varchar(20) DEFAULT NULL,
  `ForTel` int(11) DEFAULT NULL,
  `ForEnd` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE IF NOT EXISTS `produto` (
  `ProCod` int(11) NOT NULL,
  `ProNom` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `ProFor` int(11) DEFAULT NULL,
  `ProPco` decimal(15,2) DEFAULT NULL,
  `ProDat` date DEFAULT NULL,
  `ProQtd` int(11) DEFAULT NULL,
  `ProPcoTot` decimal(15,2) DEFAULT NULL,
  `ProFre` decimal(15,2) DEFAULT NULL,
  `ProIcms` decimal(15,2) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `saldo`
--

CREATE TABLE IF NOT EXISTS `saldo` (
  `SalCod` int(11) NOT NULL,
  `SalProd` varchar(40) DEFAULT NULL,
  `SalQtd` int(11) DEFAULT NULL,
  `SalVun` decimal(15,2) DEFAULT NULL,
  `SalVto` decimal(15,2) DEFAULT NULL,
  `SalDat` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `telefone`
--

CREATE TABLE IF NOT EXISTS `telefone` (
  `TelCod` int(11) NOT NULL,
  `TelDdd` varchar(4) DEFAULT NULL,
  `TelNum` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `UsuCod` int(11) NOT NULL,
  `UsuNom` varchar(40) NOT NULL,
  `UsuSen` varchar(25) NOT NULL,
  `UsuTip` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`UsuCod`, `UsuNom`, `UsuSen`, `UsuTip`) VALUES
(1, 'ADM', '123', 'SUPER ADM');

-- --------------------------------------------------------

--
-- Estrutura da tabela `venda`
--

CREATE TABLE IF NOT EXISTS `venda` (
  `VenCod` int(11) NOT NULL,
  `VenPro` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `VenQtd` int(11) DEFAULT NULL,
  `VenDat` date DEFAULT NULL,
  `VenVun` decimal(15,2) DEFAULT NULL,
  `VenVto` decimal(15,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `vendaueps`
--

CREATE TABLE IF NOT EXISTS `vendaueps` (
  `VenCod` int(11) NOT NULL,
  `VenPro` varchar(40) DEFAULT NULL,
  `VenQtd` int(11) DEFAULT NULL,
  `VenDat` date DEFAULT NULL,
  `VenVun` decimal(15,2) DEFAULT NULL,
  `VenVto` decimal(15,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `endereco`
--
ALTER TABLE `endereco`
  ADD PRIMARY KEY (`EndCod`);

--
-- Indexes for table `fornecedor`
--
ALTER TABLE `fornecedor`
  ADD PRIMARY KEY (`ForCod`),
  ADD KEY `ForTel` (`ForTel`),
  ADD KEY `ForEnd` (`ForEnd`);

--
-- Indexes for table `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`ProCod`),
  ADD KEY `ProFor` (`ProFor`);

--
-- Indexes for table `saldo`
--
ALTER TABLE `saldo`
  ADD PRIMARY KEY (`SalCod`);

--
-- Indexes for table `telefone`
--
ALTER TABLE `telefone`
  ADD PRIMARY KEY (`TelCod`);

--
-- Indexes for table `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`UsuCod`);

--
-- Indexes for table `venda`
--
ALTER TABLE `venda`
  ADD PRIMARY KEY (`VenCod`);

--
-- Indexes for table `vendaueps`
--
ALTER TABLE `vendaueps`
  ADD PRIMARY KEY (`VenCod`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `produto`
--
ALTER TABLE `produto`
  MODIFY `ProCod` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `fornecedor`
--
ALTER TABLE `fornecedor`
  ADD CONSTRAINT `fornecedor_ibfk_1` FOREIGN KEY (`ForTel`) REFERENCES `telefone` (`TelCod`),
  ADD CONSTRAINT `fornecedor_ibfk_2` FOREIGN KEY (`ForEnd`) REFERENCES `endereco` (`EndCod`);

--
-- Limitadores para a tabela `produto`
--
ALTER TABLE `produto`
  ADD CONSTRAINT `produto_ibfk_1` FOREIGN KEY (`ProFor`) REFERENCES `fornecedor` (`ForCod`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
