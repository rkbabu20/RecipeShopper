# Introduction
This is a single api for multiple micro services. Users Service, Orders Service, Ingradients Service, Recipes Service and Cart Service.

# Technology
1. .Net core 8
2. EF Core 8
3. SQL Server 2019
4. Docker
5. Github

# Architectural style and Design
1. Clear Architectural Style
2. Domain Driven Design model

# Design Patterns 
1. CQRS Design Pattern
2. Repository Pattern
3. SOLID Priniciples 

# nuget packages used
1. MediatR
2. AutoMapper
3. Microsoft.EntityFrameworkCore
4. Microsoft.AspNetCore.Identity.EntityFrameWorkCore.
5. Microsoft.EntityFrameworkCore.Design
6. Microsoft.EntityFrameworkCore.SqlServer
7. Microsoft.EntityFrameworkCore.Tools
8. Microsoft.IdentitModel.Tokens
9. Microsoft.AspnetCore.Authentication.JwtBearer

# Solution Setup
# DB Setup
Download the latest docker image for ms sql server 2019
1. Clone this repo in your local machine/laptop.
2. Install docker in your local machine.
3. Run below command to download the docker image.
    docker pull mcr.microsoft.com/mssql/server:2019-latest
4. Run following command in docket to run the sql server [Sql server 2019 will be up and running in your docker]
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD={ProvideYourOwnPasswordHere}" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
5. Open the solution in visual studio 2022
6. Under RecipeShopper.Api update Connection Strings at appsettings.json file to point to your local sql server 2019.
7. Then go to package manager console (Visual Studio -> Tools -> Nuget Package Manager -> Package Manager Console ) run below command
8. update-database [Wait for the scripts to complete]. Once completed then refresh your sql server 2019 DB instances. You should see RecipeShopperDB instance up and running.
9. Run the visual studio solution whcih will open up swagger
10. Use /api/User/register to register yourself to the portal.
11. Use /api/Login/authenticate to login. to login use user name and password just created. Successful login provides you JWT bearer token. You can use it to explore the rest of the end points.
