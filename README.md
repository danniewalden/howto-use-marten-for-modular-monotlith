# Marten in a Modular Monolith - how to?

## How to run the application
1. Execute `docker-compose up -d` to start dependencies (postgres)
2. Execute `dotnet run --project Host/Host.csproj` to start application - which creates databases schema and runs migrations


## Actual Results
* Each tenant has its own database
* Document schema (tables and routines) from Module1 and and Module2 exists in both tenant databases

## Wishful Results
* Each tenant has its own database
* Document schema (tables and routines) from Module1 exists only in tenant1 database
* Document schema (tables and routines) from Module2 exists only in tenant2 database

## Thoughts
According to this [Discord Thread](https://discord.com/channels/1074998995086225460/1148153462710874112), tenancy (not conjoined) sounds like a viable option in Marten for separating storage.
Right now, i get both modules' schema in both database.
I would think that separating document schema (tables and routines) from each module in a modular monolith should be the way to go.
Is this achievable with Marten?
