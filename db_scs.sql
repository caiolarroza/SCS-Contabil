-- phpMyAdmin SQL Dump
-- version 4.4.13.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: 14-Nov-2015 às 19:22
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

--
-- Extraindo dados da tabela `endereco`
--

INSERT INTO `endereco` (`EndCod`, `EndEnd`, `EndNum`, `EndCom`, `EndBai`, `EndMun`, `EndEst`, `EndCep`) VALUES
(1, 'RUA DIAS DE ALMEIDA', '666', 'WHEY PROTEIN', 'JARDIM MIRIAM', 'SÃO PAULO', 'SP', '04419000'),
(2, 'SUA MAE', '666', 'AQUELA VACA', 'BORDEL', 'VILA DO SAPO', 'SP', '04256177'),
(3, 'DASD11', '11', '1231', '123', '123', '13', '04475440');

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

--
-- Extraindo dados da tabela `fornecedor`
--

INSERT INTO `fornecedor` (`ForCod`, `ForRaz`, `ForNom`, `ForCnp`, `ForImu`, `ForIes`, `ForTel`, `ForEnd`) VALUES
(1, 'MONSTRÃO', 'SWEET POTATO', '66666666666666', '66666', '666666666666', 1, 1),
(2, 'QWE', 'ASD', '12345678912345', '12345', '123456789012', 2, 2),
(3, 'SD', 'DDD', '11111111111111', '22222', '333333333333', 3, 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE IF NOT EXISTS `produto` (
  `ProCod` int(11) NOT NULL,
  `ProNom` varchar(40) DEFAULT NULL,
  `ProFor` int(11) DEFAULT NULL,
  `ProPco` decimal(15,2) DEFAULT NULL,
  `ProDat` date DEFAULT NULL,
  `ProQtd` int(11) DEFAULT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`ProCod`, `ProNom`, `ProFor`, `ProPco`, `ProDat`, `ProQtd`) VALUES
(1, 'BATATA', 1, '1500.00', '2015-11-09', 7),
(3, 'WHEY DO MONSTRO 1KG BAUNILHA', 1, '150.00', '2015-11-06', 10000);

-- --------------------------------------------------------

--
-- Estrutura da tabela `telefone`
--

CREATE TABLE IF NOT EXISTS `telefone` (
  `TelCod` int(11) NOT NULL,
  `TelDdd` varchar(4) DEFAULT NULL,
  `TelNum` varchar(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `telefone`
--

INSERT INTO `telefone` (`TelCod`, `TelDdd`, `TelNum`) VALUES
(1, '11', '69696669'),
(2, '11', '12345678'),
(3, '11', '56725105');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

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
(1, 'ADM', '123', 'A'),
(2, 'ASD', 'ASD', 'A'),
(3, 'QWE', 'QWE', 'B'),
(4, 'ADOLF', '123', 'A'),
(5, 'DANILO', 'DANILO', 'A');

-- --------------------------------------------------------

--
-- Estrutura da tabela `venda`
--

CREATE TABLE IF NOT EXISTS `venda` (
  `VenCod` int(11) NOT NULL,
  `VenPro` int(11) DEFAULT NULL,
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
  ADD KEY `VenPro` (`VenPro`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `produto`
--
ALTER TABLE `produto`
  MODIFY `ProCod` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `venda`
--
ALTER TABLE `venda`
  MODIFY `VenCod` int(11) NOT NULL AUTO_INCREMENT;
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

--
-- Limitadores para a tabela `venda`
--
ALTER TABLE `venda`
  ADD CONSTRAINT `venda_ibfk_1` FOREIGN KEY (`VenPro`) REFERENCES `produto` (`ProCod`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
