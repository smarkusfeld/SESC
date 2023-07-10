-- create databases
CREATE DATABASE IF NOT EXISTS librarydb;
CREATE DATABASE IF NOT EXISTS financedb;
CREATE DATABASE IF NOT EXISTS identitydb;
CREATE DATABASE IF NOT EXISTS registrardb;

-- create users and grant rights
GRANT ALL ON registrardb.* TO root@'%';
GRANT ALL ON librarydb.* TO root@'%';
GRANT ALL ON financedb.* TO root@'%';
GRANT ALL ON identitydb.* TO root@'%';

FLUSH PRIVILEGES;
