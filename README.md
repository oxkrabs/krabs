# Krabs
`useless to anyone else`

To create the database.
###For Windows
```
docker-compose up db
Update-Database --context=ApplicationDbContext
Update-Database --context=ConfigurationDbContext
Update-Database --context=PersistedGrantDbContext
```

###For Mac
```
docker-compose up db
dotnet ef database update --context ApplicationDbContext
dotnet ef database update --context PersistedGrantDbContext
dotnet ef database update --context ConfigurationDbContext
```