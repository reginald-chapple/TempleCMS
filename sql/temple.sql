-- phpMyAdmin SQL Dump
-- version 5.1.1deb5ubuntu1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Nov 05, 2023 at 03:53 PM
-- Server version: 8.0.35-0ubuntu0.22.04.1
-- PHP Version: 8.1.2-1ubuntu2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `temple`
--

-- --------------------------------------------------------

--
-- Table structure for table `Articles`
--

CREATE TABLE `Articles` (
  `Id` bigint NOT NULL,
  `Title` longtext NOT NULL,
  `Body` longtext NOT NULL,
  `Image` longtext NOT NULL,
  `ChurchId` bigint NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoleClaims`
--

CREATE TABLE `AspNetRoleClaims` (
  `Id` int NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetRoles`
--

CREATE TABLE `AspNetRoles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `AspNetRoles`
--

INSERT INTO `AspNetRoles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('79c71a66-88cd-4181-9dca-92ec161c15ec', 'Member', 'MEMBER', '816a55a4-9ca8-47f8-b8b9-063b8ab02320'),
('be2d0438-3358-470c-a4ab-ed8f2a6a0903', 'Administrator', 'ADMINISTRATOR', '40c7ac3e-8605-4687-b94c-b378ee0acb90'),
('c0ac2a08-fa81-4bb6-a615-34075de248a6', 'Leadership', 'LEADERSHIP', 'd6df6d97-436e-4a2b-b10e-f5381b0bb426');

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserClaims`
--

CREATE TABLE `AspNetUserClaims` (
  `Id` int NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext,
  `ClaimValue` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserLogins`
--

CREATE TABLE `AspNetUserLogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` longtext,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserRoles`
--

CREATE TABLE `AspNetUserRoles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `AspNetUserRoles`
--

INSERT INTO `AspNetUserRoles` (`UserId`, `RoleId`) VALUES
('bd43d285-4136-4304-a660-9c86f4b7ed2c', 'c0ac2a08-fa81-4bb6-a615-34075de248a6');

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUsers`
--

CREATE TABLE `AspNetUsers` (
  `Id` varchar(255) NOT NULL,
  `FullName` longtext NOT NULL,
  `Image` longtext NOT NULL,
  `DateOfBirth` datetime(6) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext,
  `SecurityStamp` longtext,
  `ConcurrencyStamp` longtext,
  `PhoneNumber` longtext,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `AspNetUsers`
--

INSERT INTO `AspNetUsers` (`Id`, `FullName`, `Image`, `DateOfBirth`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('bd43d285-4136-4304-a660-9c86f4b7ed2c', 'Richard Green', 'noimage.png', '1901-01-01 00:00:00.000000', 'richardgreen@local.com', 'RICHARDGREEN@LOCAL.COM', 'richardgreen@local.com', 'RICHARDGREEN@LOCAL.COM', 0, 'AQAAAAEAACcQAAAAEKl8IUxjFwQMoj7J8rX8gF6HU4/hLV2pAcRAMlh/rgtEuwf6nM13M3HvnETopDHoBA==', 'QKCU5SYUGKBFE5PADVIP4WKW7HGSAZ2L', '055f1686-c464-4832-b2a7-bf66ebc78994', NULL, 0, 0, NULL, 1, 0);

-- --------------------------------------------------------

--
-- Table structure for table `AspNetUserTokens`
--

CREATE TABLE `AspNetUserTokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` longtext
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Beliefs`
--

CREATE TABLE `Beliefs` (
  `Id` bigint NOT NULL,
  `Title` longtext NOT NULL,
  `Details` longtext NOT NULL,
  `ChurchId` bigint NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Bookings`
--

CREATE TABLE `Bookings` (
  `Id` bigint NOT NULL,
  `Details` longtext NOT NULL,
  `DateDesired` datetime(6) DEFAULT NULL,
  `DateBooked` datetime(6) DEFAULT NULL,
  `IsCancelled` tinyint(1) NOT NULL,
  `IsAccepted` tinyint(1) NOT NULL,
  `ServiceId` bigint NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ChatMessages`
--

CREATE TABLE `ChatMessages` (
  `Id` bigint NOT NULL,
  `Content` longtext NOT NULL,
  `AuthorId` longtext NOT NULL,
  `ChatId` bigint NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Chats`
--

CREATE TABLE `Chats` (
  `Id` bigint NOT NULL,
  `Name` longtext NOT NULL,
  `Type` int NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ChatUsers`
--

CREATE TABLE `ChatUsers` (
  `UserId` varchar(255) NOT NULL,
  `ChatId` bigint NOT NULL,
  `Role` int NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Churches`
--

CREATE TABLE `Churches` (
  `Id` bigint NOT NULL,
  `Name` longtext NOT NULL,
  `Background` longtext NOT NULL,
  `Message` longtext NOT NULL,
  `Mission` longtext NOT NULL,
  `Image` longtext NOT NULL,
  `DenominationId` bigint NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Churches`
--

INSERT INTO `Churches` (`Id`, `Name`, `Background`, `Message`, `Mission`, `Image`, `DenominationId`, `Created`, `Updated`) VALUES
(1, 'St Joan of Arc', '', '', '', 'noimage.png', 1, '2023-11-05 01:09:10.360244', '2023-11-05 01:09:10.360335');

-- --------------------------------------------------------

--
-- Table structure for table `ChurchMembers`
--

CREATE TABLE `ChurchMembers` (
  `Id` bigint NOT NULL,
  `Role` int NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ChurchId` bigint NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `ChurchMembers`
--

INSERT INTO `ChurchMembers` (`Id`, `Role`, `UserId`, `ChurchId`, `Created`, `Updated`) VALUES
(1, 0, 'bd43d285-4136-4304-a660-9c86f4b7ed2c', 1, '2023-11-05 01:09:10.556651', '2023-11-05 01:09:10.556655');

-- --------------------------------------------------------

--
-- Table structure for table `Denominations`
--

CREATE TABLE `Denominations` (
  `Id` bigint NOT NULL,
  `Name` longtext NOT NULL,
  `Branch` int NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Denominations`
--

INSERT INTO `Denominations` (`Id`, `Name`, `Branch`, `Created`, `Updated`) VALUES
(1, 'Latin Church', 0, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(2, 'Alexandrian Rite', 0, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(3, 'Armenian Rite', 0, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(4, 'Byzantine Rite', 0, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(5, 'East Syriac Rite', 0, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(6, 'West Syriac Rite', 0, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(7, 'Greek Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(8, 'Albanian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(9, 'Vicariate for Palestine and Jordan', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(10, 'Finnish Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(11, 'Korean Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(12, 'Estonian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(13, 'Ukrainian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(14, 'Orthodox Metropolitanate of Singapore', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(15, 'American Carpatho-Russian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(16, 'Antiochian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(17, 'Russian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(18, 'Japanese Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(19, 'Chinese Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(20, 'Moldovan Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(21, 'Belarusian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(22, 'Philippine Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(23, 'Georgian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(24, 'Serbian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(25, 'Romanian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(26, 'Bulgarian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(27, 'Cypriot Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(28, 'Orthodox Church of Greece', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(29, 'Polish Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(30, 'Orthodox Church in America', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(31, 'Orthodox Church of Ukraine', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(32, 'Macedonian Orthodox', 1, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(33, 'Armenian Apostolic', 2, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(34, 'Coptic Orthodox', 2, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(35, 'Eritrean Orthodox Tewahedo', 2, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(36, 'Ethiopian Orthodox Tewahedo', 2, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(37, 'Malankara Orthodox Syrian', 2, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(38, 'Syriac Orthodox', 2, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(39, 'Lutheran', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(40, 'Reformed', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(41, 'Anglican', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(42, 'Anabaptist', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(43, 'Baptist', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(44, 'Methodist', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(45, 'Adventist', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(46, 'Quaker', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(47, 'Plymouth Brethren', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(48, 'Pentecostal', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(49, 'Charismatic', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(50, 'Presbyterian', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(51, 'Evangelical', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(52, 'Eastern Protestant', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(53, 'Messianic Judaism', 3, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(54, 'Unitarian', 4, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(55, 'Unitarian Universalist', 4, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(56, 'Latter Day Saints', 4, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(57, 'Jahovah Witness', 4, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(58, 'Swedenborgianism', 4, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(59, 'Christian Science', 4, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000'),
(60, 'Non-Denominational', 5, '2023-10-25 17:44:41.000000', '2023-10-25 17:44:41.000000');

-- --------------------------------------------------------

--
-- Table structure for table `Events`
--

CREATE TABLE `Events` (
  `Id` bigint NOT NULL,
  `Name` longtext NOT NULL,
  `Details` longtext NOT NULL,
  `StartTime` datetime(6) DEFAULT NULL,
  `EndTime` datetime(6) DEFAULT NULL,
  `IsFree` tinyint(1) NOT NULL,
  `Type` int NOT NULL,
  `ChurchId` bigint NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Events`
--

INSERT INTO `Events` (`Id`, `Name`, `Details`, `StartTime`, `EndTime`, `IsFree`, `Type`, `ChurchId`, `Created`, `Updated`) VALUES
(1, 'Wednesday Night Bible Study', 'Sed felis velit, sodales ut mollis ut, scelerisque eu nibh. Integer egestas semper dui nec ornare. Fusce finibus, leo vel fringilla blandit, tortor ligula viverra nibh, interdum hendrerit sem odio egestas justo. Integer felis elit, tempor ac venenatis id, rutrum eleifend mi. Pellentesque cursus nec urna et faucibus. Donec elit dui, ullamcorper at nibh nec, accumsan tristique mi. Sed eu orci quis arcu fermentum ultricies in quis dui. Vivamus vestibulum ultrices augue at eleifend. Nunc blandit, massa a tristique tincidunt, erat sem varius sem, in volutpat arcu metus ut velit. Suspendisse potenti. Phasellus euismod nulla quam, ac bibendum augue venenatis in. Aliquam vestibulum augue odio, et rutrum dolor sagittis et. Vestibulum et diam volutpat, semper sapien nec, feugiat lorem.', '2023-11-08 18:30:00.000000', '2023-11-08 20:30:00.000000', 0, 0, 1, '2023-11-05 01:57:25.000000', '2023-11-05 01:57:25.000000'),
(2, 'Sunday Mass', 'Pellentesque cursus nec urna et faucibus. Donec elit dui, ullamcorper at nibh nec, accumsan tristique mi. Sed eu orci quis arcu fermentum ultricies in quis dui. Vivamus vestibulum ultrices augue at eleifend. Nunc blandit, massa a tristique tincidunt, erat sem varius sem, in volutpat arcu metus ut velit. Suspendisse potenti. Phasellus euismod nulla quam, ac bibendum augue venenatis in. Aliquam vestibulum augue odio, et rutrum dolor sagittis et. Vestibulum et diam volutpat, semper sapien nec, feugiat lorem.', '2023-10-05 08:00:00.000000', '2023-10-05 10:00:00.000000', 0, 5, 1, '2023-11-05 03:52:45.020393', '2023-11-05 03:52:45.020450');

-- --------------------------------------------------------

--
-- Table structure for table `EventUsers`
--

CREATE TABLE `EventUsers` (
  `UserId` varchar(255) NOT NULL,
  `EventId` bigint NOT NULL,
  `Role` int NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `GroupMembers`
--

CREATE TABLE `GroupMembers` (
  `MemberId` varchar(255) NOT NULL,
  `GroupId` bigint NOT NULL,
  `Id` bigint NOT NULL,
  `Role` int NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Groups`
--

CREATE TABLE `Groups` (
  `Id` bigint NOT NULL,
  `Name` longtext NOT NULL,
  `Details` longtext NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Notifications`
--

CREATE TABLE `Notifications` (
  `Id` bigint NOT NULL,
  `Text` longtext NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Services`
--

CREATE TABLE `Services` (
  `Id` bigint NOT NULL,
  `Type` int NOT NULL,
  `ChurchId` bigint NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `UserNotifications`
--

CREATE TABLE `UserNotifications` (
  `NotificationId` bigint NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `IsRead` tinyint(1) NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `Values`
--

CREATE TABLE `Values` (
  `Id` bigint NOT NULL,
  `Name` longtext NOT NULL,
  `Details` longtext NOT NULL,
  `ChurchId` bigint NOT NULL,
  `Created` datetime(6) NOT NULL,
  `Updated` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20231105073225_Renew', '6.0.23'),
('20231105104633_UpdateEnum', '6.0.23');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Articles`
--
ALTER TABLE `Articles`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Articles_ChurchId` (`ChurchId`);

--
-- Indexes for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetRoles`
--
ALTER TABLE `AspNetRoles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `AspNetUsers`
--
ALTER TABLE `AspNetUsers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `Beliefs`
--
ALTER TABLE `Beliefs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Beliefs_ChurchId` (`ChurchId`);

--
-- Indexes for table `Bookings`
--
ALTER TABLE `Bookings`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Bookings_ServiceId` (`ServiceId`),
  ADD KEY `IX_Bookings_UserId` (`UserId`);

--
-- Indexes for table `ChatMessages`
--
ALTER TABLE `ChatMessages`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_ChatMessages_ChatId` (`ChatId`);

--
-- Indexes for table `Chats`
--
ALTER TABLE `Chats`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `ChatUsers`
--
ALTER TABLE `ChatUsers`
  ADD PRIMARY KEY (`ChatId`,`UserId`),
  ADD KEY `IX_ChatUsers_UserId` (`UserId`);

--
-- Indexes for table `Churches`
--
ALTER TABLE `Churches`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Churches_DenominationId` (`DenominationId`);

--
-- Indexes for table `ChurchMembers`
--
ALTER TABLE `ChurchMembers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_ChurchMembers_UserId` (`UserId`),
  ADD KEY `IX_ChurchMembers_ChurchId` (`ChurchId`);

--
-- Indexes for table `Denominations`
--
ALTER TABLE `Denominations`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Events`
--
ALTER TABLE `Events`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Events_ChurchId` (`ChurchId`);

--
-- Indexes for table `EventUsers`
--
ALTER TABLE `EventUsers`
  ADD PRIMARY KEY (`EventId`,`UserId`),
  ADD KEY `IX_EventUsers_UserId` (`UserId`);

--
-- Indexes for table `GroupMembers`
--
ALTER TABLE `GroupMembers`
  ADD PRIMARY KEY (`GroupId`,`MemberId`),
  ADD KEY `IX_GroupMembers_MemberId` (`MemberId`);

--
-- Indexes for table `Groups`
--
ALTER TABLE `Groups`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Notifications`
--
ALTER TABLE `Notifications`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Services`
--
ALTER TABLE `Services`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Services_ChurchId` (`ChurchId`);

--
-- Indexes for table `UserNotifications`
--
ALTER TABLE `UserNotifications`
  ADD PRIMARY KEY (`NotificationId`,`UserId`),
  ADD KEY `IX_UserNotifications_UserId` (`UserId`);

--
-- Indexes for table `Values`
--
ALTER TABLE `Values`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Values_ChurchId` (`ChurchId`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Articles`
--
ALTER TABLE `Articles`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Beliefs`
--
ALTER TABLE `Beliefs`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Bookings`
--
ALTER TABLE `Bookings`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `ChatMessages`
--
ALTER TABLE `ChatMessages`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Chats`
--
ALTER TABLE `Chats`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Churches`
--
ALTER TABLE `Churches`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `ChurchMembers`
--
ALTER TABLE `ChurchMembers`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `Denominations`
--
ALTER TABLE `Denominations`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT for table `Events`
--
ALTER TABLE `Events`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `Groups`
--
ALTER TABLE `Groups`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Notifications`
--
ALTER TABLE `Notifications`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Services`
--
ALTER TABLE `Services`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Values`
--
ALTER TABLE `Values`
  MODIFY `Id` bigint NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Articles`
--
ALTER TABLE `Articles`
  ADD CONSTRAINT `FK_Articles_Churches_ChurchId` FOREIGN KEY (`ChurchId`) REFERENCES `Churches` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetRoleClaims`
--
ALTER TABLE `AspNetRoleClaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserClaims`
--
ALTER TABLE `AspNetUserClaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserLogins`
--
ALTER TABLE `AspNetUserLogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserRoles`
--
ALTER TABLE `AspNetUserRoles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `AspNetUserTokens`
--
ALTER TABLE `AspNetUserTokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `Beliefs`
--
ALTER TABLE `Beliefs`
  ADD CONSTRAINT `FK_Beliefs_Churches_ChurchId` FOREIGN KEY (`ChurchId`) REFERENCES `Churches` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `Bookings`
--
ALTER TABLE `Bookings`
  ADD CONSTRAINT `FK_Bookings_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Bookings_Services_ServiceId` FOREIGN KEY (`ServiceId`) REFERENCES `Services` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `ChatMessages`
--
ALTER TABLE `ChatMessages`
  ADD CONSTRAINT `FK_ChatMessages_Chats_ChatId` FOREIGN KEY (`ChatId`) REFERENCES `Chats` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `ChatUsers`
--
ALTER TABLE `ChatUsers`
  ADD CONSTRAINT `FK_ChatUsers_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ChatUsers_Chats_ChatId` FOREIGN KEY (`ChatId`) REFERENCES `Chats` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `Churches`
--
ALTER TABLE `Churches`
  ADD CONSTRAINT `FK_Churches_Denominations_DenominationId` FOREIGN KEY (`DenominationId`) REFERENCES `Denominations` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `ChurchMembers`
--
ALTER TABLE `ChurchMembers`
  ADD CONSTRAINT `FK_ChurchMembers_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_ChurchMembers_Churches_ChurchId` FOREIGN KEY (`ChurchId`) REFERENCES `Churches` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `Events`
--
ALTER TABLE `Events`
  ADD CONSTRAINT `FK_Events_Churches_ChurchId` FOREIGN KEY (`ChurchId`) REFERENCES `Churches` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `EventUsers`
--
ALTER TABLE `EventUsers`
  ADD CONSTRAINT `FK_EventUsers_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_EventUsers_Events_EventId` FOREIGN KEY (`EventId`) REFERENCES `Events` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `GroupMembers`
--
ALTER TABLE `GroupMembers`
  ADD CONSTRAINT `FK_GroupMembers_AspNetUsers_MemberId` FOREIGN KEY (`MemberId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_GroupMembers_Groups_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `Groups` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `Services`
--
ALTER TABLE `Services`
  ADD CONSTRAINT `FK_Services_Churches_ChurchId` FOREIGN KEY (`ChurchId`) REFERENCES `Churches` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `UserNotifications`
--
ALTER TABLE `UserNotifications`
  ADD CONSTRAINT `FK_UserNotifications_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_UserNotifications_Notifications_NotificationId` FOREIGN KEY (`NotificationId`) REFERENCES `Notifications` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `Values`
--
ALTER TABLE `Values`
  ADD CONSTRAINT `FK_Values_Churches_ChurchId` FOREIGN KEY (`ChurchId`) REFERENCES `Churches` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
