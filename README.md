# LinguaCommunity

A multilingual article community where people publish in the language they know best, read translated versions of articles, and collaboratively improve translations.

## Project Goals

The goal is to build a platform where:

- Authors publish articles in their preferred language.
- Readers can access machine-translated versions.
- Users suggest corrections to translations.
- Article authors review and accept or reject suggestions.
- Accepted changes create new translation revisions without modifying previous versions.

## Planned MVP

- [ ] Article publishing and feed
- [ ] User authentication and authorization
- [ ] Asynchronous translation through a provider abstraction
- [ ] Translation status tracking and failure handling
- [ ] Translation correction proposals
- [ ] Author approval and rejection workflow
- [ ] Immutable translation revision history
- [ ] Protection against stale and conflicting proposals
- [ ] Comments
- [ ] Unit and integration tests

## Technology Stack

- **Language:** C#
- **Platform:** .NET 10
- **API:** ASP.NET Core Web API
- **Persistence:** PostgreSQL and Entity Framework Core
- **Infrastructure:** Docker and Docker Compose
- **CI:** GitHub Actions

The translation integration will be isolated behind an application-level interface. This makes it possible to start with a mock implementation and introduce an external translation or AI provider later without coupling domain logic to a specific vendor.

## Architecture

The initial solution uses a layered structure:

```text
src/
├── Api/
├── Application/
├── Domain/
└── Infrastructure/

tests/
└── ...
```

### Layer responsibilities

- **Api** — HTTP endpoints, authentication, authorization, and API configuration.
- **Application** — use cases, application services, DTOs, and interfaces.
- **Domain** — business entities, value objects, and domain rules.
- **Infrastructure** — persistence, external integrations, and background processing.
- **Tests** — unit and integration tests.

The intended dependency direction keeps business rules independent of HTTP, database, and external translation-provider implementations.

## Reliability and Engineering Challenges

The project is intended to demonstrate practical approaches to:

- **Background processing** — execute translation jobs outside the HTTP request lifecycle.
- **Outbox pattern** — persist business changes and outgoing work reliably.
- **Retries and recovery** — handle transient provider failures with bounded retries and backoff.
- **Idempotency** — prevent duplicate processing from creating duplicate results or revisions.
- **Optimistic concurrency** — reject correction proposals based on outdated translation revisions.
- **Immutable history** — preserve accepted translation revisions for traceability.
- **Automated testing** — verify business rules and important failure scenarios.

These are planned capabilities and will be implemented incrementally.

## Getting Started

### Prerequisites

- .NET 10 SDK
- Git
- Docker Desktop or Docker Engine (for local infrastructure when configured)

### Restore and build

Clone the repository and run:

```bash
git clone https://github.com/Sterlios/LinguaCommunity.git
cd LinguaCommunity

dotnet restore
dotnet build
```

### Run Docker Compose

#### 1. Configure environment variables

Create a .env file in the repository root:

```
POSTGRES_DB=lingua_community
POSTGRES_USER=lingua_app
POSTGRES_PASSWORD=change_me_for_local_development
POSTGRES_PORT=5432

CONNECTION_STRING=Host=postgres;Port=5432;Database=lingua_community;Username=lingua_app;Password=change_me_for_local_development
```

Use the same database name, username, and password in POSTGRES_* and CONNECTION_STRING. Change the example password for your local environment.

Do not commit .env to the repository. It contains local credentials. You can commit a .env.example file with placeholder values instead.

Docker Compose uses .env for variable substitution. These values must be explicitly passed to a container through environment or env_file.

When the API runs inside Docker Compose, the database hostname is postgres, the name of the PostgreSQL service. Do not use localhost for this connection.

The API container must receive the connection string through the ConnectionStrings__Postgres environment variable.

#### 2. Start the containers

Validate the Compose configuration, then build and start the services:

```
docker compose config
docker compose up --build -d
docker compose ps
```

The PostgreSQL service has a health check. The API should use depends_on with condition: service_healthy so that Compose waits for PostgreSQL to become ready before starting the API.

View the API logs:
```
docker compose logs -f api
```

If the API service publishes port 8080 to the host, open http://localhost:8080. The exact API and Swagger URLs depend on the container and application configuration.

#### 3. Stop the containers

docker compose down

PostgreSQL data is stored in the named Docker volume lingua_community_postgres_data and survives normal container stops and restarts.

Avoid docker compose down -v unless you intentionally want to delete the persisted database volume.

### Run the API

You can run PostgreSQL in Docker while launching the API from your IDE or command line. In this scenario, connect to the published PostgreSQL port using Host=localhost.

Initialize User Secrets for the API project:

```
dotnet user-secrets init --project src/Api/Api.csproj
```

Set the connection string:

```
dotnet user-secrets set "ConnectionStrings:Postgres" "Host=localhost;Port=5432;Database=lingua_community;Username=lingua_app;Password=YOUR_LOCAL_PASSWORD" --project src/Api/Api.csproj
```

Start only PostgreSQL:
```
docker compose up -d postgres
```
Run the API:
```
dotnet run --project src/Api/Api.csproj
```
ASP.NET Core reads the ConnectionStrings:Postgres setting through its configuration system. User Secrets are intended for local development and are not automatically available inside a Docker container.

For the containerized API, pass configuration through the Compose service's environment or use an appropriate secret-management solution.

### Start local infrastructure

The project uses Docker Compose to run PostgreSQL for local development.

1. Make sure Docker Desktop or Docker Engine is running.
2. Create a `.env` file in the repository root:

```dotenv
POSTGRES_DB=lingua_community
POSTGRES_USER=lingua_app
POSTGRES_PASSWORD=local_dev_password_change_me
POSTGRES_PORT=5432
```

Use a different password for your local environment if needed. Do not commit `.env` to the repository.

3. Start PostgreSQL:

```bash
docker compose up -d postgres
```

4. Verify the container status:

```bash
docker compose ps
```

Wait until PostgreSQL reports a healthy status before proceeding.

To stop the container without deleting persisted database data:

```bash
docker compose down
```

PostgreSQL data is stored in a named Docker volume and survives container restarts.

## Configuration and Secrets

- Keep non-sensitive default settings in appsettings.json.
- Use .NET User Secrets when running the API locally outside Docker.
- Use a local .env file for Docker Compose variable substitution; do not commit it.
- Use environment variables or a dedicated secret-management solution for CI and deployment.
- Never commit passwords, API keys, access tokens, or production connection strings.

## Testing

As test projects are introduced, run the full test suite with:

```bash
dotnet test
```

## Continuous Integration

The repository includes a GitHub Actions workflow configured to restore, build, and test the .NET solution on pushes and pull requests targeting `master` and `develop`.

Check the **Actions** tab for the actual status of CI runs.

## Project Status

The project is in its initial setup stage. Features listed in the MVP and engineering sections describe the intended implementation, not functionality already available in the current scaffold.
