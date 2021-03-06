# Code First DB Design with EF Core &amp; PostgreSQL

Sample project for code first database design using the **Entity Framework Core** and **PostgreSQL** with Repository Pattern.

> .NET Core version > 3.1

## Projects

| Project                 | Description               |
| :---                    | :---                      |
| EfCorePostgre.Core      | Base                      |
| EfCorePostgre.Data      | Entities (Isolated layer) |
| EfCorePostgre.Dto       | Data transfer objects     |
| EfCorePostgre.Services  | Business Layer            |
| EfCorePostgre.API       | Web API                   |

## DB Migration Commands

``` shell
PM> enable-migrations

-- Create Migrations
PM> dotnet ef migrations add InitialCreate --project <Project Name>

-- Update Database
PM> dotnet ef database update --project <Project Name>

-- Rollback
PM> dotnet ef migrations remove --project <Project Name>
```
