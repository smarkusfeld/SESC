-- create databases
CREATE DATABASE librarydb;
CREATE DATABASE financedb;
CREATE DATABASE identitydb;
CREATE DATABASE registrardb;

-- create users and grant rights
GRANT ALL ON registrardb.* TO root@'%';
GRANT ALL ON librarydb.* TO root@'%';
GRANT ALL ON financedb.* TO root@'%';
GRANT ALL ON identitydb.* TO root@'%';

FLUSH PRIVILEGES;
