-- Structure taken from the college export mamliga.sql.
-- Personal accounts and passwords from the export are not included.
CREATE DATABASE IF NOT EXISTS `mamliga`
  CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `mamliga`;

CREATE TABLE IF NOT EXISTS `tbl_users` (
  `PK_UserID` int(11) NOT NULL AUTO_INCREMENT,
  `Login` text NOT NULL,
  `Password` int(11) NOT NULL,
  `FullName` text NOT NULL,
  `Role` text NOT NULL,
  PRIMARY KEY (`PK_UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
