# XBit-Api

# Docker
## Run the containers

```
docker-compose up
```
It will download the containers and start them. If they are not built, it will also do it.

In the future, if you change your code or want to rebuild, execute

```
docker-compose up --build
```

## Windows
### Database initialization
```
docker exec -it sql_server powershell
sqlcmd
```

```
CREATE DATABASE Countries
GO
```

```
CREATE TABLE Countries
(id varchar(100) PRIMARY KEY NOT NULL,
name varchar(100) NOT NULL) 
GO
```

### Test the API

```
curl -Method POST -Uri 'http://127.0.0.1:52706/api/country' -Headers @{"Content-Type"="application/json"} -Body '{"Id": "00000000-0000-0000-0000-000000000001","Name": "Switzerland"}'
```

### Security
To connect to your database, you can use the same setup as in Windows or enable SSPI. You will need to follow the steps indicated [here](https://docs.microsoft.com/en-us/virtualization/windowscontainers/manage-containers/manage-serviceaccounts)

## Linux
### docker-compose
Replace the first image by `microsoft/mssql-server-linux:latest` and remove the external network

### Database initialization

```
docker exec -it sql_server powershell
sqlcmd
```

```
CREATE DATABASE Countries
GO
```

```
CREATE TABLE Countries
(id varchar(100) PRIMARY KEY NOT NULL,
name varchar(100) NOT NULL) 
GO
```

### Test the API
```
curl --request POST \
  --url 'http://localhost:52706/api/country' \
  --header 'Content-Type: application/json' \
  --data '{
    "Id": "00000000-0000-0000-0000-000000000001",
    "Name": "Switzerland"
  }
```

### Security
Set up the security as follow by editing [EF/XBitContext.cs](./EF/XBitContext.cs)
```
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var connection = @"Server=sql_server;Database=master;User=sa;Password=Your_password123;";
    optionsBuilder.UseSqlServer(connection);
    base.OnConfiguring(optionsBuilder);
}
```

