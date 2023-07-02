-- create databases
CREATE DATABASE IF NOT EXISTS librarydb;
CREATE DATABASE IF NOT EXISTS financedb;
CREATE DATABASE IF NOT EXISTS identitydb;
CREATE DATABASE IF NOT EXISTS registrardb;

-- create root user and grant rights
CREATE USER 'root'@'localhost' IDENTIFIED BY 'tiaspbiqe2r';
GRANT ALL ON *.* TO 'root'@'localhost';