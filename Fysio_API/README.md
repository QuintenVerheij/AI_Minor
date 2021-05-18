# Setup API


## Installeer packages in Visual Studio

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Npgsql
- Npgsql.EntityFrameworkCore.PostgreSQL
- AutoMapper.Extensions.Microsoft.DependencyInjection


## Installeer PostgreSQL and PgAdmin

Voor een makkelijke database connectie is het handig om ieder hetzelfde account op te zetten in PostgreSQL. 
1. Ga in PgAdmin naar de standaard PostgreSQL server 
2. Via Login/Group Roles maak een nieuwe user
3. Name: 'FysioAppRole'   -   Password: 'RoleAppFysio'
4. Zorg dat bij privileges alles op Yes staat en klik op save.

## Gebruik

Het project maakt gebruik van een Code_First implementatie van Entity Framework Core. Op deze manier wordt de database geüpdate aan de hand van de modellen.

``` bash
Add-Migration 'migration_name'
Update-Database
```
