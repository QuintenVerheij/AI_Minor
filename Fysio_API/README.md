# Setup API


## Installeer packages in Visual Studio

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Npgsql
- Npgsql.EntityFrameworkCore.PostgreSQL
- AutoMapper.Extensions.Microsoft.DependencyInjection

## docker
installeer docker desktop en maak een account enz. 
1. https://www.docker.com/products/docker-desktop

visualstudio:
2. rechterklik docker-compose -> set as startup project.
next bovenaan start het project met docker-compose.

visual studio code:
2. in de terminal:
docker-compose up

3. als het goed is start swagger nu in je browser.

4. ga naar localhost:5050 in een andere tab.
5. log in met:
email: pgadmin4@pgadmin.org
password: admin

je bent nu in een pgadmin die in een dockercontainer runt.
6. Via Login/Group Roles maak een nieuwe user
7. Name: 'FysioAppRole'   -   Password: 'RoleAppFysio'
8. Zorg dat bij privileges alles op Yes staat en klik op save.

migrations worden automatisch op je db toegepast als je het project runt met docker-compose.
9. voeg aan de tabel aspNetRoles toe:
1 CLIENT CLIENT null
2 THERAPIST THERAPIST null

10. je kunt nu een account registreren via de swagger pagina.


