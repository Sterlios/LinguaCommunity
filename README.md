# .NET Backend Project Template

A reusable template for creating .NET backend projects with a layered architecture.

The template provides a predefined project structure with separate layers for API, application logic, domain logic, and infrastructure.

## Project Structure

```text
src/
├── Api/
├── Application/
├── Domain/
└── Infrastructure/

tests/
└── ...
```

Each layer is represented by a separate `.csproj` project.

## Architecture

The basic dependency structure is:

```text
        ┌─────────┐
        │   Api   │
        └────┬────┘
             │
             ▼
      ┌─────────────┐
      │ Application │
      └──────┬──────┘
             │
             ▼
       ┌─────────┐
       │ Domain  │
       └─────────┘

Infrastructure ──────► Domain
```

### Layers

| Layer            | Responsibility                                                                       |
| ---------------- | ------------------------------------------------------------------------------------ |
| `Api`            | HTTP API, controllers, authentication, authorization, and API configuration          |
| `Application`    | Use cases, application logic, DTOs, and application interfaces                       |
| `Domain`         | Domain entities, value objects, enums, and domain rules                              |
| `Infrastructure` | Database access, repositories, external services, and infrastructure implementations |

The exact contents of each layer may vary depending on the project.

---

# Creating a New Project

## 1. Create a Repository from the Template

Create a new GitLab repository using this repository as a template.

Clone the new repository locally:

```bash
git clone <repository-url>
cd <project-directory>
```

---

## 2. Rename the Solution

The template contains a solution with the template name.

Rename it to the name of your new project.

For example:

```text
Template.sln
```

becomes:

```text
SchoolPlatform.sln
```

---

## 3. Rename the Projects

The template contains the following projects:

```text
Template.Api
Template.Application
Template.Domain
Template.Infrastructure
```

Rename them using the new project name.

For example:

```text
SchoolPlatform.Api
SchoolPlatform.Application
SchoolPlatform.Domain
SchoolPlatform.Infrastructure
```

Make sure to rename the corresponding `.csproj` files as well.

---

## 4. Update `RootNamespace`

Each project defines its own `RootNamespace`.

For example:

```xml
<PropertyGroup>
    <RootNamespace>Template.Api</RootNamespace>
</PropertyGroup>
```

Change it to:

```xml
<PropertyGroup>
    <RootNamespace>SchoolPlatform.Api</RootNamespace>
</PropertyGroup>
```

Update `RootNamespace` for every project:

```text
Template.Api             → SchoolPlatform.Api
Template.Application    → SchoolPlatform.Application
Template.Domain         → SchoolPlatform.Domain
Template.Infrastructure → SchoolPlatform.Infrastructure
```

---

## 5. Update C# Namespaces

Search the entire repository for references to `Template`.

For example:

```csharp
namespace Template.Api.Controllers;
```

Change it to:

```csharp
namespace SchoolPlatform.Api.Controllers;
```

Also update `using` directives:

```csharp
using Template.Application;
using Template.Domain;
```

to:

```csharp
using SchoolPlatform.Application;
using SchoolPlatform.Domain;
```

### Important

Search the entire repository for:

```text
Template
```

Replace all references that belong to the template.

There should be no remaining `Template` references unless they are intentionally kept.

---

## 6. Check Project References

Make sure all project references point to the renamed `.csproj` files.

For example:

```xml
<ProjectReference Include="..\Application\SchoolPlatform.Application.csproj" />
```

instead of:

```xml
<ProjectReference Include="..\Application\Template.Application.csproj" />
```

Also check the project references inside the solution file.

---

# Project-Specific Configuration

After renaming the projects, configure the parts that are specific to the new application.

## Application Configuration

Check:

```text
src/Api/appsettings.json
src/Api/appsettings.Development.json
src/Api/appsettings.Local.json
```

Configure the values required by the new project, such as:

* database connection strings;
* external service URLs;
* authentication settings;
* Kafka configuration;
* Redis configuration;
* other environment-specific settings.

Do not commit passwords, API keys, tokens, or other secrets to the repository.

Use environment variables or an appropriate secret-management solution instead.

For Local environment use dotnet user-secrets

---

## Docker

If the template contains Docker configuration, check:

```text
Dockerfile
docker-compose.yml
.dockerignore
```

Update any project-specific values, such as:

* project names;
* assembly names;
* paths;
* ports;
* service names;
* environment variables.

---

## CI/CD

Check the GitHub CI configuration:

```text
github-ci.yml
```

Update any project-specific settings, such as:

* Docker image names;
* container registry paths;
* environment names;
* deployment configuration;
* project-specific variables.

---

## README

Replace this README with project-specific documentation once the project has been configured.

The project README should describe:

* project purpose;
* architecture;
* how to run the application;
* required dependencies;
* configuration;
* database setup and migrations;
* how to run tests;
* deployment process.

---

# Verify the Project

After completing the renaming and configuration, restore the dependencies:

```bash
dotnet restore
```

Build the solution:

```bash
dotnet build
```

Run the tests:

```bash
dotnet test
```

If the project contains an API, run it:

```bash
dotnet run --project src/Api
```

Make sure the application starts successfully.

---

# Final Checklist

Before starting development, make sure:

* [ ] The repository was created from this template
* [ ] The solution was renamed
* [ ] `RootNamespace` was updated in every project
* [ ] C# namespaces were updated
* [ ] `using` directives were updated
* [ ] `appsettings.json` was configured
* [ ] Docker configuration was checked
* [ ] GitHub CI/CD configuration was checked
* [ ] All unintended `Template` references were removed
* [ ] `dotnet restore` succeeds
* [ ] `dotnet build` succeeds
* [ ] `dotnet test` succeeds
* [ ] The API starts successfully
* [ ] A project-specific README was created

