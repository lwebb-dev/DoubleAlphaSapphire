# DoubleAlphaSapphire App

Web App for consolidating Nuzlocke battle data for x360NoDad's Alpha Sapphire romhack (referred in this repo as DoubleAlphaSapphire, sometimes commonly referred to as "Daddy Doubles").


## Contributing

See [CONTRIBUTING](docs/CONTRIBUTING.md) for details and Code of Conduct for contributing to this repo. Also read Coding Conventions at [CONVENTIONS](docs/CONVENTIONS.md).


## Local Setup


1. Clone the repository.
2. Create a local [PostgreSQL](https://www.postgresql.org/) database. This can be a local instance running on your host kernel or a virtualized instance using Hyper-V or Docker. You may use the docker-compose file in this repository if you wish, the important thing is that you are able to connect to the database.
3. Store the connection string for this PostgreSQL database with [user-secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows#set-a-secret) under `UserSecretsUtility:POSTGRES_CONNECTION_STRING`.

```
dotnet user-secrets set "UserSecretsUtility:POSTGRES_CONNECTION_STRING" "<YOUR_CONNECTION_STRING>"
```

4. Build & Run the DoubleAlphaSapphire.App project. Migrations wwill be run against your PostgreSQL database automatically.

The App should now be running and available at https://localhost:7079.
