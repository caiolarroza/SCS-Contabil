-- phpMyAdmin SQL Dump
-- version 4.4.9
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: 08-Out-2015 às 13:27
-- Versão do servidor: 5.6.25
-- PHP Version: 5.4.41

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `scs`
--
CREATE DATABASE IF NOT EXISTS `scs` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `scs`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

DROP TABLE IF EXISTS `cliente`;
CREATE TABLE IF NOT EXISTS `cliente` (
  `CliCod` int(11) NOT NULL,
  `CliNom` varchar(30) NOT NULL,
  `CliCpf` varchar(15) DEFAULT NULL,
  `CliTel` int(11) DEFAULT NULL,
  `CliEnd` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `endereco`
--

DROP TABLE IF EXISTS `endereco`;
CREATE TABLE IF NOT EXISTS `endereco` (
  `EndCod` int(11) NOT NULL,
  `EndEnd` varchar(60) NOT NULL,
  `EndNum` varchar(7) NOT NULL,
  `EndCom` varchar(30) DEFAULT NULL,
  `EndBai` varchar(30) DEFAULT NULL,
  `EndMun` varchar(30) DEFAULT NULL,
  `EndCid` varchar(30) DEFAULT NULL,
  `EndEst` char(2) DEFAULT NULL,
  `EndCep` varchar(9) NOT NULL,
  `EndPai` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `fornecedor`
--

DROP TABLE IF EXISTS `fornecedor`;
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

DROP TABLE IF EXISTS `produto`;
CREATE TABLE IF NOT EXISTS `produto` (
  `ProCod` int(11) NOT NULL,
  `ProNom` varchar(40) DEFAULT NULL,
  `ProFor` int(11) DEFAULT NULL,
  `ProPco` decimal(9,2) DEFAULT NULL,
  `ProPve` decimal(9,2) DEFAULT NULL,
  `ProDat` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `telefone`
--

DROP TABLE IF EXISTS `telefone`;
CREATE TABLE IF NOT EXISTS `telefone` (
  `TelCod` int(11) NOT NULL,
  `TelDdi` varchar(4) DEFAULT NULL,
  `TelDdd` varchar(4) DEFAULT NULL,
  `TelNum` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE IF NOT EXISTS `usuario` (
  `UsuCod` int(11) NOT NULL,
  `UsuNom` varchar(40) NOT NULL,
  `UsuSen` varchar(25) NOT NULL,
  `UsuTip` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`UsuCod`, `UsuNom`, `UsuSen`, `UsuTip`) VALUES
(1, 'adm', '123', 'A');

-- --------------------------------------------------------

--
-- Estrutura da tabela `venda`
--

DROP TABLE IF EXISTS `venda`;
CREATE TABLE IF NOT EXISTS `venda` (
  `VenCod` int(11) NOT NULL,
  `VenPro` int(11) DEFAULT NULL,
  `VenCli` int(11) DEFAULT NULL,
  `VenQtd` int(11) DEFAULT NULL,
  `VenVal` decimal(9,2) DEFAULT NULL,
  `VenVfr` decimal(9,2) DEFAULT NULL,
  `VenVfi` decimal(9,2) DEFAULT NULL,
  `VenDat` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`CliCod`),
  ADD KEY `CliEnd` (`CliEnd`),
  ADD KEY `CliTel` (`CliTel`);

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
  ADD PRIMARY KEY (`VenCod`),
  ADD KEY `VenPro` (`VenPro`),
  ADD KEY `VenCli` (`VenCli`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `produto`
--
ALTER TABLE `produto`
  MODIFY `ProCod` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `venda`
--
ALTER TABLE `venda`
  MODIFY `VenCod` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `cliente`
--
ALTER TABLE `cliente`
  ADD CONSTRAINT `cliente_ibfk_1` FOREIGN KEY (`CliEnd`) REFERENCES `endereco` (`EndCod`),
  ADD CONSTRAINT `cliente_ibfk_2` FOREIGN KEY (`CliTel`) REFERENCES `telefone` (`TelCod`);

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

--
-- Limitadores para a tabela `venda`
--
ALTER TABLE `venda`
  ADD CONSTRAINT `venda_ibfk_1` FOREIGN KEY (`VenPro`) REFERENCES `produto` (`ProCod`),
  ADD CONSTRAINT `venda_ibfk_2` FOREIGN KEY (`VenCli`) REFERENCES `cliente` (`CliCod`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
