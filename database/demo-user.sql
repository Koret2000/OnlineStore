-- Synthetic local demo account, unrelated to the college export.
USE `mamliga`;

INSERT INTO `tbl_users` (`Login`, `Password`, `FullName`, `Role`)
SELECT 'demo', 1234, 'Demo User', 'user'
WHERE NOT EXISTS (SELECT 1 FROM `tbl_users` WHERE `Login` = 'demo');
