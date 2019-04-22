# Building WEB API with ASP.Net Core

Web APIs with ASP.Net Core
https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-2.2

MySQL Connector
https://mysql-net.github.io/MySqlConnector/tutorials/net-core-mvc/

```
CREATE TABLE IF NOT EXISTS `Post` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Content` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB;
```

Starting your MySQL Server
In MacOs,
- System preferences
- MySQL
- Start MySQL Server
  - Choose Use legacy password
Source: https://stackoverflow.com/questions/49194719/authentication-plugin-caching-sha2-password-cannot-be-loaded
