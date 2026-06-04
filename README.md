# TestApp

A minimal ASP.NET Core (Razor Pages) web app that reads rows from a PostgreSQL
database using Entity Framework Core and shows them in an HTML table. The schema
and seed data are created via EF Core migrations.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A running PostgreSQL server (default expected at `localhost:5432`)

## Configuration (no secrets in the repo)

`appsettings.json` ships a **password-less** connection string:

```
Host=localhost;Port=5432;Database=testapp;Username=postgres
```

Supply the password locally with **.NET User Secrets** (stored in your user
profile, never committed):

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" \
  "Host=localhost;Port=5432;Database=testapp;Username=postgres;Password=YOUR_PASSWORD"
```

Alternatively, set it via an environment variable (handy for CI / containers /
production, where User Secrets are not loaded):

```bash
# Linux/macOS
export ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=testapp;Username=postgres;Password=YOUR_PASSWORD"

# Windows PowerShell
$env:ConnectionStrings__DefaultConnection = "Host=localhost;Port=5432;Database=testapp;Username=postgres;Password=YOUR_PASSWORD"
```

Configuration precedence (later wins): `appsettings.json` → User Secrets
(Development only) → environment variables.

## Run

```bash
dotnet run
```

The app applies any pending EF migrations on startup (creating the `testapp`
database, the `Products` table, and seed rows), then serves the table at the URL
it prints (e.g. `http://localhost:5xxx`).

## Useful commands

```bash
dotnet ef migrations add <Name>   # create a new migration
dotnet ef database update         # apply migrations manually
```
