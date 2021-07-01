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