-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 06, 2025 at 07:21 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `culture2geth`
--

-- --------------------------------------------------------

--
-- Table structure for table `interest`
--

CREATE TABLE `interest` (
  `InterestID` int(2) NOT NULL,
  `Name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `interest`
--

INSERT INTO `interest` (`InterestID`, `Name`) VALUES
(1, 'Sharing'),
(24, 'Caring'),
(25, 'Learning'),
(26, 'Working'),
(27, 'Happenings');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `UserId` int(5) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `Password` varchar(250) NOT NULL,
  `MembershipType` varchar(50) NOT NULL,
  `JoinDate` date NOT NULL,
  `ExpiryDate` date NOT NULL,
  `Role` varchar(10) NOT NULL,
  `MailingList` int(5) DEFAULT NULL,
  `Address` varchar(100) NOT NULL,
  `PhoneNumber` varchar(20) NOT NULL,
  `ProfileStatus` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`UserId`, `Email`, `FirstName`, `LastName`, `Password`, `MembershipType`, `JoinDate`, `ExpiryDate`, `Role`, `MailingList`, `Address`, `PhoneNumber`, `ProfileStatus`) VALUES
(1, 'test@gmail.com', 'Sarah', 'Bourenane', '$2a$11$3SKtK8j8BEt69ixs1TkaOuu8wlHQtzKyb2EfctSKwpSD3dcIvsSoK', 'Key', '2012-12-20', '2012-12-20', 'Member', 1, '', '0', 'Approved'),
(3, 'admin@gmail.com', 'admin', 'boss', '$2a$11$3SKtK8j8BEt69ixs1TkaOuu8wlHQtzKyb2EfctSKwpSD3dcIvsSoK', 'Admin', '2012-12-20', '2012-12-20', 'Admin', 0, '', '0', 'Approved'),
(25, 'pu@gmail.com', 'sarah', 'lu', '$2a$11$EqkT9YJqPqhz7tLB/Y2KSOROQ6ngmaqqNMyi23Hn4uWA7IjtvU7Z6', 'KeyAccessMember', '2024-12-10', '2025-12-10', 'Member', 1, '11 Address Street', '07946435678', 'Approved'),
(26, 'try@gmail.com', 'Julia', 'Peters', 'mkxmec98293nidn39^&^\"^*Bb8d3', 'KeyAccessMember', '0000-00-00', '0000-00-00', 'Member', 1, '', '0999999800', 'pending');

-- --------------------------------------------------------

--
-- Table structure for table `userinterest`
--

CREATE TABLE `userinterest` (
  `UserInterestID` int(5) NOT NULL,
  `UserId` int(5) NOT NULL,
  `InterestID` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `userinterest`
--

INSERT INTO `userinterest` (`UserInterestID`, `UserId`, `InterestID`) VALUES
(29, 25, 1);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `interest`
--
ALTER TABLE `interest`
  ADD PRIMARY KEY (`InterestID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserId`);

--
-- Indexes for table `userinterest`
--
ALTER TABLE `userinterest`
  ADD PRIMARY KEY (`UserInterestID`),
  ADD KEY `InterestID` (`InterestID`),
  ADD KEY `UserId` (`UserId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `interest`
--
ALTER TABLE `interest`
  MODIFY `InterestID` int(2) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `UserId` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `userinterest`
--
ALTER TABLE `userinterest`
  MODIFY `UserInterestID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=30;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `userinterest`
--
ALTER TABLE `userinterest`
  ADD CONSTRAINT `userinterest_ibfk_1` FOREIGN KEY (`InterestID`) REFERENCES `interest` (`InterestID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `userinterest_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
