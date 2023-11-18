-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 18, 2023 at 12:08 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `gym_management_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `billing`
--

CREATE TABLE `billing` (
  `Agent` varchar(50) NOT NULL,
  `Member` varchar(50) NOT NULL,
  `Period` varchar(50) NOT NULL,
  `Date` varchar(50) NOT NULL,
  `Amount` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `billing`
--

INSERT INTO `billing` (`Agent`, `Member`, `Period`, `Date`, `Amount`) VALUES
('1', '1', '9 yrs', '0000-00-00', 1550),
('2', '2', '2yrs', '0000-00-00', 1200),
('3', 'Karan', '3', '23-Oct-23 8:21:59 AM', 2900);

-- --------------------------------------------------------

--
-- Table structure for table `coach`
--

CREATE TABLE `coach` (
  `CId` int(50) NOT NULL,
  `CName` varchar(50) NOT NULL,
  `CDOB` varchar(50) NOT NULL,
  `CPhoneNo` varchar(50) NOT NULL,
  `CExperience` int(50) NOT NULL,
  `CAddress` varchar(50) NOT NULL,
  `CPassword` varchar(50) NOT NULL,
  `Gender` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `coach`
--

INSERT INTO `coach` (`CId`, `CName`, `CDOB`, `CPhoneNo`, `CExperience`, `CAddress`, `CPassword`, `Gender`) VALUES
(1, 'Luxshi', '0000-00-00', '0765379820', 3, 'Jaffna', '1234', 'Female'),
(2, 'Mahesi', '0000-00-00', '0752345678', 5, 'Galle', '1234', 'Female'),
(3, 'Lavan', '0000-00-00', '0752345674', 7, 'Hatton', '1234', 'Male'),
(5, 'Kuga', '0000-00-00', '0754567121', 1, 'Ambara', '1234', 'Male'),
(6, 'Tharmi', '0000-00-00', '0763419234', 3, 'Kandy', '1234', 'Female'),
(7, 'Lavanya', '23-Oct-23 12:00:00 AM', '0752345634', 7, 'Hatton', '1234', 'Female');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`Username`, `Password`) VALUES
('Admin', 'Admin'),
('Admin', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `member`
--

CREATE TABLE `member` (
  `MemberId` int(50) NOT NULL,
  `MName` varchar(50) NOT NULL,
  `MDuration` int(50) NOT NULL,
  `MGoal` varchar(50) NOT NULL,
  `MCost` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `member`
--

INSERT INTO `member` (`MemberId`, `MName`, `MDuration`, `MGoal`, `MCost`) VALUES
(1, 'Karan', 2, 'Work', 2000),
(2, 'Saranya', 3, 'Work', 1000),
(3, 'Elil', 5, 'Master', 45000),
(5, 'Yathu', 9, 'Work', 7000);

-- --------------------------------------------------------

--
-- Table structure for table `members`
--

CREATE TABLE `members` (
  `MembersId` int(50) NOT NULL,
  `MName` varchar(50) NOT NULL,
  `MGender` varchar(50) NOT NULL,
  `MDOB` varchar(50) NOT NULL,
  `MJoinDate` varchar(50) NOT NULL,
  `PhoneNo` varchar(50) NOT NULL,
  `Timing` varchar(50) NOT NULL,
  `Status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `members`
--

INSERT INTO `members` (`MembersId`, `MName`, `MGender`, `MDOB`, `MJoinDate`, `PhoneNo`, `Timing`, `Status`) VALUES
(1, 'harshi', 'Female', '23-Oct-23 9:01:17 AM', '23-Oct-23 9:01:17 AM', '0765678909', '3', 'Unmarried'),
(2, 'Lakshan', 'Male', '23-Oct-23 9:17:05 AM', '23-Oct-23 9:17:05 AM', '0765432567', '3', 'Married');

-- --------------------------------------------------------

--
-- Table structure for table `receptionists`
--

CREATE TABLE `receptionists` (
  `ReceId` int(11) NOT NULL,
  `RName` varchar(50) NOT NULL,
  `RGender` varchar(50) NOT NULL,
  `RDOB` varchar(50) NOT NULL,
  `RAddress` varchar(50) NOT NULL,
  `RPhoneNo` varchar(50) NOT NULL,
  `RPassword` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `receptionists`
--

INSERT INTO `receptionists` (`ReceId`, `RName`, `RGender`, `RDOB`, `RAddress`, `RPhoneNo`, `RPassword`) VALUES
(0, 'Diviya', 'Female', '13-Jun-00 8:25:42 AM', 'Mannar', '0769012345', '1234'),
(1, 'Siva', 'Male', '02-Dec-99 8:32:32 AM', 'Jaffna', '0761234567', '1234');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `coach`
--
ALTER TABLE `coach`
  ADD PRIMARY KEY (`CId`);

--
-- Indexes for table `member`
--
ALTER TABLE `member`
  ADD PRIMARY KEY (`MemberId`);

--
-- Indexes for table `members`
--
ALTER TABLE `members`
  ADD PRIMARY KEY (`MembersId`);

--
-- Indexes for table `receptionists`
--
ALTER TABLE `receptionists`
  ADD PRIMARY KEY (`ReceId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
