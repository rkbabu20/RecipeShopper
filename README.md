# Introduction
This is a single api for multiple micro services. Users Service, Orders Service, Ingradients Service, Recipes Service and Cart Service.

# Technology
1. .Net core 8
2. EF Core 8
3. CQRS Design Pattern
4. Repository Pattern
5. Docker
6. Github 

# nuget packages used
1. Microsoft.EntityFramework.Core
2. MediatR
3. AutoMapper

# DB Setup
Download the latest docker image for ms sql server 2019
1. Run below command to download the docker image.
	docker pull mcr.microsoft.com/mssql/server:2019-latest
2. Run following command in docket to run the sql server
	docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=KeltonExercise@123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
