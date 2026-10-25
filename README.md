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

### Run the API

```bash
dotnet run --project src/Api/Api.csproj
```

The API launch profiles are defined in `src/Api/Properties/launchSettings.json`. Swagger is configured for non-production environments.

> **Current status:** the repository contains the initial .NET solution scaffold. The complete application, database integration, migrations, translation workflow, and test suite are still under development. Local infrastructure setup will be documented as it is added.

## Configuration and Secrets

Keep non-sensitive configuration in `appsettings.json`.

Do not commit passwords, API keys, access tokens, or production connection strings.

For local development, initialize .NET User Secrets:

```bash
dotnet user-secrets init --project src/Api/Api.csproj
```

Use environment variables or an appropriate secret-management solution for CI and deployment.

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
