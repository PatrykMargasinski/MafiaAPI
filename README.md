# MafiaBackend

This is an Api to the mafia fronted project which can be found under this link https://github.com/PatrykMargasinski/MafiaFrontend

# Required installations

- DotNet 5.0
- EF tool (migrations)

# Run backend server

Use `dotnet run` to run the server

# Migrations

CL EF:  
- add migration:  
    `dotnet ef migrations add <name>`  
- update database from migration:  
    `dotnet ef database update`  
- drop database:   
    `dotnet ef database drop`

# Swagger

Swagger is a tool to document an API. ASP.NET generate swagger's docs automatically, but for better description it can be done manually. If you want to check how to make endpoint/model documentation by hand, you can check Swashbuckle project. https://github.com/domaindrivendev/Swashbuckle.AspNetCore. You can check API documentation under this link after run .net server: http://localhost:53191/swagger