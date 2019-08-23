# Krabs
`useless to anyone else`

To create the database.
```
docker-compose up
Update-Database --context=ApplicationDbContext
Update-Database --context=ConfigurationDbContext
Update-Database --context=PersistedGrantDbContext
```